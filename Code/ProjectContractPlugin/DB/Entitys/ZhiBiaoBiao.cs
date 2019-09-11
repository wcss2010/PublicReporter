using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
{
    /// <summary>
    /// 类ZhiBiaoBiao。
    /// </summary>
    [Serializable]
    public partial class ZhiBiaoBiao : IEntity
    {
        public ZhiBiaoBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            query.set("ModifyTime", DateTime.Now);
            //设置值
            query.set("BianHao", BianHao);
            query.set("ZhiBiaoMingCheng", ZhiBiaoMingCheng);
            query.set("ZhiBiaoYaoQiu", ZhiBiaoYaoQiu);
            query.set("KaoHeFangShi", KaoHeFangShi);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public string ZhiBiaoMingCheng { get; set; }
        public string ZhiBiaoYaoQiu { get; set; }
        public string KaoHeFangShi { get; set; }
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            ZhiBiaoMingCheng = source("ZhiBiaoMingCheng").value<string>("");
            ZhiBiaoYaoQiu = source("ZhiBiaoYaoQiu").value<string>("");
            KaoHeFangShi = source("KaoHeFangShi").value<string>("");
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new ZhiBiaoBiao();
        }
    }
}
