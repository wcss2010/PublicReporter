using System;
using System.Data;
using System.Text;

namespace ProjectReporterPlugin.DB.Entitys
{
    /// <summary>
    /// 类ProjectAndStep。
    /// </summary>
    [Serializable]
    public partial class ProjectAndStep : IEntity
    {
        public ProjectAndStep() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //更新保存时间
            updateSaveDate();

            //设置值
            query.set("ID", ID);
            query.set("StepID", StepID);
            query.set("StepContent", StepContent);
            query.set("StepDest", StepDest);
            query.set("StepTarget", StepTarget);
            query.set("StepResult", StepResult);
            query.set("Money", Money);

            return query;
        }

        public string ID { get; set; }
        public string StepID { get; set; }
        public string StepContent { get; set; }
        public string StepDest { get; set; }
        public string StepTarget { get; set; }
        public string StepResult { get; set; }
        public decimal? Money { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            StepID = source("StepID").value<string>("");
            StepContent = source("StepContent").value<string>("");
            StepDest = source("StepDest").value<string>("");
            StepTarget = source("StepTarget").value<string>("");
            StepResult = source("StepResult").value<string>("");
            Money = source("Money").value<decimal>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new ProjectAndStep();
        }
    }
}