using System;
using System.Data;
using System.Text;

namespace ProjectContractPlugin.DB.Entitys
{
    /// <summary>
    /// 类Task。
    /// </summary>
    [Serializable]
    public partial class Task : IEntity
    {
        public Task() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectID", ProjectID);
            query.set("PersonID", PersonID);
            query.set("Role", Role);
            query.set("Type", Type);
            query.set("Content", Content);
            query.set("TotalTime", TotalTime);
            query.set("TotalMoney", TotalMoney);
            query.set("IDCard", IDCard);
            query.set("DisplayOrder", DisplayOrder);            

            return query;
        }

        #region Model
        private string _id;
        private string _projectid;
        private string _personid;
        private string _role;
        private string _type;
        private string _Content;
        private int? _totaltime;
        private decimal? _totalMoney;
        private string _idcard;
        private int? _displayOrder;

        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectID
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonID
        {
            set { _personid = value; }
            get { return _personid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Role
        {
            set { _role = value; }
            get { return _role; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TotalTime
        {
            set { _totaltime = value; }
            get { return _totaltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }

        public int? DisplayOrder
        {
            get
            {
                return _displayOrder;
            }

            set
            {
                _displayOrder = value;
            }
        }

        public decimal? TotalMoney
        {
            get
            {
                return _totalMoney;
            }

            set
            {
                _totalMoney = value;
            }
        }

        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            ProjectID = source("ProjectID").value<string>(string.Empty);
            PersonID = source("PersonID").value<string>(string.Empty);
            Role = source("Role").value<string>(string.Empty);
            Type = source("Type").value<string>(string.Empty);
            Content = source("Content").value<string>(string.Empty);
            TotalTime = source("TotalTime").value<int>(0);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            IDCard = source("IDCard").value<string>(string.Empty);
            DisplayOrder = source("DisplayOrder").value<int>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Task();
        }
    }
}