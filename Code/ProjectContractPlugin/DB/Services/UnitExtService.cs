using System;
using System.Collections.Generic;
using System.Text;
using ProjectContractPlugin.DB.Entitys;

namespace ProjectContractPlugin.DB.Services
{
    public class UnitExtService
    {
        public IList<UnitExt> GetUnitInforList()
        {
            return ConnectionManager.Context.table("UnitExt").select("*").getList<UnitExt>(new UnitExt());
        }

        public IList<UnitExt> GetUnitInforList(string[] idList)
        {
            List<UnitExt> results = new List<UnitExt>();
            foreach (string id in idList)
            {
                var uu = ConnectionManager.Context.table("UnitExt").where("ID='" + id + "'").select("*").getItem<UnitExt>(new UnitExt());
                if (uu != null)
                {
                    results.Add(uu);
                }
            }
            return results;
        }

        public bool UpdateUnitInfors(IList<UnitExt> list)
        {
            foreach (UnitExt current in list)
            {
                if (string.IsNullOrEmpty(current.ID))
                {
                    current.ID = Guid.NewGuid().ToString();
                    current.copyTo(ConnectionManager.Context.table("UnitExt")).insert();
                }
                else
                {
                    current.copyTo(ConnectionManager.Context.table("UnitExt").where("ID='" + current.ID + "'")).update();
                }
            }
            return true;
        }

        public bool DeleteUnitInfors(IList<string> list)
        {
            foreach (string current in list)
            {
                ConnectionManager.Context.table("UnitExt").where("ID='" + current + "'").delete();
            }
            return true;
        }
    }
}