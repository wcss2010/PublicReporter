using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
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
            query.set("HeTongBianHao", HeTongBianHao);
            query.set("HeTongMingCheng", HeTongMingCheng);
            query.set("HeTongMiJi", HeTongMiJi);
            query.set("HeTongMiQi", HeTongMiQi);
            query.set("HeTongFuZeRen", HeTongFuZeRen);
            query.set("HeTongFuZeRenShenFenZheng", HeTongFuZeRenShenFenZheng);
            query.set("HeTongFuZeRenDianHua", HeTongFuZeRenDianHua);
            query.set("HeTongKaiShiShiJian", HeTongKaiShiShiJian);
            query.set("HeTongJieShuShiJian", HeTongJieShuShiJian);
            query.set("HeTongJiaKuan", HeTongJiaKuan);
            query.set("HeTongFuZeDanWei", HeTongFuZeDanWei);
            query.set("HeTongFuZeDanWeiChangYongMingCheng", HeTongFuZeDanWeiChangYongMingCheng);
            query.set("HeTongFuZeDanWeiTongXunDiZhi", HeTongFuZeDanWeiTongXunDiZhi);
            query.set("HeTongFuZeDanWeiLianXiRen", HeTongFuZeDanWeiLianXiRen);
            query.set("HeTongFuZeDanWeiLianXiRenDianHua", HeTongFuZeDanWeiLianXiRenDianHua);
            query.set("HeTongSuoShuBuMen", HeTongSuoShuBuMen);
            query.set("HeTongSuoShuDiDian", HeTongSuoShuDiDian);
            query.set("HeTongGuanJianZi", HeTongGuanJianZi);
            query.set("HeTongSuoShuLingYu", HeTongSuoShuLingYu);
            query.set("HeTongJingFeiGuanLiMoShi", HeTongJingFeiGuanLiMoShi);
            query.set("WeiTuoDanWeiMingCheng", WeiTuoDanWeiMingCheng);
            query.set("WeiTuoDanWeiXingZhi", WeiTuoDanWeiXingZhi);
            query.set("WeiTuoDanWeiFaDingDaiBiaoRen", WeiTuoDanWeiFaDingDaiBiaoRen);
            query.set("WeiTuoDanWeiLianXiRen", WeiTuoDanWeiLianXiRen);
            query.set("WeiTuoDanWeiLianXiRenDianHua", WeiTuoDanWeiLianXiRenDianHua);
            query.set("WeiTuoDanWeiTongXinDiZhi", WeiTuoDanWeiTongXinDiZhi);
            query.set("WeiTuoDanWeiYouZhengBianMa", WeiTuoDanWeiYouZhengBianMa);
            query.set("WeiTuoDanWeiZuZhiJiGouDaiMa", WeiTuoDanWeiZuZhiJiGouDaiMa);
            query.set("WeiTuoDanWeiShuiHao", WeiTuoDanWeiShuiHao);
            query.set("WeiTuoDanWeiKaiHuMingCheng", WeiTuoDanWeiKaiHuMingCheng);
            query.set("WeiTuoDanWeiKaiHuYingHang", WeiTuoDanWeiKaiHuYingHang);
            query.set("WeiTuoDanWeiYinHangZhangHao", WeiTuoDanWeiYinHangZhangHao);
            query.set("WeiTuoDanWeiCaiWuFuZeRen", WeiTuoDanWeiCaiWuFuZeRen);
            query.set("WeiTuoDanWeiCaiWuFuZeRenDianHua", WeiTuoDanWeiCaiWuFuZeRenDianHua);
            query.set("ChengYanDanWeiMingCheng", ChengYanDanWeiMingCheng);
            query.set("ChengYanDanWeiXingZhi", ChengYanDanWeiXingZhi);
            query.set("ChengYanDanWeiFaDingDaiBiaoRen", ChengYanDanWeiFaDingDaiBiaoRen);
            query.set("ChengYanDanWeiLianXiRen", ChengYanDanWeiLianXiRen);
            query.set("ChengYanDanWeiLianXiRenDianHua", ChengYanDanWeiLianXiRenDianHua);
            query.set("ChengYanDanWeiTongXinDiZhi", ChengYanDanWeiTongXinDiZhi);
            query.set("ChengYanDanWeiYouZhengBianMa", ChengYanDanWeiYouZhengBianMa);
            query.set("ChengYanDanWeiZuZhiJiGouDaiMa", ChengYanDanWeiZuZhiJiGouDaiMa);
            query.set("ChengYanDanWeiShuiHao", ChengYanDanWeiShuiHao);
            query.set("ChengYanDanWeiKaiHuMingCheng", ChengYanDanWeiKaiHuMingCheng);
            query.set("ChengYanDanWeiKaiHuYingHang", ChengYanDanWeiKaiHuYingHang);
            query.set("ChengYanDanWeiYinHangZhangHao", ChengYanDanWeiYinHangZhangHao);
            query.set("ChengYanDanWeiCaiWuFuZeRen", ChengYanDanWeiCaiWuFuZeRen);
            query.set("ChengYanDanWeiCaiWuFuZeRenDianHua", ChengYanDanWeiCaiWuFuZeRenDianHua);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public string HeTongBianHao { get; set; }
        public string HeTongMingCheng { get; set; }
        public string HeTongMiJi { get; set; }
        public int HeTongMiQi { get; set; }
        public string HeTongFuZeRen { get; set; }
        public string HeTongFuZeRenShenFenZheng { get; set; }
        public string HeTongFuZeRenDianHua { get; set; }
        public DateTime HeTongKaiShiShiJian { get; set; }
        public DateTime HeTongJieShuShiJian { get; set; }
        public decimal HeTongJiaKuan { get; set; }
        public string HeTongFuZeDanWei { get; set; }
        public string HeTongFuZeDanWeiChangYongMingCheng { get; set; }
        public string HeTongFuZeDanWeiTongXunDiZhi { get; set; }
        public string HeTongFuZeDanWeiLianXiRen { get; set; }
        public string HeTongFuZeDanWeiLianXiRenDianHua { get; set; }
        public string HeTongSuoShuBuMen { get; set; }
        public string HeTongSuoShuDiDian { get; set; }
        public string HeTongGuanJianZi { get; set; }
        public string HeTongSuoShuLingYu { get; set; }
        public string HeTongJingFeiGuanLiMoShi { get; set; }
        public string WeiTuoDanWeiMingCheng { get; set; }
        public string WeiTuoDanWeiXingZhi { get; set; }
        public string WeiTuoDanWeiFaDingDaiBiaoRen { get; set; }
        public string WeiTuoDanWeiLianXiRen { get; set; }
        public string WeiTuoDanWeiLianXiRenDianHua { get; set; }
        public string WeiTuoDanWeiTongXinDiZhi { get; set; }
        public string WeiTuoDanWeiYouZhengBianMa { get; set; }
        public string WeiTuoDanWeiZuZhiJiGouDaiMa { get; set; }
        public string WeiTuoDanWeiShuiHao { get; set; }
        public string WeiTuoDanWeiKaiHuMingCheng { get; set; }
        public string WeiTuoDanWeiKaiHuYingHang { get; set; }
        public string WeiTuoDanWeiYinHangZhangHao { get; set; }
        public string WeiTuoDanWeiCaiWuFuZeRen { get; set; }
        public string WeiTuoDanWeiCaiWuFuZeRenDianHua { get; set; }
        public string ChengYanDanWeiMingCheng { get; set; }
        public string ChengYanDanWeiXingZhi { get; set; }
        public string ChengYanDanWeiFaDingDaiBiaoRen { get; set; }
        public string ChengYanDanWeiLianXiRen { get; set; }
        public string ChengYanDanWeiLianXiRenDianHua { get; set; }
        public string ChengYanDanWeiTongXinDiZhi { get; set; }
        public string ChengYanDanWeiYouZhengBianMa { get; set; }
        public string ChengYanDanWeiZuZhiJiGouDaiMa { get; set; }
        public string ChengYanDanWeiShuiHao { get; set; }
        public string ChengYanDanWeiKaiHuMingCheng { get; set; }
        public string ChengYanDanWeiKaiHuYingHang { get; set; }
        public string ChengYanDanWeiYinHangZhangHao { get; set; }
        public string ChengYanDanWeiCaiWuFuZeRen { get; set; }
        public string ChengYanDanWeiCaiWuFuZeRenDianHua { get; set; }
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            HeTongBianHao = source("HeTongBianHao").value<string>("");
            HeTongMingCheng = source("HeTongMingCheng").value<string>("");
            HeTongMiJi = source("HeTongMiJi").value<string>("");
            HeTongMiQi = source("HeTongMiQi").value<int>(0);
            HeTongFuZeRen = source("HeTongFuZeRen").value<string>("");
            HeTongFuZeRenShenFenZheng = source("HeTongFuZeRenShenFenZheng").value<string>("");
            HeTongFuZeRenDianHua = source("HeTongFuZeRenDianHua").value<string>("");
            HeTongKaiShiShiJian = source("HeTongKaiShiShiJian").value<DateTime>(DateTime.Now);
            HeTongJieShuShiJian = source("HeTongJieShuShiJian").value<DateTime>(DateTime.Now);
            HeTongJiaKuan = source("HeTongJiaKuan").value<decimal>(0);
            HeTongFuZeDanWei = source("HeTongFuZeDanWei").value<string>("");
            HeTongFuZeDanWeiChangYongMingCheng = source("HeTongFuZeDanWeiChangYongMingCheng").value<string>("");
            HeTongFuZeDanWeiTongXunDiZhi = source("HeTongFuZeDanWeiTongXunDiZhi").value<string>("");
            HeTongFuZeDanWeiLianXiRen = source("HeTongFuZeDanWeiLianXiRen").value<string>("");
            HeTongFuZeDanWeiLianXiRenDianHua = source("HeTongFuZeDanWeiLianXiRenDianHua").value<string>("");
            HeTongSuoShuBuMen = source("HeTongSuoShuBuMen").value<string>("");
            HeTongSuoShuDiDian = source("HeTongSuoShuDiDian").value<string>("");
            HeTongGuanJianZi = source("HeTongGuanJianZi").value<string>("");
            HeTongSuoShuLingYu = source("HeTongSuoShuLingYu").value<string>("");
            HeTongJingFeiGuanLiMoShi = source("HeTongJingFeiGuanLiMoShi").value<string>("");
            WeiTuoDanWeiMingCheng = source("WeiTuoDanWeiMingCheng").value<string>("");
            WeiTuoDanWeiXingZhi = source("WeiTuoDanWeiXingZhi").value<string>("");
            WeiTuoDanWeiFaDingDaiBiaoRen = source("WeiTuoDanWeiFaDingDaiBiaoRen").value<string>("");
            WeiTuoDanWeiLianXiRen = source("WeiTuoDanWeiLianXiRen").value<string>("");
            WeiTuoDanWeiLianXiRenDianHua = source("WeiTuoDanWeiLianXiRenDianHua").value<string>("");
            WeiTuoDanWeiTongXinDiZhi = source("WeiTuoDanWeiTongXinDiZhi").value<string>("");
            WeiTuoDanWeiYouZhengBianMa = source("WeiTuoDanWeiYouZhengBianMa").value<string>("");
            WeiTuoDanWeiZuZhiJiGouDaiMa = source("WeiTuoDanWeiZuZhiJiGouDaiMa").value<string>("");
            WeiTuoDanWeiShuiHao = source("WeiTuoDanWeiShuiHao").value<string>("");
            WeiTuoDanWeiKaiHuMingCheng = source("WeiTuoDanWeiKaiHuMingCheng").value<string>("");
            WeiTuoDanWeiKaiHuYingHang = source("WeiTuoDanWeiKaiHuYingHang").value<string>("");
            WeiTuoDanWeiYinHangZhangHao = source("WeiTuoDanWeiYinHangZhangHao").value<string>("");
            WeiTuoDanWeiCaiWuFuZeRen = source("WeiTuoDanWeiCaiWuFuZeRen").value<string>("");
            WeiTuoDanWeiCaiWuFuZeRenDianHua = source("WeiTuoDanWeiCaiWuFuZeRenDianHua").value<string>("");
            ChengYanDanWeiMingCheng = source("ChengYanDanWeiMingCheng").value<string>("");
            ChengYanDanWeiXingZhi = source("ChengYanDanWeiXingZhi").value<string>("");
            ChengYanDanWeiFaDingDaiBiaoRen = source("ChengYanDanWeiFaDingDaiBiaoRen").value<string>("");
            ChengYanDanWeiLianXiRen = source("ChengYanDanWeiLianXiRen").value<string>("");
            ChengYanDanWeiLianXiRenDianHua = source("ChengYanDanWeiLianXiRenDianHua").value<string>("");
            ChengYanDanWeiTongXinDiZhi = source("ChengYanDanWeiTongXinDiZhi").value<string>("");
            ChengYanDanWeiYouZhengBianMa = source("ChengYanDanWeiYouZhengBianMa").value<string>("");
            ChengYanDanWeiZuZhiJiGouDaiMa = source("ChengYanDanWeiZuZhiJiGouDaiMa").value<string>("");
            ChengYanDanWeiShuiHao = source("ChengYanDanWeiShuiHao").value<string>("");
            ChengYanDanWeiKaiHuMingCheng = source("ChengYanDanWeiKaiHuMingCheng").value<string>("");
            ChengYanDanWeiKaiHuYingHang = source("ChengYanDanWeiKaiHuYingHang").value<string>("");
            ChengYanDanWeiYinHangZhangHao = source("ChengYanDanWeiYinHangZhangHao").value<string>("");
            ChengYanDanWeiCaiWuFuZeRen = source("ChengYanDanWeiCaiWuFuZeRen").value<string>("");
            ChengYanDanWeiCaiWuFuZeRenDianHua = source("ChengYanDanWeiCaiWuFuZeRenDianHua").value<string>("");
            ZhuangTai = source("ZhuangTai").value<double>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new JiBenXinXiBiao();
        }
    }
}