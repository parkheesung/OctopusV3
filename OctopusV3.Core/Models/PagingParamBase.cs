using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.Core
{
    public class PagingParamBase : QueryParamBase, IDynamicQuery
    {
        public int CurPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string OrderBy { get; set; } = string.Empty;

        public string URL { get; set; } = string.Empty;

        protected int lastPage { get; set; } = 1;

        public int LastPage
        {
            get
            {
                return this.lastPage;
            }
        }

        public PagingParamBase() : base()
        {
        }

        public int TotalPageCount { get; set; } = 0;

        public int SequenceNumber
        {
            get
            {
                return (TotalPageCount - ((CurPage - 1) * PageSize));
            }
        }

        public string GetURL(int pageNum)
        {
            StringBuilder builder = new StringBuilder(100);
            if (!string.IsNullOrWhiteSpace(this.URL))
            {
                builder.Append(URL);
                if (this.URL.IndexOf("?") > -1)
                {
                    builder.Append("&");
                }
                else
                {
                    builder.Append("?");
                }
                builder.Append($"CurPage={pageNum}");
            }
            return builder.ToString();
        }

        public List<int> GetPaging()
        {
            List<int> result = new List<int>();

            if (TotalPageCount > PageSize)
            {
                int st = 1;
                int ed = 10;

                this.lastPage = TotalPageCount / PageSize;
                int tmp = TotalPageCount % PageSize;
                if (tmp > 0)
                {
                    this.lastPage++;
                }

                if (CurPage > PageSize)
                {
                    st = (Convert.ToInt32(CurPage / 10) * 10) + 1;
                    ed = st + 9;
                }

                for(int i = st; i <= ed; i++)
                {
                    if (i > this.lastPage) break;
                    result.Add(i);
                }
            }
            
            if (result.Count == 0)
            {
                result.Add(1);
            }

            return result;
        }


        public int PreviousPage
        {
            get
            {
                if (TotalPageCount > 0)
                {
                    int tmp = this.GetPaging()[0];
                    if (tmp > this.PageSize)
                    {
                        tmp = (Convert.ToInt32(tmp / 10) * 10) + 1;
                        tmp = tmp - 10;
                    }
                    else
                    {
                        tmp = 1;
                    }
                    return tmp;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int NextPage
        {
            get
            {
                if (TotalPageCount > 0)
                {
                    int tmp = this.GetPaging()[this.GetPaging().Count - 1];
                    if (tmp < this.LastPage)
                    {
                        tmp = (Convert.ToInt32(tmp / 10) * 10) + 1;
                        if (tmp > this.LastPage)
                        {
                            tmp = this.LastPage;
                        }
                    }
                    else
                    {
                        tmp = this.LastPage;
                    }
                    return tmp;
                }
                else
                {
                    return this.LastPage;
                }
            }
        }

        public virtual string Serialize()
        {
            return $"CurPage={this.CurPage}";
        }

        public virtual string inPagingParams()
        {
            return $"";
        }
    }
}
