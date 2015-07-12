using System;
using System.IO;
using System.Net;

namespace AdministradorGeneral.Parsers
{
    public class Parser
    {
        public static string GetSourceCode(string url)
        {
            string content;
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var r = new StreamReader(response.GetResponseStream());
            content = r.ReadToEnd();
            r.Close();
            return content;
        }

        public static string GetContent(string text, string tagStart, string tagEnd)
        {
            string content;

            content = text.Substring(text.IndexOf(tagStart) + tagStart.Length);
            if (!tagStart.EndsWith(">"))
            {
                content = content.Substring(content.IndexOf(">")+1);
            }
            content = content.Remove(content.IndexOf(tagEnd));
            return content.Trim();
        }

        public static string GetContentAndCut(ref string text, string tagStart, string tagEnd)
        {
            string content;
            content = text.Substring(text.IndexOf(tagStart) + tagStart.Length);
            text = text.Substring(text.IndexOf(tagStart) + tagStart.Length);
            if (!tagStart.EndsWith(">"))
            {
                content = content.Substring(content.IndexOf(">") + 1);
                text = text.Substring(text.IndexOf(">") + 1);
            }
            content = content.Remove(content.IndexOf(tagEnd));
            text = text.Substring(content.IndexOf(tagEnd) + 1);
            return content.Trim();
        }

        public static Tag GetTag(string text)
        {
            if (!text.Contains("<"))
                return null;
            text = text.Substring(text.IndexOf("<")+1);
            Tag t = new Tag();
            var tagName = text.Substring(0, text.IndexOf(">"));
            if (tagName.Contains(" "))
            {
                t.Contenido = tagName.Substring(tagName.IndexOf(" ") + 1);
                tagName = tagName.Remove(tagName.IndexOf(" "));
            }

            t.Nombre = tagName;

            return t;
        }
    }
}
