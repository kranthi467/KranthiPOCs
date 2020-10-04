using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpritesTest.App_Start.Helpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString MyLabel(this HtmlHelper html, string[] classes)
        {
            StringBuilder sb = new StringBuilder();
            //StringBuilder classesBuild = new StringBuilder();
            //for(int idx = 0; idx < classes.Length; idx++)
            //{
            //    classesBuild.Append()
            //}
            sb.AppendFormat("<label class='{0}' id='MyLabelId'>MyLabel</label>", string.Join(" ",classes));
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString ContentBase64(this HtmlHelper html, string path)
        {
            string pathUrl = System.AppDomain.CurrentDomain.BaseDirectory + path;
            var contentType = getFileContentType(path);
            string base64String;

            using (System.Drawing.Image image = System.Drawing.Image.FromFile(pathUrl))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                }
            }
            
            return MvcHtmlString.Create(string.Format($"data:{contentType}; base64,{base64String}"));
        }

        private static string getFileContentType(string path)
        {
            if (path.EndsWith(".JPG", StringComparison.OrdinalIgnoreCase) == true)
            {
                return "image/jpeg";
            }
            else if (path.EndsWith(".GIF", StringComparison.OrdinalIgnoreCase) == true)
            {
                return "image/gif";
            }
            else if (path.EndsWith(".PNG", StringComparison.OrdinalIgnoreCase) == true)
            {
                return "image/png";
            }

            throw new ArgumentException("Unknown file type");
        }
    }
}