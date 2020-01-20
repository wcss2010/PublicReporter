using System;
using System.Data;
using System.Text;

namespace ProjectStrategicLeadershipPlugin.DB.Entitys 
{
    /// <summary>
    /// 类Persons。
    /// </summary>
    [Serializable]
    public partial class Persons : IEntity
    {
        public Persons() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ProjectID", ProjectID);
            query.set("IDCard", IDCard);
            query.set("Name", Name);
            query.set("Job", Job);
            query.set("Specialty", Specialty);
            query.set("Sex", Sex);
            query.set("Birthday", Birthday);
            query.set("Telephone", Telephone);
            query.set("MobilePhone", MobilePhone);
            query.set("Address", Address);
            query.set("AttachInfo", AttachInfo);
            query.set("UnitName", UnitName);
            query.set("UnitAddress", UnitAddress);
            query.set("UnitContact", UnitContact);
            query.set("UnitContactPhone", UnitContactPhone);
            query.set("TaskContent", TaskContent);
            query.set("TimeForSubject", TimeForSubject);
            query.set("RoleType", RoleType);
            query.set("SubjectID", SubjectID);
            query.set("RoleName", RoleName);

            return query;
        }

        public string ProjectID { get; set; }
        public string IDCard { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Specialty { get; set; }
        public string Sex { get; set; }
        public datetime Birthday { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string AttachInfo { get; set; }
        public string UnitName { get; set; }
        public string UnitAddress { get; set; }
        public string UnitContact { get; set; }
        public string UnitContactPhone { get; set; }
        public string TaskContent { get; set; }
        public int32 TimeForSubject { get; set; }
        public string RoleType { get; set; }
        public string SubjectID { get; set; }
        public string RoleName { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ProjectID = source("ProjectID").value<string>("");
            IDCard = source("IDCard").value<string>("");
            Name = source("Name").value<string>("");
            Job = source("Job").value<string>("");
            Specialty = source("Specialty").value<string>("");
            Sex = source("Sex").value<string>("");
            Birthday = source("Birthday").value<datetime>("");
            Telephone = source("Telephone").value<string>("");
            MobilePhone = source("MobilePhone").value<string>("");
            Address = source("Address").value<string>("");
            AttachInfo = source("AttachInfo").value<string>("");
            UnitName = source("UnitName").value<string>("");
            UnitAddress = source("UnitAddress").value<string>("");
            UnitContact = source("UnitContact").value<string>("");
            UnitContactPhone = source("UnitContactPhone").value<string>("");
            TaskContent = source("TaskContent").value<string>("");
            TimeForSubject = source("TimeForSubject").value<int32>("");
            RoleType = source("RoleType").value<string>("");
            SubjectID = source("SubjectID").value<string>("");
            RoleName = source("RoleName").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Persons();
        }
    }
}
