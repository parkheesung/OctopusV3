using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.DynamicHTML
{
    public class SingleTag : HtmlTag
    {
        public SingleTag() : base()
        {
        }

        public SingleTag(string _name) : base(_name)
        {
        }

        public override string Write()
        {
            if (!string.IsNullOrWhiteSpace(this.TagName))
            {
                StringBuilder builder = new StringBuilder(200);
                builder.Append($"<{TagName}");
                foreach (var item in Attributes)
                {
                    builder.Append($" {item.Key}=\"{item.Value}\" ");
                }
                builder.Append(">");
                builder.Append(Content);
                builder.AppendLine($" />");
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
