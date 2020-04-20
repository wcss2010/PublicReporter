using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
{
    /// <summary>
    /// 类KeTiJieDianJingFeiBiao。
    /// </summary>
    [Serializable]
    public partial class KeTiJieDianJingFeiBiao : IEntity
    {
        public KeTiJieDianJingFeiBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //更新保存时间
            updateSaveDate();

            //设置值
            query.set("ModifyTime", DateTime.Now);

            query.set("BianHao", BianHao);
            query.set("BoFuBianHao", BoFuBianHao);
            query.set("KeTiBianHao", KeTiBianHao);
            query.set("JingFei", JingFei);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public string BoFuBianHao { get; set; }
        public string KeTiBianHao { get; set; }
        public decimal JingFei { get; set; }
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            BoFuBianHao = source("BoFuBianHao").value<string>("");
            KeTiBianHao = source("KeTiBianHao").value<string>("");
            JingFei = source("JingFei").value<decimal>(0);
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new KeTiJieDianJingFeiBiao();
        }
    }
}