using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPServerLib;
using System.IO;

namespace HttpServer
{
    public class ExampleServer : HTTPServerLib.HttpServer
    {
        public ExampleServer(string ipAddress, int port)
            : base(ipAddress, port)
        {

        }

        public override void OnPost(HttpRequest request, HttpResponse response)
        {
            string data = request.Params == null ? "" : string.Join(";", request.Params.Select(x => x.Key + "=" + x.Value).ToArray());

            string content = string.Format("the data from post:{0}", data);

            response.SetContent(content);
            response.Content_Encoding = "utf-8";
            response.StatusCode = "200";
            response.Content_Type = "text/html; charset=UTF-8";
            response.Headers["Server"] = "ExampleServer";

            response.Send();
        }

        public override void OnGet(HttpRequest request, HttpResponse response)
        {

            response = response.FromFile("defaultfile");
            response.Content_Type = "text/html; charset=UTF-8";

            response.Send();
        }

        public override void OnDefault(HttpRequest request, HttpResponse response)
        {

        }

        private string ConvertPath(string[] urls)
        {
            string html = string.Empty;
            int length = ServerRoot.Length;
            foreach (var url in urls)
            {
                var s = url.StartsWith("..") ? url : url.Substring(length).TrimEnd('\\');
                html += String.Format("<li><a href=\"{0}\">{0}</a></li>", s);
            }

            return html;
        }

    }
}
