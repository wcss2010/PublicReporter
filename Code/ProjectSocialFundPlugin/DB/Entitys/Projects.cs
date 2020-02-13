using Noear.Weed;
using System;
using System.Data;
using System.Text;

namespace ProjectStrategicLeadershipPlugin.DB.Entitys 
{
    /// <summary>
    /// 类Projects。
    /// </summary>
    [Serializable]
    public partial class Projects : IEntity
    {
        public Projects() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectName", ProjectName);
            query.set("ProjectTopic", ProjectTopic);
            query.set("ProjectDirection", ProjectDirection);
            query.set("ProjectSecretLevel", ProjectSecretLevel);
            query.set("ProjectMasterName", ProjectMasterName);
            query.set("UnitName", UnitName);
            query.set("UnitRealName", UnitRealName);
            query.set("UnitAddress", UnitAddress);
            query.set("UnitType2", UnitType2);
            query.set("UnitContact", UnitContact);
            query.set("UnitContactJob", UnitContactJob);
            query.set("UnitContactPhone", UnitContactPhone);
            query.set("TotalTime", TotalTime);
            query.set("TotalMoney", TotalMoney);
            query.set("RequestTime", RequestTime);

            return query;
        }

        public string ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectTopic { get; set; }
        public string ProjectDirection { get; set; }
        public string ProjectSecretLevel { get; set; }
        public string ProjectMasterName { get; set; }
        public string UnitName { get; set; }
        public string UnitRealName { get; set; }
        public string UnitAddress { get; set; }
        public string UnitType2 { get; set; }
        public string UnitContact { get; set; }
        public string UnitContactJob { get; set; }
        public string UnitContactPhone { get; set; }
        public int TotalTime { get; set; }
        public decimal TotalMoney { get; set; }
        public DateTime RequestTime { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>("");
            ProjectName = source("ProjectName").value<string>("");
            ProjectTopic = source("ProjectTopic").value<string>("");
            ProjectDirection = source("ProjectDirection").value<string>("");
            ProjectSecretLevel = source("ProjectSecretLevel").value<string>("");
            ProjectMasterName = source("ProjectMasterName").value<string>("");
            UnitName = source("UnitName").value<string>("");
            UnitRealName = source("UnitRealName").value<string>("");
            UnitAddress = source("UnitAddress").value<string>("");
            UnitType2 = source("UnitType2").value<string>("");
            UnitContact = source("UnitContact").value<string>("");
            UnitContactJob = source("UnitContactJob").value<string>("");
            UnitContactPhone = source("UnitContactPhone").value<string>("");
            TotalTime = source("TotalTime").value<int>(0);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            RequestTime = source("RequestTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Projects();
        }
    }
}