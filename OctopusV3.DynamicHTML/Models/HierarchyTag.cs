using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.DynamicHTML
{
    public class HierarchyTag : ITagObject
    {
        public HtmlTag RootTag { get; set; } = new HtmlTag();
        public Dictionary<int, HtmlTag> ContentTags { get; set; } = new Dictionary<int, HtmlTag>();

        public ConcurrentDictionary<string, string> Attributes { get; set; } = new ConcurrentDictionary<string, string>();

        public HierarchyTag()
        {
        }

        public HierarchyTag(string _name)
        {
            this.RootTag = new HtmlTag(_name);
        }

        public void AttributeSet(string key, string value)
        {
            this.Attributes.AddOrUpdate(key, value, (oldKey, oldValue) => value);
        }


        public virtual string Write()
        {
            if (!string.IsNullOrWhiteSpace(RootTag.TagName))
            {
                StringBuilder builder = new StringBuilder(200);
                builder.Append($"<{RootTag.TagName}");
                foreach (var item in RootTag.Attributes)
                {
                    builder.Append($" {item.Key}=\"{item.Value}\" ");
                }
                builder.AppendLine(">");
                foreach (var content in ContentTags)
                {
                    builder.AppendLine(content.Value.Write());
                }
                builder.AppendLine($"</{RootTag.TagName}>");
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
