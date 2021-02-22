using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using CDB.MarketData.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CDB.MarketData.Infra
{
    //Inicialmente pensei em pegar o csv de um storage no Cloud da Amazon, mas achei que seria um canhão para matar um mosquito, mas se fossem muitos arquivos é uma boa opção.
    public class AwsS3HelperService : IStorageHelperService
    {
        private readonly ILogger<AwsS3HelperService> _logger;
        private readonly IAmazonS3 _s3Client;
        private readonly AwsS3BucketOptions _s3BucketOptions;

        public AwsS3HelperService(IAmazonS3 s3Client, AwsS3BucketOptions s3BucketOptions,
            ILogger<AwsS3HelperService> logger)
        {
            _s3Client = s3Client;
            _logger = logger;
            _s3BucketOptions = s3BucketOptions;
        }


        public async Task<string> Get(string fileName, string folder)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(folder))
                    return string.Empty;

                var contentEventStream = await GetSelectObjectContentEventStream();

                string body = string.Empty;

                foreach (var ev in contentEventStream)
                {
                    if (ev is RecordsEvent records)
                    {
                        using (var reader = new StreamReader(records.Payload, Encoding.UTF8))
                            body += reader.ReadToEnd();
                    }
                };

                return body;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                 amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogError("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError("An error occurred with the message '{0}' when reading an object",
                        amazonS3Exception.Message);
                }

                return string.Empty;
            }
        }

        private async Task<ISelectObjectContentEventStream> GetSelectObjectContentEventStream()
        {
            var fileTransferUtility = new TransferUtility(_s3Client);
            var response = await fileTransferUtility.S3Client.SelectObjectContentAsync(new SelectObjectContentRequest()
            {
                Bucket = "xxxxxxxxxxxxxxx",
                Key = "CDI/CDI_Prices.csv",
                ExpressionType = ExpressionType.SQL,
                Expression = "Select * from S3Object",
                InputSerialization = new InputSerialization()
                {
                    CSV = new CSVInput()
                    {
                        FieldDelimiter = ",",
                        FileHeaderInfo = FileHeaderInfo.Use,
                        RecordDelimiter = "\n"
                    },
                    CompressionType = CompressionType.None,
                },
                OutputSerialization = new OutputSerialization()
                {
                    CSV = new CSVOutput()
                    {
                        QuoteFields = QuoteFields.Always,
                        FieldDelimiter = ",",
                        RecordDelimiter = "\n",
                    }
                }
            });
            return response.Payload;
        }
    }
}
