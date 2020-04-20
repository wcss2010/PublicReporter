using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys
{
    /// <summary>
    /// 类RenWuBiao。
    /// </summary>
    [Serializable]
    public partial class RenWuBiao : IEntity
    {
        public RenWuBiao() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //更新保存时间
            updateSaveDate();

            //设置值
            query.set("BianHao", BianHao);
            query.set("KeTiBianHao", KeTiBianHao);
            query.set("DanWeiMing", DanWeiMing);
            query.set("RenWuFenGong", RenWuFenGong);
            query.set("ZhuangTai", ZhuangTai);
            query.set("ModifyTime", DateTime.Now);

            return query;
        }

        public string BianHao { get; set; }
        public string KeTiBianHao { get; set; }
        public string DanWeiMing { get; set; }
        public string RenWuFenGong { get; set; }
        public double ZhuangTai { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            BianHao = source("BianHao").value<string>(Guid.NewGuid().ToString());
            KeTiBianHao = source("KeTiBianHao").value<string>("");
            DanWeiMing = source("DanWeiMing").value<string>("");
            RenWuFenGong = source("RenWuFenGong").value<string>("");
            ZhuangTai = source("ZhuangTai").value<double>(0);
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new RenWuBiao();
        }
    }
}