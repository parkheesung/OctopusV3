using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.Core
{
    public static class ExtendStringHelper
    {
        public static void AppendTab(this StringBuilder builder, int tabCount, string content)
        {
            for(int i = 0; i < tabCount; i++)
            {
                builder.Append("\t");
            }
            builder.Append(content);
        }

        public static void AppendTabLine(this StringBuilder builder, int tabCount, string content)
        {
            for (int i = 0; i < tabCount; i++)
            {
                builder.Append("\t");
            }
            builder.AppendLine(content);
        }
    }
}
