using System;
using System.Data;
using System.Text;

namespace ProjectMilitaryTechnologPlanPlugin.DB.Entitys 
{
    /// <summary>
    /// 类Version。
    /// </summary>
    [Serializable]
    public partial class Version : IEntity
    {
        public Version() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("VersionNum", VersionNum);
            query.set("Tag", Tag);

            return query;
        }

        public string VersionNum { get; set; }
        public string Tag { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            VersionNum = source("VersionNum").value<string>("");
            Tag = source("Tag").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Version();
        }
    }
}
