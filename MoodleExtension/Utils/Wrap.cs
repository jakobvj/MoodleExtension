using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleExtension
{
    public enum Tag
    {
        code,
        pre
    }
    public static class Wrap
    {
        public static string WrapCode(Tag tag, string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<");
            sb.Append(tag);
            sb.Append(">");
            sb.Append(code);
            sb.Append("</");
            sb.Append(tag);
            sb.Append(">");
            return sb.ToString();
        }
    }
}
