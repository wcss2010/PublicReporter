using System;
using System.Data;
using System.Text;

namespace ProjectStrategicLeadershipPlugin.DB.Entitys 
{
    /// <summary>
    /// 类ExtFiles。
    /// </summary>
    [Serializable]
    public partial class ExtFiles : Noear.Weed.IEntity
    {
        public ExtFiles() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectID", ProjectID);
            query.set("ExtName", ExtName);
            query.set("ExtType", ExtType);
            query.set("SourceFileName", SourceFileName);
            query.set("RealFileName", RealFileName);
            query.set("IsIgnore", IsIgnore);
            query.set("Tag", Tag);

            return query;
        }

        public string ID { get; set; }
        public string ProjectID { get; set; }
        public string ExtName { get; set; }
        public string ExtType { get; set; }
        public string SourceFileName { get; set; }
        public string RealFileName { get; set; }
        public int IsIgnore { get; set; }
        public string Tag { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            ExtName = source("ExtName").value<string>("");
            ExtType = source("ExtType").value<string>("");
            SourceFileName = source("SourceFileName").value<string>("");
            RealFileName = source("RealFileName").value<string>("");
            IsIgnore = source("IsIgnore").value<int>(0);
            Tag = source("Tag").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new ExtFiles();
        }
    }
}