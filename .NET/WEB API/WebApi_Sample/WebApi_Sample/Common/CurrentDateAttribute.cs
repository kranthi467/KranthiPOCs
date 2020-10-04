using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Sample.Common
{
    public class CurrentDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime = Convert.ToDateTime(value);
            return datetime <= DateTime.Now;
        }
    }
}