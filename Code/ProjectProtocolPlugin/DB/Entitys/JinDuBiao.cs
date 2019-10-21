using System;
using System.Data;
using System.Text;

namespace ProjectProtocolPlugin.DB.Entitys 
{
    /// <summary>
    /// 类JinDuBiao。
    /// </summary>
    [Serializable]
    public partial class JinDuBiao : IEntity
    {
        public JinDuBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            query.set("ModifyTime", DateTime.Now);
            //设置值
            query.set("BianHao", BianHao);
            query.set("JieDian", JieDian);
            query.set("ShiJian", ShiJian);
            query.set("JieDuanMuBiao", JieDuanMuBiao);
            query.set("WanChengNeiRong", WanChengNeiRong);
            query.set("JieDuanChengGuo", JieDuanChengGuo);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public int JieDian { get; set; }
        public DateTime ShiJian { get; set; }
        public string JieDuanMuBiao { get; set; }
        public string WanChengNeiRong { get; set; }
        public string JieDuanChengGuo { get; set; }
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            JieDian = source("JieDian").value<int>(0);
            ShiJian = source("ShiJian").value<DateTime>(DateTime.Now);
            JieDuanMuBiao = source("JieDuanMuBiao").value<string>("");
            WanChengNeiRong = source("WanChengNeiRong").value<string>("");
            JieDuanChengGuo = source("JieDuanChengGuo").value<string>("");
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new JinDuBiao();
        }
    }
}
