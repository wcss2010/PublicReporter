using System;
using System.Data;
using System.Text;

namespace ProjectMilitaryTechnologPlanPlugin.DB.Entitys 
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
            query.set("ModifyTime", DateTime.Now);
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
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            NianDu = source("NianDu").value<int>(0);
            NeiRong = source("NeiRong").value<string>("");
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new JiShuBiao();
        }
    }
}
