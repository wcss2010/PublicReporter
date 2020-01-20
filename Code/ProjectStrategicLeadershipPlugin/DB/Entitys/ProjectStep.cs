using System;
using System.Data;
using System.Text;

namespace ProjectStrategicLeadershipPlugin.DB.Entitys 
{
    /// <summary>
    /// 类ProjectStep。
    /// </summary>
    [Serializable]
    public partial class ProjectStep : IEntity
    {
        public ProjectStep() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ProjectID", ProjectID);
            query.set("StepTime", StepTime);
            query.set("StepTag1", StepTag1);
            query.set("StepTag2", StepTag2);
            query.set("StepTag3", StepTag3);
            query.set("StepTag4", StepTag4);
            query.set("StepMoney", StepMoney);
            query.set("StepIndex", StepIndex);

            return query;
        }

        public string ProjectID { get; set; }
        public int32 StepTime { get; set; }
        public string StepTag1 { get; set; }
        public string StepTag2 { get; set; }
        public string StepTag3 { get; set; }
        public string StepTag4 { get; set; }
        public single StepMoney { get; set; }
        public int32 StepIndex { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ProjectID = source("ProjectID").value<string>("");
            StepTime = source("StepTime").value<int32>("");
            StepTag1 = source("StepTag1").value<string>("");
            StepTag2 = source("StepTag2").value<string>("");
            StepTag3 = source("StepTag3").value<string>("");
            StepTag4 = source("StepTag4").value<string>("");
            StepMoney = source("StepMoney").value<single>("");
            StepIndex = source("StepIndex").value<int32>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new ProjectStep();
        }
    }
}
