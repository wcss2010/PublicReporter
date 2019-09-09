using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
{
    /// <summary>
    /// 类RenYuanBiao。
    /// </summary>
    [Serializable]
    public partial class RenYuanBiao : IEntity
    {
        public RenYuanBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            query.set("ModifyTime", DateTime.Now);
            //设置值
            query.set("BianHao", BianHao);
            query.set("XingMing", XingMing);
            query.set("XingBie", XingBie);
            query.set("ZhiCheng", ZhiCheng);
            query.set("ZhuanYe", ZhuanYe);
            query.set("GongZuoDanWei", GongZuoDanWei);
            query.set("MeiNianTouRuShiJian", MeiNianTouRuShiJian);
            query.set("RenWuFenGong", RenWuFenGong);
            query.set("ShenFenZhengHao", ShenFenZhengHao);
            query.set("KeTiBiaoHao", KeTiBiaoHao);
            query.set("ZhiWu", ZhiWu);
            query.set("ZhuangTai", ZhuangTai);
  

            return query;
        }

        public string BianHao { get; set; }
        public string XingMing { get; set; }
        public string XingBie { get; set; }
        public string ZhiCheng { get; set; }
        public string ZhuanYe { get; set; }
        public string GongZuoDanWei { get; set; }
        public int MeiNianTouRuShiJian { get; set; }
        public string RenWuFenGong { get; set; }
        public string ShenFenZhengHao { get; set; }
        public string KeTiBiaoHao { get; set; }
        public string ZhiWu { get; set; }
        public string ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            XingMing = source("XingMing").value<string>("");
            XingBie = source("XingBie").value<string>("");
            ZhiCheng = source("ZhiCheng").value<string>("");
            ZhuanYe = source("ZhuanYe").value<string>("");
            GongZuoDanWei = source("GongZuoDanWei").value<string>("");
            MeiNianTouRuShiJian = source("MeiNianTouRuShiJian").value<int>(0);
            RenWuFenGong = source("RenWuFenGong").value<string>("");
            ShenFenZhengHao = source("ShenFenZhengHao").value<string>("");
            KeTiBiaoHao = source("KeTiBiaoHao").value<string>("");
            ZhiWu = source("ZhiWu").value<string>("");
            ZhuangTai = source("ZhuangTai").value<string>("");
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new RenYuanBiao();
        }
    }
}
