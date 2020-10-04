using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Net;

namespace ToDoApplication.Models
{
    public class Todo
    {
        public Todo()
        {
            IP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }
        public int ID { get; set; }
        public string Description { get; set; }

        [Display(Name =  "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public string IP { get; set; }
    }
}