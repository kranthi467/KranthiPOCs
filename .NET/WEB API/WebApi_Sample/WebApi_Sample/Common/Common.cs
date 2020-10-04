using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_Sample.Common
{
    public class DateRangeAttribute:RangeAttribute
    {
        public DateRangeAttribute(string minimumvalue):base(typeof(DateTime), minimumvalue,DateTime.Now.ToShortDateString())
        {

        }
    }
}