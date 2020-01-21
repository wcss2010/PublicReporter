using System;
using System.Data;
using System.Text;

namespace ProjectStrategicLeadershipPlugin.DB.Entitys 
{
    /// <summary>
    /// 类Steps。
    /// </summary>
    [Serializable]
    public partial class Steps : Noear.Weed.IEntity
    {
        public Steps() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectID", ProjectID);
            query.set("SubjectID", SubjectID);
            query.set("StepTime", StepTime);
            query.set("StepTag1", StepTag1);
            query.set("StepTag2", StepTag2);
            query.set("StepTag3", StepTag3);
            query.set("StepTag4", StepTag4);
            query.set("StepMoney", StepMoney);
            query.set("StepIndex", StepIndex);

            return query;
        }

        public string ID { get; set; }
        public string ProjectID { get; set; }
        public string SubjectID { get; set; }
        public int StepTime { get; set; }
        public string StepTag1 { get; set; }
        public string StepTag2 { get; set; }
        public string StepTag3 { get; set; }
        public string StepTag4 { get; set; }
        public decimal StepMoney { get; set; }
        public int StepIndex { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            SubjectID = source("SubjectID").value<string>("");
            StepTime = source("StepTime").value<int>(0);
            StepTag1 = source("StepTag1").value<string>("");
            StepTag2 = source("StepTag2").value<string>("");
            StepTag3 = source("StepTag3").value<string>("");
            StepTag4 = source("StepTag4").value<string>("");
            StepMoney = source("StepMoney").value<decimal>(0);
            StepIndex = source("StepIndex").value<int>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Steps();
        }
    }
}