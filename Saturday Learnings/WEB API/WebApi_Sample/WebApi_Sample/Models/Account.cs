using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApi_Sample.Common;

namespace WebApi_Sample.Models
{
    public class Account
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("(^.{4,8}$)")]
        //Matches any string between 4 and 8 characters in length
        //Limits the length of a string
        public string Password { get; set; }

        [Required]
        [Range(18, 50)]
        public int Age { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Url]
        public string Website { get; set; }




        //1.{"username":"abc","password":"1234","age":40,"email":"a@gmail.com","website":"http://google.com"}//success
        //2.{"username":"PQR","password":"1234","age":20,"email":"a@gmail.com","website":"http://google.com","Date":"11/18/2010"}//Error Message
        //3.{"username":"PQR","password":"1234","age":20,"email":"a@gmail.com","website":"http://google.com","Date":"11/18/2009"}//Success
        //4. {"username":"PQR","password":"1234","age":20,"email":"a@gmail.com","website":"http://google.com","Date":"11/18/2017"}//Success after custom validation
        //5. {"username":"PQR","password":"1234","age":20,"email":"a@gmail.com","website":"http://google.com","Date":"11/19/2017"}//Error Message.


        [Required]
        //[Range(typeof(DateTime),"01/01/2000","01/01/2010")]
       // [Range(typeof(DateTime), "01/01/2000",DateTime.Now.ToShortDateString())]
        //custom Validation
        //We can give hire date upto current date.
       [CurrentDateAttribute()]
        public DateTime Date { get; set; }

        
    }
}