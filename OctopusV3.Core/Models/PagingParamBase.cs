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

        public int PerPageSize { get; set; } = 10;

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

        public virtual string GetURL(int pageNum)
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

        public virtual List<int> GetPaging()
        {
            List<int> result = new List<int>();

            if (TotalPageCount > PageSize)
            {
                int st = 1;
                int ed = this.PerPageSize;

                this.lastPage = TotalPageCount / PageSize;
                int tmp = TotalPageCount % PageSize;
                if (tmp > 0)
                {
                    this.lastPage++;
                }

                if (CurPage > PerPageSize)
                {
                    st = Convert.ToInt32(CurPage / this.PerPageSize) * this.PerPageSize + 1;
                    ed = st + (this.PerPageSize - 1);
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
                        tmp = (Convert.ToInt32(tmp / this.PerPageSize) * this.PerPageSize) + 1;
                        tmp = tmp - this.PerPageSize;
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
                        tmp = (Convert.ToInt32(tmp / this.PerPageSize) * this.PerPageSize) + 1;
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
