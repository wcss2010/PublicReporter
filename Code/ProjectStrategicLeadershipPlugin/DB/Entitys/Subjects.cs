using System;
using System.Data;
using System.Text;

namespace ProjectStrategicLeadershipPlugin.DB.Entitys 
{
    /// <summary>
    /// 类Subjects。
    /// </summary>
    [Serializable]
    public partial class Subjects : Noear.Weed.IEntity
    {
        public Subjects() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("SubjectName", SubjectName);
            query.set("SecretLevel", SecretLevel);
            query.set("TotalTime", TotalTime);
            query.set("TotalMoney", TotalMoney);
            query.set("UnitName", UnitName);
            query.set("UnitAddress", UnitAddress);
            query.set("UnitContact", UnitContact);
            query.set("UnitContactPhone", UnitContactPhone);

            return query;
        }

        public string ID { get; set; }
        public string SubjectName { get; set; }
        public string SecretLevel { get; set; }
        public int TotalTime { get; set; }
        public decimal TotalMoney { get; set; }
        public string UnitName { get; set; }
        public string UnitAddress { get; set; }
        public string UnitContact { get; set; }
        public string UnitContactPhone { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>("");
            SubjectName = source("SubjectName").value<string>("");
            SecretLevel = source("SecretLevel").value<string>("");
            TotalTime = source("TotalTime").value<int>(0);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            UnitName = source("UnitName").value<string>("");
            UnitAddress = source("UnitAddress").value<string>("");
            UnitContact = source("UnitContact").value<string>("");
            UnitContactPhone = source("UnitContactPhone").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Subjects();
        }
    }
}