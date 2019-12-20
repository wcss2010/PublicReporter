using System;
using System.Data;
using System.Text;

namespace ProjectMilitaryTechnologPlanPlugin.DB.Entitys
{
    /// <summary>
    /// 类JiBenXinXiBiao。
    /// </summary>
    [Serializable]
    public partial class JiBenXinXiBiao : IEntity
    {
        public JiBenXinXiBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("BianHao", BianHao);
            query.set("XiangMuMingCheng", XiangMuMingCheng);
            query.set("YanJiuMuBiao", YanJiuMuBiao);
            query.set("YanJiuNeiRong", YanJiuNeiRong);
            query.set("YuQiChengGuo", YuQiChengGuo);
            query.set("YanJiuZhouQi", YanJiuZhouQi);
            query.set("JingFeiYuSuan", JingFeiYuSuan);
            query.set("XiangMuLeiBie", XiangMuLeiBie);
            query.set("ZhuanYeLeiBie", ZhuanYeLeiBie);
            query.set("ZeRenDanWei", ZeRenDanWei);
            query.set("XiaJiDanWei", XiaJiDanWei);
            query.set("BeiZhu", BeiZhu);
            query.set("QianTouRen", QianTouRen);
            query.set("QianTouRenShenFenZheng", QianTouRenShenFenZheng);
            query.set("QianTouRenXingBie", QianTouRenXingBie);
            query.set("QianTouRenMinZu", QianTouRenMinZu);
            query.set("QianTouRenShengRi", QianTouRenShengRi);
            query.set("QianTouRenDianHua", QianTouRenDianHua);
            query.set("QianTouRenShouJi", QianTouRenShouJi);
            query.set("BuZhiBie", BuZhiBie);
            query.set("LianHeYanJiuDanWei", LianHeYanJiuDanWei);
            query.set("ShenQingJingFei", ShenQingJingFei);
            query.set("JiHuaWanChengShiJian", JiHuaWanChengShiJian);
            query.set("ZhuangTai", ZhuangTai);
            query.set("ModifyTime", ModifyTime);

            return query;
        }

        public string BianHao { get; set; }
        public string XiangMuMingCheng { get; set; }
        public string YanJiuMuBiao { get; set; }
        public string YanJiuNeiRong { get; set; }
        public string YuQiChengGuo { get; set; }
        public decimal YanJiuZhouQi { get; set; }
        public decimal JingFeiYuSuan { get; set; }
        public string XiangMuLeiBie { get; set; }
        public string ZhuanYeLeiBie { get; set; }
        public string ZeRenDanWei { get; set; }
        public string XiaJiDanWei { get; set; }
        public string BeiZhu { get; set; }
        public string QianTouRen { get; set; }
        public string QianTouRenShenFenZheng { get; set; }
        public string QianTouRenXingBie { get; set; }
        public string QianTouRenMinZu { get; set; }
        public DateTime QianTouRenShengRi { get; set; }
        public string QianTouRenDianHua { get; set; }
        public string QianTouRenShouJi { get; set; }
        public string BuZhiBie { get; set; }
        public string LianHeYanJiuDanWei { get; set; }
        public decimal ShenQingJingFei { get; set; }
        public DateTime JiHuaWanChengShiJian { get; set; }
        public decimal ZhuangTai { get; set; }
        public DateTime ModifyTime { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            XiangMuMingCheng = source("XiangMuMingCheng").value<string>("");
            YanJiuMuBiao = source("YanJiuMuBiao").value<string>("");
            YanJiuNeiRong = source("YanJiuNeiRong").value<string>("");
            YuQiChengGuo = source("YuQiChengGuo").value<string>("");
            YanJiuZhouQi = source("YanJiuZhouQi").value<decimal>(0);
            JingFeiYuSuan = source("JingFeiYuSuan").value<decimal>(0);
            XiangMuLeiBie = source("XiangMuLeiBie").value<string>("");
            ZhuanYeLeiBie = source("ZhuanYeLeiBie").value<string>("");
            ZeRenDanWei = source("ZeRenDanWei").value<string>("");
            XiaJiDanWei = source("XiaJiDanWei").value<string>("");
            BeiZhu = source("BeiZhu").value<string>("");
            QianTouRen = source("QianTouRen").value<string>("");
            QianTouRenShenFenZheng = source("QianTouRenShenFenZheng").value<string>("");
            QianTouRenXingBie = source("QianTouRenXingBie").value<string>("");
            QianTouRenMinZu = source("QianTouRenMinZu").value<string>("");
            QianTouRenShengRi = source("QianTouRenShengRi").value<DateTime>(DateTime.Now);
            QianTouRenDianHua = source("QianTouRenDianHua").value<string>("");
            QianTouRenShouJi = source("QianTouRenShouJi").value<string>("");
            BuZhiBie = source("BuZhiBie").value<string>("");
            LianHeYanJiuDanWei = source("LianHeYanJiuDanWei").value<string>("");
            ShenQingJingFei = source("ShenQingJingFei").value<decimal>(0);
            JiHuaWanChengShiJian = source("JiHuaWanChengShiJian").value<DateTime>(DateTime.Now);
            ZhuangTai = source("ZhuangTai").value<decimal>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new JiBenXinXiBiao();
        }
    }
}