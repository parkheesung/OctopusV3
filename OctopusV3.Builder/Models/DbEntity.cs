namespace OctopusV3.Builder
{
    public class DbEntity
    {
        public int database_id { get; set; } = -1;
        public string name { get; set; } = string.Empty;


        public DbEntity()
        {
        }
    }

    public class ObjectEntity
    {
        public string ObjectType { get; set; } = string.Empty;

        public int object_id { get; set; } = -1;
        public string name { get; set; } = string.Empty;

        public ObjectEntity()
        {
        }
    }

    public class SPEntity
    {
        public string name { get; set; } = string.Empty;

        public int depid { get; set; } = -1;

        public string TableName { get; set; } = string.Empty;


        public string methodName
        {
            get
            {
                string result = string.Empty;
                if (!string.IsNullOrWhiteSpace(this.name))
                {
                    if (this.name.Length > 4 && this.name.Substring(3, 1) == "_")
                    {
                        result = this.name.Substring(4, this.name.Length - 4);
                    }
                    else
                    {
                        result = this.name;
                    }
                }
                return result.Replace("_","");
            }
        }

        public SPEntity()
        {
        }
    }
}
