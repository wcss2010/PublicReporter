using System;
using System.Data;
using System.Text;

namespace TestReporterPlugin.DB.Entitys
{
    /// <summary>
    /// 类Step。
    /// </summary>
    [Serializable]
    public partial class Step : IEntity
    {
        public Step() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectID", ProjectID);
            query.set("StepTime", StepTime);
            query.set("StepContent", StepContent);
            query.set("StepDest", StepDest);
            query.set("StepTarget", StepTarget);
            query.set("StepResult", StepResult);
            query.set("StepMoney", StepMoney);
            query.set("StepIndex", StepIndex);

            return query;
        }

        public string ID { get; set; }
        public string ProjectID { get; set; }
        public int? StepTime { get; set; }
        public string StepContent { get; set; }
        public string StepDest { get; set; }
        public string StepTarget { get; set; }
        public string StepResult { get; set; }
        public decimal? StepMoney { get; set; }
        public int? StepIndex { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            ProjectID = source("ProjectID").value<string>("");
            StepTime = source("StepTime").value<int>(0);
            StepContent = source("StepContent").value<string>("");
            StepDest = source("StepDest").value<string>("");
            StepTarget = source("StepTarget").value<string>("");
            StepResult = source("StepResult").value<string>("");
            StepMoney = source("StepMoney").value<decimal>(0);
            StepIndex = source("StepIndex").value<int>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Step();
        }
    }
}