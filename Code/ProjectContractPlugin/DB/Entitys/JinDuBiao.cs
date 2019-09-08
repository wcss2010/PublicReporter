using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
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
        public int32 JieDian { get; set; }
        public datetime ShiJian { get; set; }
        public string JieDuanMuBiao { get; set; }
        public string WanChengNeiRong { get; set; }
        public string JieDuanChengGuo { get; set; }
        public string ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            JieDian = source("JieDian").value<int32>("");
            ShiJian = source("ShiJian").value<datetime>("");
            JieDuanMuBiao = source("JieDuanMuBiao").value<string>("");
            WanChengNeiRong = source("WanChengNeiRong").value<string>("");
            JieDuanChengGuo = source("JieDuanChengGuo").value<string>("");
            ZhuangTai = source("ZhuangTai").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new JinDuBiao();
        }
    }
}
