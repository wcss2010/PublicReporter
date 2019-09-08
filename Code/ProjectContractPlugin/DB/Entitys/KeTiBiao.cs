using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
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
            //设置值
            query.set("BianHao", BianHao);
            query.set("KeTiMingCheng", KeTiMingCheng);
            query.set("KeTiYanJiuMuBiao", KeTiYanJiuMuBiao);
            query.set("KeTiYanJiuNeiRong", KeTiYanJiuNeiRong);
            query.set("KeTiCanJiaDanWeiFenGong", KeTiCanJiaDanWeiFenGong);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public string KeTiMingCheng { get; set; }
        public string KeTiYanJiuMuBiao { get; set; }
        public string KeTiYanJiuNeiRong { get; set; }
        public string KeTiCanJiaDanWeiFenGong { get; set; }
        public string ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            KeTiMingCheng = source("KeTiMingCheng").value<string>("");
            KeTiYanJiuMuBiao = source("KeTiYanJiuMuBiao").value<string>("");
            KeTiYanJiuNeiRong = source("KeTiYanJiuNeiRong").value<string>("");
            KeTiCanJiaDanWeiFenGong = source("KeTiCanJiaDanWeiFenGong").value<string>("");
            ZhuangTai = source("ZhuangTai").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new KeTiBiao();
        }
    }
}
