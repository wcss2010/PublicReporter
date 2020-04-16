using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
{
    /// <summary>
    /// 类DanWeiJieDianJingFeiBiao。
    /// </summary>
    [Serializable]
    public partial class DanWeiJieDianJingFeiBiao : IEntity
    {
        public DanWeiJieDianJingFeiBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("BianHao", BianHao);
            query.set("KeTiBianHao", KeTiBianHao);
            query.set("DanWeiMingCheng", DanWeiMingCheng);
            query.set("JingFei", JingFei);
            query.set("ZhuangTai", ZhuangTai);
            query.set("ModifyTime", ModifyTime);

            return query;
        }

        public string BianHao { get; set; }
        public string KeTiBianHao { get; set; }
        public string DanWeiMingCheng { get; set; }
        public decimal JingFei { get; set; }
        public string ZhuangTai { get; set; }
        public DateTime ModifyTime { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            KeTiBianHao = source("KeTiBianHao").value<string>("");
            DanWeiMingCheng = source("DanWeiMingCheng").value<string>("");
            JingFei = source("JingFei").value<decimal>(0);
            ZhuangTai = source("ZhuangTai").value<string>("");
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new DanWeiJieDianJingFeiBiao();
        }
    }
}