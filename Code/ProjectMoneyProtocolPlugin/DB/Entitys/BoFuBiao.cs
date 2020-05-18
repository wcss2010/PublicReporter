using System;
using System.Data;
using System.Text;

namespace ProjectMoneyProtocolPlugin.DB.Entitys 
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
            //更新保存时间
            updateSaveDate();

            query.set("ModifyTime", DateTime.Now);
            //设置值
            query.set("BianHao", BianHao);
            query.set("BoFuTiaoJian", BoFuTiaoJian);
            query.set("YuJiShiJian", YuJiShiJian);
            query.set("JingFeiJinQian", JingFeiJinQian);
            query.set("ZhuangTai", ZhuangTai);
            query.set("BeiZhu", BeiZhu);

            return query;
        }

        public string BianHao { get; set; }
        public string BoFuTiaoJian { get; set; }
        public DateTime YuJiShiJian { get; set; }
        public decimal JingFeiJinQian { get; set; }
        public double ZhuangTai { get; set; }
        public string BeiZhu { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            BoFuTiaoJian = source("BoFuTiaoJian").value<string>("");
            YuJiShiJian = source("YuJiShiJian").value<DateTime>(DateTime.Now);
            JingFeiJinQian = source("JingFeiJinQian").value<decimal>(0);
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
            BeiZhu = source("BeiZhu").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new BoFuBiao();
        }
    }
}
