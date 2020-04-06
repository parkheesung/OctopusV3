using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.DynamicHTML
{
    public class HtmlLayout : HtmlPage
    {
        public string SectionKey { get; set; } = "{body}";
        public string LayoutTag { get; set; } = string.Empty;

        public HtmlLayout() : base()
        {
        }

        public override string Write()
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
            builder.AppendLine(this.LayoutTag.Replace(this.SectionKey, Body.Write()));
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
