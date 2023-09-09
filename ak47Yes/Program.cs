using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace ak47Yes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Run(async (context) =>
            {
                // Site open

                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/login");
                }

                if(context.Request.Path == "/login")
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.SendFileAsync("html/login/index.html");
                }

                else if (context.Request.Path == "/html/login/style.css")
                {
                    await context.Response.SendFileAsync("html/login/style.css");
                }

                else if (context.Request.Path == "/html/login/167.jpg")
                {
                    await context.Response.SendFileAsync("html/login/167.jpg");
                }

                // Forms action

                else if (context.Request.Path == "/loginAction")
                {
                    var form = context.Request.Form;

                    string mail = form["mail"];
                    string password = form["password"];

                    await context.Response.WriteAsync($"<div><p>Name: {mail}</p><p>Age: {password}</p></div>");
                }
            });

            app.Run();

            
        }
        public record User(string Mail, string Password);
    }
}