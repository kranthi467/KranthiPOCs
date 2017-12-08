using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class EmailSending
    {
        List<string> emailStrings = new List<string>();

        public void SendEmail(List<string> emailStrings)
        {
            foreach (string emailString in emailStrings)
            {
                if (isGroup(emailString))
                {

                    foreach (Email email in getEmailList(emailString))
                    {
                        email.Send();
                    }
                }
                else
                {
                    getCorrespondingEmail(emailString).Send();
                }
            }
        }

        private Email getCorrespondingEmail(string emailString)
        {
            return new Email();
        }

        private IEnumerable<Email> getEmailList(string emailString)
        {
            return new List<Email>();
        }

        private bool isGroup(string emailString)
        {
            throw new NotImplementedException();
        }
    }

    internal class Email
    {
        public void Send()
        {

        }
    }
} 