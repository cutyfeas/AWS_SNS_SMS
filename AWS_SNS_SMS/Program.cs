using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWS_SNS_SMS
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMessage(my_access_key, my_secret_key, "CALCI2018", "Hi Vishal", "+9198185*****");
        }


        public static void SendMessage(string my_access_key, string my_secret_key, string sender_ID, string Message, string ToPhoneNumber)
        {
            try
            {
                AmazonSimpleNotificationServiceClient smsClient =
                    new AmazonSimpleNotificationServiceClient(my_access_key, my_secret_key, Amazon.RegionEndpoint.USEast1);

                var smsAttributes = new Dictionary<string, MessageAttributeValue>();


                //MessageAttributeValue senderID =   A custom ID that contains up to 11 alphanumeric characters, including at least one letter and no spaces. The sender ID is displayed as the message sender on the receiving device. For example, you can use your business brand to make the message source easier to recognize.

                MessageAttributeValue senderID = new MessageAttributeValue();
                senderID.DataType = "String";
                senderID.StringValue = sender_ID;

                MessageAttributeValue sMSType = new MessageAttributeValue();
                sMSType.DataType = "String";
                sMSType.StringValue = "Transactional";

                MessageAttributeValue maxPrice = new MessageAttributeValue();
                maxPrice.DataType = "Number";
                maxPrice.StringValue = "0.5";

                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;


                smsAttributes.Add("AWS.SNS.SMS.SenderID", senderID);
                smsAttributes.Add("AWS.SNS.SMS.SMSType", sMSType);
                smsAttributes.Add("AWS.SNS.SMS.MaxPrice", maxPrice);

                PublishRequest publishRequest = new PublishRequest();
                publishRequest.Message = Message;
                publishRequest.MessageAttributes = smsAttributes;
                publishRequest.PhoneNumber = ToPhoneNumber;

                Task<PublishResponse> result = smsClient.PublishAsync(publishRequest, token);
                result.Wait();
                Console.WriteLine(result.Result.HttpStatusCode);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
                Console.ReadLine();
            }
        }
    }
}
