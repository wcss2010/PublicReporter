using System;
using System.Data;
using System.Text;

namespace ProjectMilitaryTechnologPlanPlugin.DB.Entitys
{
    /// <summary>
    /// 类DanWeiJingFeiNianDuBiao。
    /// </summary>
    [Serializable]
    public partial class DanWeiJingFeiNianDuBiao : IEntity
    {
        public DanWeiJingFeiNianDuBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("BianHao", BianHao);
            query.set("DanWeiMing", DanWeiMing);
            query.set("NianDu", NianDu);
            query.set("JingFei", JingFei);
            query.set("ZhuangTai", ZhuangTai);
            query.set("ModifyTime", DateTime.Now);

            return query;
        }

        public string BianHao { get; set; }
        public string DanWeiMing { get; set; }
        public int NianDu { get; set; }
        public decimal JingFei { get; set; }
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            DanWeiMing = source("DanWeiMing").value<string>("");
            NianDu = source("NianDu").value<int>(0);
            JingFei = source("JingFei").value<decimal>(0);
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new DanWeiJingFeiNianDuBiao();
        }
    }
}