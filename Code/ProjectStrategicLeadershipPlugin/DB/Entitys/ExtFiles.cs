using System;
using System.Data;
using System.Text;

namespace ProjectStrategicLeadershipPlugin.DB.Entitys 
{
    /// <summary>
    /// 类ExtFiles。
    /// </summary>
    [Serializable]
    public partial class ExtFiles : IEntity
    {
        public ExtFiles() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ProjectID", ProjectID);
            query.set("ExtName", ExtName);
            query.set("ExtType", ExtType);
            query.set("SourceFileName", SourceFileName);
            query.set("RealFileName", RealFileName);
            query.set("IsIgnore", IsIgnore);
            query.set("Tag", Tag);

            return query;
        }

        public string ProjectID { get; set; }
        public string ExtName { get; set; }
        public string ExtType { get; set; }
        public string SourceFileName { get; set; }
        public string RealFileName { get; set; }
        public int32 IsIgnore { get; set; }
        public string Tag { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ProjectID = source("ProjectID").value<string>("");
            ExtName = source("ExtName").value<string>("");
            ExtType = source("ExtType").value<string>("");
            SourceFileName = source("SourceFileName").value<string>("");
            RealFileName = source("RealFileName").value<string>("");
            IsIgnore = source("IsIgnore").value<int32>("");
            Tag = source("Tag").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new ExtFiles();
        }
    }
}
