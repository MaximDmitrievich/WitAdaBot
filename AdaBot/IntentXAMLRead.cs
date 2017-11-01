using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Microsoft.Bot.Framework.Builder.Witai.Models;

namespace AdaBot
{
    public static class IntentXAMLRead
    {
        public static string Reading(WitResult result, string intent)
        {
            string res = string.Empty;
            XDocument doc = XDocument.Load(System.Web.HttpContext.Current.Request.MapPath("~/Responses.xml"));
            XElement r = (from x in doc.Descendants("Response")
                          where x.Attribute("intent")?.Value == intent
                          select x).FirstOrDefault();
            res = "Я вас не понимаю...";
            if (r != null)
            {
                var arr = (from x in r.Descendants("Text")
                           select x.Value).ToArray();
                if (arr.Length > 0)
                {
                    Random rnd = new Random();
                    res = arr[rnd.Next(0, arr.Length)];
                }
            }
            return res;
        }
    }
}