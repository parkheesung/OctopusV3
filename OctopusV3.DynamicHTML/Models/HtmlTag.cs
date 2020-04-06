using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.DynamicHTML
{
    public class HtmlTag : ITagObject
    {
        public string TagName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public ConcurrentDictionary<string, string> Attributes { get; set; } = new ConcurrentDictionary<string, string>();

        public HtmlTag()
        {
        }

        public HtmlTag(string _name)
        {
            this.TagName = _name;
        }

        public HtmlTag(string _name, string _content)
        {
            this.TagName = _name;
            this.Content = _content;
        }

        public void AttributeSet(string key, string value)
        {
            this.Attributes.AddOrUpdate(key, value, (oldKey, oldValue) => value);
        }

        public virtual string Write()
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
                builder.AppendLine($"</{TagName}>");
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
