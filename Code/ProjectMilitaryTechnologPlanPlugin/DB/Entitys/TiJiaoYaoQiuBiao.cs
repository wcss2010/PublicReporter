using System;
using System.Data;
using System.Text;

namespace ProjectMilitaryTechnologPlanPlugin.DB.Entitys 
{
    /// <summary>
    /// 类TiJiaoYaoQiuBiao。
    /// </summary>
    [Serializable]
    public partial class TiJiaoYaoQiuBiao : IEntity
    {
        public TiJiaoYaoQiuBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            query.set("ModifyTime", DateTime.Now);
            //设置值
            query.set("BianHao", BianHao);
            query.set("MingCheng", MingCheng);
            query.set("YaoQiu", YaoQiu);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public string MingCheng { get; set; }
        public string YaoQiu { get; set; }
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            MingCheng = source("MingCheng").value<string>("");
            YaoQiu = source("YaoQiu").value<string>("");
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new TiJiaoYaoQiuBiao();
        }
    }
}
