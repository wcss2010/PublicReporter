using System;
using System.Data;
using System.Text;

namespace ProjectMilitaryTechnologPlanPlugin.DB.Entitys 
{
    /// <summary>
    /// 类YuSuanBiao。
    /// </summary>
    [Serializable]
    public partial class YuSuanBiao : IEntity
    {
        public YuSuanBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("BianHao", BianHao);
            query.set("MingCheng", MingCheng);
            query.set("ShuJu", ShuJu);
            query.set("ZhuangTai", ZhuangTai);
            query.set("ModifyTime", ModifyTime);

            return query;
        }

        public string BianHao { get; set; }
        public string MingCheng { get; set; }
        public string ShuJu { get; set; }
        public decimal ZhuangTai { get; set; }
        public DateTime ModifyTime { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            MingCheng = source("MingCheng").value<string>("");
            ShuJu = source("ShuJu").value<string>("");
            ZhuangTai = source("ZhuangTai").value<decimal>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new YuSuanBiao();
        }
    }
}