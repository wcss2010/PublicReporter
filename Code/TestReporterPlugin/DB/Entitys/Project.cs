using System;
using System.Data;
using System.Text;

namespace TestReporterPlugin.DB.Entitys
{
    /// <summary>
    /// 类Project。
    /// </summary>
    [Serializable]
    public partial class Project : IEntity
    {
        public Project() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("Name", Name);
            query.set("SecretLevel", SecretLevel);
            query.set("Type", Type);
            query.set("Type2", Type2);
            query.set("ParentID", ParentID);
            query.set("UnitID", UnitID);
            query.set("TotalTime", TotalTime);
            query.set("TotalMoney", TotalMoney);
            query.set("Keywords", Keywords);
            query.set("Domain", Domain);
            query.set("Direction", Direction);
            query.set("DirectionCode", DirectionCode);

            return query;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string SecretLevel { get; set; }
        public string Type { get; set; }
        public string Type2 { get; set; }
        public string ParentID { get; set; }
        public string UnitID { get; set; }
        public int? TotalTime { get; set; }
        public decimal? TotalMoney { get; set; }
        public string Keywords { get; set; }
        public string Domain { get; set; }
        public string Direction { get; set; }
        public int? DirectionCode { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            Name = source("Name").value<string>("");
            SecretLevel = source("SecretLevel").value<string>("");
            Type = source("Type").value<string>("");
            Type2 = source("Type2").value<string>("");
            ParentID = source("ParentID").value<string>("");
            UnitID = source("UnitID").value<string>("");
            TotalTime = source("TotalTime").value<int>(0);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            Keywords = source("Keywords").value<string>("");
            Domain = source("Domain").value<string>("");
            Direction = source("Direction").value<string>("");
            DirectionCode = source("DirectionCode").value<int>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Project();
        }
    }
}