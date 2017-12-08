using AuthorizationSample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AuthorizationSample
{
    public class CredentialChecker
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
        public UserModel CheckCredential(string username, string password)
        {
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from Authorize where name=\'"+username+"\'";
            SqlDataReader reader;
            IList<UserModel> data = new List<UserModel>();

            reader = com.ExecuteReader();
            while (reader.Read())
            {
                UserModel todoObj = new UserModel();
                todoObj.username = (string)reader["name"];
                todoObj.password = (string)reader["password"];
                todoObj.role = (string)reader["role"];
                data.Add(todoObj);
            }
            if (data[0].password == password)
                return data[0];
            else
                return null;
        }
    }
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var tokens = request.Headers.GetValues("Authorization").FirstOrDefault();

                var t = request.Headers;
                if (tokens != null)
                {
                    string[] tokensValues = tokens.Split(':');

                    UserModel ObjUser = new CredentialChecker().CheckCredential(tokensValues[0], tokensValues[1]);
                    if (ObjUser != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(ObjUser.username), ObjUser.role.Split(','));
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                    else
                    {
                        //The user is unauthorize and return 401 status  
                        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
                        tsc.SetResult(response);
                        return tsc.Task;
                    }
                }
                else
                {
                    //Bad Request request because Authentication header is set but value is null  
                    var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(response);
                    return tsc.Task;
                }
                return base.SendAsync(request, cancellationToken);
            }
            catch(Exception ex)
            {
                //User did not set Authentication header  
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
        }

    }
}