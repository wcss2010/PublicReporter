using System;
using System.Data;
using System.Text;

namespace ProjectMoneyProtocolPlugin.DB.Entitys 
{
    /// <summary>
    /// 类KeTiBiao。
    /// </summary>
    [Serializable]
    public partial class KeTiBiao : IEntity
    {
        public KeTiBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //更新保存时间
            updateSaveDate();

            query.set("ModifyTime", DateTime.Now);

            //设置值
            query.set("BianHao", BianHao);
            query.set("KeTiMingCheng", KeTiMingCheng);
            query.set("KeTiBaoMiDengJi", KeTiBaoMiDengJi);
            query.set("KeTiYanJiuMuBiao", KeTiYanJiuMuBiao);
            query.set("KeTiYanJiuNeiRong", KeTiYanJiuNeiRong);
            query.set("KeTiCanJiaDanWeiFenGong", KeTiCanJiaDanWeiFenGong);
            query.set("KeTiFuZeDanWei", KeTiFuZeDanWei);
            query.set("KeTiFuZeDanWeiChangYongMingCheng", KeTiFuZeDanWeiChangYongMingCheng);
            query.set("KeTiFuZeDanWeiTongXunDiZhi", KeTiFuZeDanWeiTongXunDiZhi);
            query.set("KeTiFuZeDanWeiLianXiRen", KeTiFuZeDanWeiLianXiRen);
            query.set("KeTiFuZeDanWeiLianXiRenDianHua", KeTiFuZeDanWeiLianXiRenDianHua);
            query.set("KeTiSuoShuBuMen", KeTiSuoShuBuMen);
            query.set("KeTiSuoShuDiDian", KeTiSuoShuDiDian);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public string KeTiMingCheng { get; set; }
        public string KeTiBaoMiDengJi { get; set; }
        public string KeTiYanJiuMuBiao { get; set; }
        public string KeTiYanJiuNeiRong { get; set; }
        public string KeTiCanJiaDanWeiFenGong { get; set; }
        public string KeTiFuZeDanWei { get; set; }
        public string KeTiFuZeDanWeiChangYongMingCheng { get; set; }
        public string KeTiFuZeDanWeiTongXunDiZhi { get; set; }
        public string KeTiFuZeDanWeiLianXiRen { get; set; }
        public string KeTiFuZeDanWeiLianXiRenDianHua { get; set; }
        public string KeTiSuoShuBuMen { get; set; }
        public string KeTiSuoShuDiDian { get; set; }
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            KeTiMingCheng = source("KeTiMingCheng").value<string>("");
            KeTiBaoMiDengJi = source("KeTiBaoMiDengJi").value<string>("");
            KeTiYanJiuMuBiao = source("KeTiYanJiuMuBiao").value<string>("");
            KeTiYanJiuNeiRong = source("KeTiYanJiuNeiRong").value<string>("");
            KeTiCanJiaDanWeiFenGong = source("KeTiCanJiaDanWeiFenGong").value<string>("");
            KeTiFuZeDanWei = source("KeTiFuZeDanWei").value<string>("");
            KeTiFuZeDanWeiChangYongMingCheng = source("KeTiFuZeDanWeiChangYongMingCheng").value<string>("");
            KeTiFuZeDanWeiTongXunDiZhi = source("KeTiFuZeDanWeiTongXunDiZhi").value<string>("");
            KeTiFuZeDanWeiLianXiRen = source("KeTiFuZeDanWeiLianXiRen").value<string>("");
            KeTiFuZeDanWeiLianXiRenDianHua = source("KeTiFuZeDanWeiLianXiRenDianHua").value<string>("");
            KeTiSuoShuBuMen = source("KeTiSuoShuBuMen").value<string>("");
            KeTiSuoShuDiDian = source("KeTiSuoShuDiDian").value<string>("");
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new KeTiBiao();
        }
    }
}