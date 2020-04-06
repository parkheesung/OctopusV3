using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.DynamicHTML
{
    public class HtmlPage : ITagObject
    {
        public string Title { get; set; } = string.Empty;
        public ConcurrentDictionary<string, SingleTag> Metas { get; set; } = new ConcurrentDictionary<string, SingleTag>();
        public ConcurrentDictionary<string, SingleTag> Links { get; set; } = new ConcurrentDictionary<string, SingleTag>();
        public ConcurrentDictionary<string, HtmlTag> Scripts { get; set; } = new ConcurrentDictionary<string, HtmlTag>();

        public HtmlTag Body { get; set; } = new HtmlTag("body");
        public HtmlTag Footer { get; set; } = new HtmlTag();
        public HtmlTag Scirpt { get; set; } = new HtmlTag("script");

        public string Language { get; set; } = "ko";

        public HtmlPage()
        {
        }

        public void MetaAdd(string key, SingleTag content)
        {
            this.Metas.AddOrUpdate(key, content, (oldkey, oldContent) => content);
        }

        public void LinkAdd(string href)
        {
            var target = new SingleTag("link");
            target.AttributeSet("type", "text/css");
            target.AttributeSet("rel", "stylesheet");
            target.AttributeSet("href", href);

            this.Links.AddOrUpdate(href, target, (oldkey, oldContent) => target);
        }

        public void ScriptAdd(string src)
        {
            var target = new SingleTag("script");
            target.AttributeSet("type", "text/javascript");
            target.AttributeSet("src", src);

            this.Links.AddOrUpdate(src, target, (oldkey, oldContent) => target);
        }


        public virtual string Write()
        {
            StringBuilder builder = new StringBuilder(1000);
            builder.AppendLine("<!DOCTYPE html>");
            builder.AppendLine($"<html lang=\"{this.Language}\">");
            builder.AppendLine($"<head>");
            foreach (var meta in this.Metas)
            {
                builder.AppendLine(meta.Value.Write());
            }
            foreach (var link in this.Links)
            {
                builder.AppendLine(link.Value.Write());
            }
            builder.AppendLine($"<title>{this.Title}</title>");
            builder.AppendLine($"</head>");
            builder.AppendLine(Body.Write());
            builder.AppendLine(Footer.Write());
            foreach (var script in this.Scripts)
            {
                builder.AppendLine(script.Value.Write());
            }
            builder.AppendLine(Scirpt.Write());
            builder.AppendLine($"</html>");
            return builder.ToString();
        }
    }
}
