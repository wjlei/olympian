﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServerLib
{
    public class BaseHeader
    {
        public string Body { get; set; }

        public Encoding Encoding { get; set; }

        public string Content_Type { get; set; }

        public string Content_Length { get; set; }

        public string Content_Encoding { get; set; }

        public string ContentLanguage { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        protected string GetHeader(Enum header)
        {
            var fieldName = header.GetDescription();
            if (fieldName == null) return null;
            var hasKey = Headers.ContainsKey(fieldName);
            if (!hasKey) return null;
            return Headers[fieldName];
        }

        protected void SetHeader(Enum header, string value)
        {
            var fieldName = header.GetDescription();
            if (fieldName == null) return;
            var hasKey = Headers.ContainsKey(fieldName);
            if (!hasKey) Headers.Add(fieldName, value);
            Headers[fieldName] = value;
        }
    }
}
