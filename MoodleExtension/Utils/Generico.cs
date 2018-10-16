using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleExtension
{
    public static class Generico
    {
        public enum Highlighter
        {
            cs,
            html,
            css,
            javascript,
            json,
            python,
            sql,
            xml
        }
        public static string WrapCode(Highlighter highlighter, string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{GENERICO:type=\"codebox\",language=\"" + highlighter + "\"}" + code);
            //sb.Append(highlighter);
            //sb.Append("\"}");
            //sb.AppendJoin(code);
            sb.Append("{GENERICO:type=\"codebox_end\"}");
            return sb.ToString();
        }
    }
}
