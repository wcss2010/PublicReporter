using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
{
    /// <summary>
    /// 类BoFuBiao。
    /// </summary>
    [Serializable]
    public partial class BoFuBiao : IEntity
    {
        public BoFuBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("BianHao", BianHao);
            query.set("BoFuTiaoJian", BoFuTiaoJian);
            query.set("YuJiShiJian", YuJiShiJian);
            query.set("JingFeiJinQian", JingFeiJinQian);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public string BoFuTiaoJian { get; set; }
        public DateTime YuJiShiJian { get; set; }
        public decimal JingFeiJinQian { get; set; }
        public string ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            BoFuTiaoJian = source("BoFuTiaoJian").value<string>("");
            YuJiShiJian = source("YuJiShiJian").value<DateTime>(DateTime.Now);
            JingFeiJinQian = source("JingFeiJinQian").value<decimal>(0);
            ZhuangTai = source("ZhuangTai").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new BoFuBiao();
        }
    }
}
