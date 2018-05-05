using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServerLib
{
    public interface IServer
    {
        void OnGet(HttpRequest request, HttpResponse response);


        void OnPost(HttpRequest request, HttpResponse response);


        void OnDefault(HttpRequest request, HttpResponse response);
    }
}
