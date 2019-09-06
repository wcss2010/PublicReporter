using System;
using System.Collections.Generic;
using System.Text;
using Noear.Weed;

namespace ProjectReporterPlugin.DB.Entitys
{
    /// <summary>
    /// 类UnitExt。
    /// </summary>
    [Serializable]
    public class UnitExt : IEntity
    {
        public UnitExt()
        {

        }

        public override void bind(GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            UnitName = source("UnitName").value<string>(Guid.NewGuid().ToString());
            UnitType = source("UnitType").value<string>(Guid.NewGuid().ToString());
            UnitBankUser = source("UnitBankUser").value<string>(Guid.NewGuid().ToString());
            UnitBankName = source("UnitBankName").value<string>(Guid.NewGuid().ToString());
            UnitBankNo = source("UnitBankNo").value<string>(Guid.NewGuid().ToString());
            IsUserAdded = source("IsUserAdded").value<int>(-1);
        }

        #region Model

        private string _id = string.Empty;
        private string _unitName = string.Empty;
        private string _unitType = string.Empty;
        private string _unitBankUser = string.Empty;
        private string _unitBankName = string.Empty;
        private string _unitBankNo = string.Empty;
        private int _isUserAdded = -1;

        public string ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string UnitName
        {
            get
            {
                return _unitName;
            }

            set
            {
                _unitName = value;
            }
        }

        public string UnitType
        {
            get
            {
                return _unitType;
            }

            set
            {
                _unitType = value;
            }
        }

        public string UnitBankUser
        {
            get
            {
                return _unitBankUser;
            }

            set
            {
                _unitBankUser = value;
            }
        }

        public string UnitBankName
        {
            get
            {
                return _unitBankName;
            }

            set
            {
                _unitBankName = value;
            }
        }

        public string UnitBankNo
        {
            get
            {
                return _unitBankNo;
            }

            set
            {
                _unitBankNo = value;
            }
        }

        public int IsUserAdded
        {
            get
            {
                return _isUserAdded;
            }

            set
            {
                _isUserAdded = value;
            }
        }
        
        #endregion

        public override DbTableQuery copyTo(DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("UnitName", UnitName);
            query.set("UnitType", UnitType);
            query.set("UnitBankUser", UnitBankUser);
            query.set("UnitBankName", UnitBankName);
            query.set("UnitBankNo", UnitBankNo);
            query.set("IsUserAdded", IsUserAdded);

            return query;
        }

        public override IBinder clone()
        {
            return new UnitExt();
        }
    }
}