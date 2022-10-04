using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;

namespace RockstarsHealthCheck.Models
{
    public class MailingViewModel
    {
        private string FromEmail;
        private string FromName;
        private string ToEmail;
        private string Subject;
        private string TextPart;
        private string HtmlPart;


        public static async void SendMail()
        {
            Console.WriteLine("Sent");
            MailjetClient client = new MailjetClient("f61e465b778f2c147258769edf6d84f4", "1f78e321e4a2492382bc1f43129cab42")
            {


            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.Messages, new JArray {
            new JObject {
                        {
                            "FromEmail", "502495@student.fontys.nl"
                        },
                        {
                            "FromName", "Evalynn"
                        },
                        {
                            "Recipients", JArray.Parse(@"[{'Email': '502495@student.fontys.nl'}]")
                        },
                        { 
                            "Subject", "Test"
                        },
                        {
                            "Text-part", "My first Mailjet email"
                        },
                {
                    "Html-part",
                    "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!" 
                }
                        /*{
                            "To",
                                new JArray {
                                    new JObject {
                                    {
                                    "Email",
                                    "502495@student.fontys.nl"
                                    }, {
                                    "Name",
                                    "Evalynn"
                                    }
                                    }
                                    }
                                    }, {
                                    "Subject",
                                    "Greetings from Mailjet."
                                    }, {
                                    "TextPart",
                                    "My first Mailjet email"
                                    }, {
                                    "HTMLPart",
                                    "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
                                    }, {
                                    "CustomID",
                                    "AppGettingStartedTest"
                                    }
                                */
                            }});

            Console.WriteLine(request.Body);
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(response.GetData());
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
        }
    }
}