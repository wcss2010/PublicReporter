using System;
using System.Data;
using System.Text;

namespace ProjectSocialFundPlugin.DB.Entitys 
{
    /// <summary>
    /// 类Projects。
    /// </summary>
    [Serializable]
    public partial class Projects : Noear.Weed.IEntity
    {
        public Projects() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectName", ProjectName);
            query.set("KeyText", KeyText);
            query.set("ProjectType", ProjectType);
            query.set("WorkType", WorkType);
            query.set("ProjectMaster", ProjectMaster);
            query.set("ProjectMasterSex", ProjectMasterSex);
            query.set("ProjectMasterNation", ProjectMasterNation);
            query.set("ProjectMasterBirthday", ProjectMasterBirthday);
            query.set("WorkJob", WorkJob);
            query.set("ProfessionalTitle", ProfessionalTitle);
            query.set("AreasOfSpecialization", AreasOfSpecialization);
            query.set("FinalEducation", FinalEducation);
            query.set("FinalDegree", FinalDegree);
            query.set("AsAMentor", AsAMentor);
            query.set("WorkUnit", WorkUnit);
            query.set("ContactPhone", ContactPhone);
            query.set("OwnedSystem", OwnedSystem);
            query.set("IDCard", IDCard);
            query.set("FirstRecommender", FirstRecommender);
            query.set("FirstRecommenderTitle", FirstRecommenderTitle);
            query.set("FirstRecommenderUnit", FirstRecommenderUnit);
            query.set("SecondRecommender", SecondRecommender);
            query.set("SecondRecommenderTitle", SecondRecommenderTitle);
            query.set("SecondRecommenderUnit", SecondRecommenderUnit);
            query.set("ExpectedResults", ExpectedResults);
            query.set("WordCount", WordCount);
            query.set("RequestMoney", RequestMoney);
            query.set("RequestDate", RequestDate);
            query.set("CompleteDate", CompleteDate);

            return query;
        }

        public string ID { get; set; }
        public string ProjectName { get; set; }
        public string KeyText { get; set; }
        public string ProjectType { get; set; }
        public string WorkType { get; set; }
        public string ProjectMaster { get; set; }
        public string ProjectMasterSex { get; set; }
        public string ProjectMasterNation { get; set; }
        public string ProjectMasterBirthday { get; set; }
        public string WorkJob { get; set; }
        public string ProfessionalTitle { get; set; }
        public string AreasOfSpecialization { get; set; }
        public string FinalEducation { get; set; }
        public string FinalDegree { get; set; }
        public string AsAMentor { get; set; }
        public string WorkUnit { get; set; }
        public string ContactPhone { get; set; }
        public string OwnedSystem { get; set; }
        public string IDCard { get; set; }
        public string FirstRecommender { get; set; }
        public string FirstRecommenderTitle { get; set; }
        public string FirstRecommenderUnit { get; set; }
        public string SecondRecommender { get; set; }
        public string SecondRecommenderTitle { get; set; }
        public string SecondRecommenderUnit { get; set; }
        public string ExpectedResults { get; set; }
        public int WordCount { get; set; }
        public decimal RequestMoney { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime CompleteDate { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>("");
            ProjectName = source("ProjectName").value<string>("");
            KeyText = source("KeyText").value<string>("");
            ProjectType = source("ProjectType").value<string>("");
            WorkType = source("WorkType").value<string>("");
            ProjectMaster = source("ProjectMaster").value<string>("");
            ProjectMasterSex = source("ProjectMasterSex").value<string>("");
            ProjectMasterNation = source("ProjectMasterNation").value<string>("");
            ProjectMasterBirthday = source("ProjectMasterBirthday").value<string>("");
            WorkJob = source("WorkJob").value<string>("");
            ProfessionalTitle = source("ProfessionalTitle").value<string>("");
            AreasOfSpecialization = source("AreasOfSpecialization").value<string>("");
            FinalEducation = source("FinalEducation").value<string>("");
            FinalDegree = source("FinalDegree").value<string>("");
            AsAMentor = source("AsAMentor").value<string>("");
            WorkUnit = source("WorkUnit").value<string>("");
            ContactPhone = source("ContactPhone").value<string>("");
            OwnedSystem = source("OwnedSystem").value<string>("");
            IDCard = source("IDCard").value<string>("");
            FirstRecommender = source("FirstRecommender").value<string>("");
            FirstRecommenderTitle = source("FirstRecommenderTitle").value<string>("");
            FirstRecommenderUnit = source("FirstRecommenderUnit").value<string>("");
            SecondRecommender = source("SecondRecommender").value<string>("");
            SecondRecommenderTitle = source("SecondRecommenderTitle").value<string>("");
            SecondRecommenderUnit = source("SecondRecommenderUnit").value<string>("");
            ExpectedResults = source("ExpectedResults").value<string>("");
            WordCount = source("WordCount").value<int>(0);
            RequestMoney = source("RequestMoney").value<decimal>(0);
            RequestDate = source("RequestDate").value<DateTime>(DateTime.Now);
            CompleteDate = source("CompleteDate").value<DateTime>(DateTime.Now);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Projects();
        }
    }
}