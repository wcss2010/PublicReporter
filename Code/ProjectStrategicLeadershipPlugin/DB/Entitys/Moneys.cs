using System;
using System.Data;
using System.Text;

namespace ProjectStrategicLeadershipPlugin.DB.Entitys 
{
    /// <summary>
    /// 类Moneys。
    /// </summary>
    [Serializable]
    public partial class Moneys : IEntity
    {
        public Moneys() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("Index", Index);
            query.set("ProjectID", ProjectID);
            query.set("Name", Name);
            query.set("Value", Value);

            return query;
        }

        public int32 Index { get; set; }
        public string ProjectID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            Index = source("Index").value<int32>("");
            ProjectID = source("ProjectID").value<string>("");
            Name = source("Name").value<string>("");
            Value = source("Value").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Moneys();
        }
    }
}
