using System;
using System.Data;
using System.Text;

namespace ProjectMilitaryTechnologPlanPlugin.DB.Entitys 
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
            //设置值
            query.set("BianHao", BianHao);
            query.set("XingMing", XingMing);
            query.set("XingBie", XingBie);
            query.set("MinZu", MinZu);
            query.set("ShengRi", ShengRi);
            query.set("ShenFenZhengHao", ShenFenZhengHao);
            query.set("ZhuanYeZhiWu", ZhuanYeZhiWu);
            query.set("YanJiuZhuanChang", YanJiuZhuanChang);
            query.set("GongZuoDanWei", GongZuoDanWei);
            query.set("DianHua", DianHua);
            query.set("ShouJI", ShouJI);
            query.set("ZhiWu", ZhiWu);
            query.set("ShiXiangMuFuZeRen", ShiXiangMuFuZeRen);
            query.set("ZhuangTai", ZhuangTai);
            query.set("BeiZhu", BeiZhu);
            query.set("ModifyTime", DateTime.Now);

            return query;
        }

        public string BianHao { get; set; }
        public string XingMing { get; set; }
        public string XingBie { get; set; }
        public string MinZu { get; set; }
        public DateTime ShengRi { get; set; }
        public string ShenFenZhengHao { get; set; }
        public string ZhuanYeZhiWu { get; set; }
        public string YanJiuZhuanChang { get; set; }
        public string GongZuoDanWei { get; set; }
        public string DianHua { get; set; }
        public string ShouJI { get; set; }
        public string ZhiWu { get; set; }
        public string ShiXiangMuFuZeRen { get; set; }
        public decimal ZhuangTai { get; set; }
        public string BeiZhu { get; set; }
        public DateTime ModifyTime { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            XingMing = source("XingMing").value<string>("");
            XingBie = source("XingBie").value<string>("");
            MinZu = source("MinZu").value<string>("");
            ShengRi = source("ShengRi").value<DateTime>(DateTime.Now);
            ShenFenZhengHao = source("ShenFenZhengHao").value<string>("");
            ZhuanYeZhiWu = source("ZhuanYeZhiWu").value<string>("");
            YanJiuZhuanChang = source("YanJiuZhuanChang").value<string>("");
            GongZuoDanWei = source("GongZuoDanWei").value<string>("");
            DianHua = source("DianHua").value<string>("");
            ShouJI = source("ShouJI").value<string>("");
            ZhiWu = source("ZhiWu").value<string>("");
            ShiXiangMuFuZeRen = source("ShiXiangMuFuZeRen").value<string>("");
            ZhuangTai = source("ZhuangTai").value<decimal>(0);
            BeiZhu = source("BeiZhu").value<string>("");
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new RenYuanBiao();
        }
    }

}