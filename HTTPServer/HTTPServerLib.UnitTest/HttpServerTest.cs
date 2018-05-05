﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HTTPServerLib.UnitTest
{
    [TestClass]
    public class HttpServerTest
    {
        [TestMethod]
        public void TestGet()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:4050/");
            var response = request.GetResponse();
            Assert.AreEqual("text/html; charset=UTF-8", response.Headers["Content-Type"]);
            Assert.AreEqual("ExampleServer", response.Headers["Server"]);
        }

        [TestMethod]
        public void TestPost()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:4050/");
            request.Method = "POST";
            var requestStream = request.GetRequestStream();
            var data = Encoding.UTF8.GetBytes("a=10&b=15");
            requestStream.Write(data,0,data.Length);
            var response = request.GetResponse();
            Assert.AreEqual("text/html; charset=UTF-8", response.Headers["Content-Type"]);
            Assert.AreEqual("ExampleServer", response.Headers["Server"]);
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var content = reader.ReadToEnd();
                Assert.AreEqual("the data from post:a=10;b=15", content);
            }
        }
    }
}
