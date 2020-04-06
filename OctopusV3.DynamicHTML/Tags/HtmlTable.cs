using OctopusV3.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctopusV3.DynamicHTML
{
    public class HtmlTable : HtmlTag
    {
        protected const int header = 1;
        protected const int body = 2;
        protected const int footer = 3;

        protected bool IsHeader { get; set; } = false;
        protected bool IsFooter { get; set; } = false;
        protected int FootNumber { get; set; } = 0;

        protected bool IsBody { get; set; } = false;

        public ExtendHierarchyTag Header { get; set; } = new ExtendHierarchyTag("thead");
        public ExtendHierarchyTag Body { get; set; } = new ExtendHierarchyTag("tbody");
        public ExtendHierarchyTag Footer { get; set; } = new ExtendHierarchyTag("tfoot");

        protected ConcurrentDictionary<string, string> classList { get; set; } = new ConcurrentDictionary<string, string>();
        protected List<string> tdList { get; set; } = new List<string>();

        protected List<IEntity> bindData { get; set; } = new List<IEntity>();
        protected List<string> setColumns { get; set; } = new List<string>();

        protected string RowClickEventString { get; set; } = string.Empty;

        public HtmlTable() : base("table")
        {
        }

        public virtual void AddClass(string className)
        {
            this.classList.AddOrUpdate(className, className, (oldKey, oldValue) => className);
        }

        public virtual void RemoveClass(string className)
        {
            if (this.classList.ContainsKey(className))
            {
                string temp = string.Empty;
                this.classList.TryRemove(className, out temp);
            }
        }

        public virtual bool ExistsClass(string className)
        {
            return this.classList.ContainsKey(className);
        }

        public virtual void SetHeader(params string[] names)
        {
            Header.ContentTags.Clear();
            int num = 0;
            HierarchyTag temp = new HierarchyTag("tr");
            foreach (string name in names)
            {
                temp.ContentTags.Add(num++, new HtmlTag("th", name));
            }
            Header.ContentTags.Add(1, temp);
            this.IsHeader = true;
        }

        public virtual void SetFooter(int rowNum, int title_size, string title, int value_size, object value)
        {
            HierarchyTag temp = null;
            if (!Footer.ContentTags.TryGetValue(rowNum, out temp))
            {
                temp = new HierarchyTag("tr");
            }
            var titleTag = new HtmlTag("th", title);
            titleTag.AttributeSet("colspan", title_size.ToString());
            var contentTag = new HtmlTag("td", value.ToString());
            contentTag.AttributeSet("colspan", value_size.ToString());
            temp.ContentTags.Add(this.FootNumber++, titleTag);
            temp.ContentTags.Add(this.FootNumber++, contentTag);
            this.IsFooter = true;
        }

        public virtual void SetRowEventScript(string scriptName, params string[] columns)
        {
            StringBuilder builder = new StringBuilder(200);
            builder.Append($"{scriptName}(");
            int num = 0;
            foreach(string column in columns)
            {
                if (num > 0) builder.Append(",");
                builder.Append("'{");
                builder.Append(column);
                builder.Append("}'");
                num++;
            }
            builder.Append(");");
            this.RowClickEventString = builder.ToString();
        }

        public virtual void SetBody<T>(List<T> data, params string[] columns) where T : IEntity
        {
            Body.ContentTags.Clear();

            if (data != null && data.Count > 0)
            {
                this.bindData = data as List<IEntity>;
                this.setColumns = columns.ToList();
                int colNum = 0;
                int rowNum = 0;
                HierarchyTag row = null;
                HtmlTag col = null;
                StringBuilder builder = new StringBuilder(200);

                foreach (T obj in data)
                {
                    builder.Clear();
                    colNum = 0;
                    row = new HierarchyTag("tr");
                    if (!string.IsNullOrWhiteSpace(this.RowClickEventString)) builder.Append(this.RowClickEventString);
                    foreach (string column in columns)
                    {
                        if (!string.IsNullOrWhiteSpace(this.RowClickEventString)) builder.Replace("{" + column + "}", Convert.ToString(obj.GetValue(column)));
                        col = new HtmlTag("td", Convert.ToString(obj.GetValue(column)));
                        row.ContentTags.Add(colNum++, col);
                    }

                    if (tdList != null && tdList.Count > 0)
                    {
                        StringBuilder tdContent = null;

                        foreach (string td in tdList)
                        {
                            tdContent = new StringBuilder(td);
                            foreach (string column in columns)
                            {
                                tdContent.Replace("{" + column + "}", Convert.ToString(obj.GetValue(column)));
                            }
                            col = new HtmlTag("td", tdContent.ToString());
                            row.ContentTags.Add(colNum++, col);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(this.RowClickEventString)) row.RootTag.AttributeSet("onclick", builder.ToString());
                    Body.ContentTags.Add(rowNum++, row);
                }

                this.IsBody = true;
            }
        }

        public virtual void AppendTd(string content)
        {
            if (this.IsBody)
            {
                HtmlTag temp = null;
                StringBuilder builder = null;
                string column = string.Empty;
                IEntity entity = null;
                foreach (var row in Body.ContentTags)
                {
                    builder = new StringBuilder(content);
                    column = this.setColumns[row.Key];
                    entity = this.bindData[row.Key];
                    builder.Replace("{" + column + "}", entity.GetValue(column).ToString());
                    temp = new HtmlTag("td", builder.ToString());
                    row.Value.ContentTags.Add(row.Value.ContentTags.Max(x => x.Key) + 1, temp);
                }
            }
            else
            {
                tdList.Add(content);
            }
        }

        public override string Write()
        {
            StringBuilder classAttr = new StringBuilder(200);
            int num = 0;
            foreach(string className in this.classList.Values)
            {
                if (num > 0) classAttr.Append(" ");
                classAttr.Append(className);
                num++;
            }
            this.AttributeSet("class", classAttr.ToString());
            
            StringBuilder builder = new StringBuilder(200);
            if (this.IsHeader) builder.AppendLine(this.Header.Write());
            builder.AppendLine(this.Body.Write());
            if (this.IsFooter) builder.AppendLine(this.Footer.Write());
            this.Content = builder.ToString();
            return base.Write();
        }
    }
}
