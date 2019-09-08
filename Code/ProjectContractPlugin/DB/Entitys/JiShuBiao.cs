using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys 
{
    /// <summary>
    /// 类JiShuBiao。
    /// </summary>
    [Serializable]
    public partial class JiShuBiao : IEntity
    {
        public JiShuBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("BianHao", BianHao);
            query.set("NianDu", NianDu);
            query.set("NeiRong", NeiRong);
            query.set("ZhuangTai", ZhuangTai);

            return query;
        }

        public string BianHao { get; set; }
        public int NianDu { get; set; }
        public string NeiRong { get; set; }
        public string ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>("");
            NianDu = source("NianDu").value<int>("");
            NeiRong = source("NeiRong").value<string>("");
            ZhuangTai = source("ZhuangTai").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new JiShuBiao();
        }
    }
}
