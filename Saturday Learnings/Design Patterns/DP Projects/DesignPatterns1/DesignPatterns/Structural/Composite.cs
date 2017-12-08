using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class CompositePattern
    {

    }

    public interface EmailInterface
    {
        void Send();
        void AddEmail(EmailInterface email);
    }

    public class SingleEmail : EmailInterface
    {
        public void AddEmail(EmailInterface email)
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }

    public class CompositeEmail : EmailInterface
    {
        List<EmailInterface> emailList = new List<EmailInterface>();

        public void AddEmail(EmailInterface email)
        {
            emailList.Add(email);
        }

        public void RemoveEmail(EmailInterface email)
        {
            emailList.Remove(email);
        }

        public void Send()
        {
            foreach (EmailInterface email in emailList)
            {
                email.Send();
            }
        }
    }
    public class Client
    {
        int emailCount = getEmailCount();

        EmailInterface emailList;
        List<string> emailStrings = new List<string>();


        public void processEmail()
        {
            emailList = new SimpleFactory().GetEmailInstance(emailCount);

            foreach (string emailString in emailStrings)
            {
                emailList.AddEmail(getEmail(emailString));
            }

            emailList.Send();
        }


        private EmailInterface getEmail(string emailString)
        {
            if (isGroup(emailString))
            {
                ///Add all emails under that group
                return new CompositeEmail();
            }
            else
            {
                return new SingleEmail();
            }
        }

        private static int getEmailCount()
        {
            throw new NotImplementedException();
        }

        private bool isGroup(string emailString)
        {
            throw new NotImplementedException();
        }
    }

    public class SimpleFactory
    {
        public EmailInterface GetEmailInstance(int count)
        {
            if(count > 1)
            {
                return new CompositeEmail();
            }
            else
            {
                return new SingleEmail();
            }
        }
    }
}