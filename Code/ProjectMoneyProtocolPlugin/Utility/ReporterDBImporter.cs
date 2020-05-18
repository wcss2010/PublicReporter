using Noear.Weed;
using ProjectContractPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Utility
{
    public class ReporterDBImporter
    {
        public static bool import(string zipFile, Noear.Weed.DbContext context, NewPluginRoot pluginObj)
        {
            try
            {
                //创建一个新工程
                string projectGuid = Guid.NewGuid().ToString();

                //建议书DB文件
                string reporterDBFile = string.Empty;

                #region 解压数据库
                string localAppDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string decompressDir = Path.Combine(localAppDir, projectGuid + "-" + DateTime.Now.Ticks);
                try
                {
                    Directory.CreateDirectory(decompressDir);
                }
                catch (Exception ex) { }
                reporterDBFile = Path.Combine(decompressDir, "static.db");
                new PublicReporterLib.Utility.ZipUtil().UnZipFile(zipFile, decompressDir, string.Empty, true);
                #endregion

                if (File.Exists(reporterDBFile))
                {
                    //项目或课题表
                    DataList dlProject = getDataList(reporterDBFile, "Project", string.Empty);
                    //金额表
                    DataList dlMoneyAndYear = getDataList(reporterDBFile, "MoneyAndYear", string.Empty);
                    //任务表
                    DataList dlTask = getDataList(reporterDBFile, "Task", string.Empty);

                    try
                    {
                        JiBenXinXiBiao projectItem = context.table("JiBenXinXiBiao").select("*").getItem<JiBenXinXiBiao>(new JiBenXinXiBiao());

                        #region 清空所有数据
                        context.table("JiBenXinXiBiao").delete();
                        context.table("KeTiBiao").delete();
                        context.table("KeTiJingFeiNianDuBiao").delete();
                        context.table("KeTiYuSuanBiao").delete();
                        context.table("RenYuanBiao").delete();
                        context.table("YuSuanBiao").delete();
                        context.table("RenWuBiao").delete();
                        context.table("KeTiJieDianJingFeiBiao").delete();
                        #endregion

                        DataItem diProject = null;
                        string projectID = string.Empty;
                        string projectUnitID = string.Empty;
                        foreach (DataItem di in dlProject.getRows())
                        {
                            string parentID = di.get("ParentID") != null ? di.get("ParentID").ToString() : string.Empty;
                            if (string.IsNullOrEmpty(parentID))
                            {
                                projectID = di.get("ID") != null ? di.get("ID").ToString() : string.Empty;
                                projectUnitID = di.get("UnitID") != null ? di.get("UnitID").ToString() : string.Empty;

                                diProject = di;
                                break;
                            }
                        }

                        //插入项目数据                        
                        projectItem.BianHao = projectGuid;
                        projectItem.HeTongMingCheng = diProject.get("Name") != null ? diProject.get("Name").ToString() : string.Empty;
                        projectItem.HeTongMiJi = diProject.get("SecretLevel") != null ? diProject.get("SecretLevel").ToString() : "公开";
                        projectItem.HeTongMiQi = 0;
                        projectItem.HeTongKaiShiShiJian = DateTime.Now;
                        projectItem.HeTongJieShuShiJian = DateTime.Now;
                        projectItem.HeTongSuoShuLingYu = getValueWithDefault<string>(diProject.get("Domain"), string.Empty);

                        DataItem diProjectMaster = getDataItem(reporterDBFile, "Person", "ID in (select PersonID from task where Role='负责人' and Type='项目' and ProjectID = '" + projectID + "')");
                        projectItem.HeTongFuZeRen = diProjectMaster.get("Name") != null ? diProjectMaster.get("Name").ToString() : string.Empty;
                        projectItem.HeTongFuZeRenShenFenZheng = diProjectMaster.get("IDCard") != null ? diProjectMaster.get("IDCard").ToString() : string.Empty;
                        projectItem.HeTongFuZeRenDianHua = diProjectMaster.get("Telephone") != null ? diProjectMaster.get("Telephone").ToString() : string.Empty;

                        projectItem.HeTongJiaKuan = decimal.Parse(diProject.get("TotalMoney") != null ? diProject.get("TotalMoney").ToString() : "0");

                        DataItem diProjectUnit = getDataItem(reporterDBFile, "Unit", "ID = '" + projectUnitID + "'");
                        projectItem.HeTongFuZeDanWei = diProjectUnit.get("UnitName") != null ? diProjectUnit.get("UnitName").ToString() : string.Empty;
                        projectItem.HeTongFuZeDanWeiChangYongMingCheng = diProjectUnit.get("NormalName") != null ? diProjectUnit.get("NormalName").ToString() : string.Empty;
                        projectItem.HeTongFuZeDanWeiTongXunDiZhi = diProjectUnit.get("Address") != null ? diProjectUnit.get("Address").ToString() : string.Empty;
                        projectItem.HeTongFuZeDanWeiLianXiRen = diProjectUnit.get("ContactName") != null ? diProjectUnit.get("ContactName").ToString() : string.Empty;
                        projectItem.HeTongFuZeDanWeiLianXiRenDianHua = diProjectUnit.get("Telephone") != null ? diProjectUnit.get("Telephone").ToString() : string.Empty;

                        projectItem.HeTongGuanJianZi = diProject.get("Keywords") != null ? diProject.get("Keywords").ToString() : string.Empty;
                        projectItem.copyTo(context.table("JiBenXinXiBiao")).insert();

                        //插入课题数据
                        foreach (DataItem di in dlProject.getRows())
                        {
                            string subParentID = di.get("ParentID") != null ? di.get("ParentID").ToString() : string.Empty;
                            if (string.IsNullOrEmpty(subParentID))
                            {
                                continue;
                            }
                            else
                            {
                                string subjectID = di.get("ID") != null ? di.get("ID").ToString() : string.Empty;
                                string subjectUnitID = di.get("UnitID") != null ? di.get("UnitID").ToString() : string.Empty;

                                KeTiBiao keTiBiao = new KeTiBiao();
                                keTiBiao.BianHao = di.get("ID") != null ? di.get("ID").ToString() : string.Empty;
                                keTiBiao.KeTiMingCheng = di.get("Name") != null ? di.get("Name").ToString() : string.Empty;
                                //keTiBiao.KeTiBaoMiDengJi = di.get("") != null ? di.get("").ToString() : string.Empty;
                                keTiBiao.KeTiFuZeDanWei = getDataValue<string>(reporterDBFile, "Unit", "ID='" + di.get("UnitID") + "'", "UnitName", "未知");
                                keTiBiao.copyTo(context.table("KeTiBiao")).insert();
                            }
                        }

                        //插入人员数据
                        int displayOrder = 0;
                        //项目角色
                        List<DataItem> ignoreList = new List<DataItem>();
                        foreach (DataItem diTask in dlTask.getRows())
                        {
                            DataItem diPerson = getDataItem(reporterDBFile, "Person", "ID = '" + diTask.get("PersonID") + "'");
                            if (diPerson != null && diPerson.count() >= 1)
                            {
                                string ktPID = getValueWithDefault<string>(diTask.get("ProjectID"), string.Empty);

                                displayOrder++;
                                RenYuanBiao obj = new RenYuanBiao();
                                obj.BianHao = Guid.NewGuid().ToString();
                                obj.ZhuangTai = displayOrder;                                
                                
                                obj.XingMing = getValueWithDefault<string>(diPerson.get("Name"), string.Empty);
                                obj.ShenFenZhengHao = getValueWithDefault<string>(diPerson.get("IDCard"), string.Empty);
                                obj.XingBie = getValueWithDefault<string>(diPerson.get("Sex"), string.Empty);
                                obj.ZhiCheng = getValueWithDefault<string>(diPerson.get("Job"), string.Empty);
                                obj.ZhuanYe = getValueWithDefault<string>(diPerson.get("Specialty"), string.Empty);
                                obj.MeiNianTouRuShiJian = diTask.getInt("TotalTime");
                                obj.RenWuFenGong = getValueWithDefault<string>(diTask.get("Content"), string.Empty);
                                obj.DianHua = getValueWithDefault<string>(diPerson.get("Telephone"), string.Empty);
                                obj.ShouJi = getValueWithDefault<string>(diPerson.get("MobilePhone"), string.Empty);
                                obj.ShengRi = DateTime.Parse(getValueWithDefault<string>(diPerson.get("Birthday"), DateTime.Now.ToString()));

                                DataItem diUnit = getDataItem(reporterDBFile, "Unit", "ID='" + diPerson.get("UnitID") + "'");
                                if (diUnit != null && diUnit.count() >= 1)
                                {
                                    obj.GongZuoDanWei = getValueWithDefault<string>(diUnit.get("UnitName"), string.Empty);
                                }
                                else
                                {
                                    obj.GongZuoDanWei = "未知";
                                }

                                //设置项目中职务
                                obj.ZhiWu = getValueWithDefault<string>(diTask.get("Role"), string.Empty);

                                //是否为项目负责人
                                if (ktPID == projectID)
                                {
                                    ignoreList.Add(diTask);

                                    //仅为项目负责人
                                    obj.ShiXiangMuFuZeRen = "rbIsOnlyProject";

                                    //插入数据
                                    obj.copyTo(context.table("RenYuanBiao")).insert();
                                }
                            }
                        }
                        //课题角色
                        foreach (DataItem diTask in dlTask.getRows())
                        {
                            if (ignoreList.Contains(diTask))
                            {
                                continue;
                            }

                            DataItem diPerson = getDataItem(reporterDBFile, "Person", "ID = '" + diTask.get("PersonID") + "'");
                            if (diPerson != null && diPerson.count() >= 1)
                            {
                                if (diTask.get("Type").ToString() == "项目")
                                {
                                    continue;
                                }

                                displayOrder++;
                                RenYuanBiao obj = new RenYuanBiao();
                                obj.BianHao = Guid.NewGuid().ToString();
                                obj.ZhuangTai = displayOrder;

                                obj.KeTiBiaoHao = getValueWithDefault<string>(diTask.get("ProjectID"), string.Empty);
                                obj.XingMing = getValueWithDefault<string>(diPerson.get("Name"), string.Empty);
                                obj.ShenFenZhengHao = getValueWithDefault<string>(diPerson.get("IDCard"), string.Empty);
                                obj.XingBie = getValueWithDefault<string>(diPerson.get("Sex"), string.Empty);
                                obj.ZhiCheng = getValueWithDefault<string>(diPerson.get("Job"), string.Empty);
                                obj.ZhuanYe = getValueWithDefault<string>(diPerson.get("Specialty"), string.Empty);
                                obj.MeiNianTouRuShiJian = diTask.getInt("TotalTime");
                                obj.RenWuFenGong = getValueWithDefault<string>(diTask.get("Content"), string.Empty);
                                obj.DianHua = getValueWithDefault<string>(diPerson.get("Telephone"), string.Empty);
                                obj.ShouJi = getValueWithDefault<string>(diPerson.get("MobilePhone"), string.Empty);
                                obj.ShengRi = DateTime.Parse(getValueWithDefault<string>(diPerson.get("Birthday"), DateTime.Now.ToString()));

                                DataItem diUnit = getDataItem(reporterDBFile, "Unit", "ID='" + diPerson.get("UnitID") + "'");
                                if (diUnit != null && diUnit.count() >= 1)
                                {
                                    obj.GongZuoDanWei = getValueWithDefault<string>(diUnit.get("UnitName"), string.Empty);
                                }
                                else
                                {
                                    obj.GongZuoDanWei = "未知";
                                }

                                //设置项目中职务
                                obj.ZhiWu = getValueWithDefault<string>(diTask.get("Role"), string.Empty);

                                //是否为项目负责人
                                obj.ShiXiangMuFuZeRen = "rbIsOnlySubject";

                                //插入数据
                                obj.copyTo(context.table("RenYuanBiao")).insert();
                            }
                        }

                        //插入经费数据
                        if (dlMoneyAndYear != null && dlMoneyAndYear.getRowCount() >= 1)
                        {
                            //关键字映射表
                            Dictionary<string, string> nameDicts = new Dictionary<string, string>();
                            nameDicts["ProjectRFA"] = "Money1";
                            nameDicts["ProjectRFA1"] = "Money2";
                            nameDicts["ProjectRFA1_1"] = "Money3";
                            nameDicts["ProjectRFA1_1_1"] = "Money3_1";
                            nameDicts["ProjectRFA1_1_2"] = "Money3_2";
                            nameDicts["ProjectRFA1_1_3"] = "Money3_3";
                            nameDicts["ProjectRFA1_2"] = "Money4";
                            nameDicts["ProjectRFA1_3"] = "Money5";
                            nameDicts["ProjectRFA1_3_1"] = "Money5_1";
                            nameDicts["ProjectRFA1_3_2"] = "Money5_2";
                            nameDicts["ProjectRFA1_4"] = "Money6";
                            nameDicts["ProjectRFA1_5"] = "Money7";
                            nameDicts["ProjectRFA1_6"] = "Money8";
                            nameDicts["ProjectRFA1_7"] = "Money9";
                            nameDicts["ProjectRFA1_8"] = "Money10";
                            nameDicts["ProjectRFA1_9"] = "Money11";
                            nameDicts["ProjectRFA2"] = "Money12";
                            nameDicts["ProjectRFA2_1"] = "Money13";
                            nameDicts["Projectoutlay1"] = "Year1";
                            nameDicts["Projectoutlay2"] = "Year2";
                            nameDicts["Projectoutlay3"] = "Year3";
                            nameDicts["Projectoutlay4"] = "Year4";
                            nameDicts["Projectoutlay5"] = "Year5";
                            nameDicts["ProjectRFArm"] = "Info1";
                            nameDicts["ProjectRFA1rm"] = "Info2";
                            nameDicts["ProjectRFA1_1rm"] = "Info3";
                            nameDicts["ProjectRFA1_1_1rm"] = "Info3_1";
                            nameDicts["ProjectRFA1_1_2rm"] = "Info3_2";
                            nameDicts["ProjectRFA1_1_3rm"] = "Info3_3";
                            nameDicts["ProjectRFA1_2rm"] = "Info4";
                            nameDicts["ProjectRFA1_3rm"] = "Info5";
                            nameDicts["ProjectRFA1_3_1rm"] = "Info5_1";
                            nameDicts["ProjectRFA1_3_2rm"] = "Info5_2";
                            nameDicts["ProjectRFA1_4rm"] = "Info6";
                            nameDicts["ProjectRFA1_5rm"] = "Info7";
                            nameDicts["ProjectRFA1_6rm"] = "Info8";
                            nameDicts["ProjectRFA1_7rm"] = "Info9";
                            nameDicts["ProjectRFA1_8rm"] = "Info10";
                            nameDicts["ProjectRFA1_9rm"] = "Info11";
                            nameDicts["ProjectRFA2rm"] = "Info12";
                            nameDicts["ProjectRFA2_1rm"] = "Info13";

                            foreach (DataItem di in dlMoneyAndYear.getRows())
                            {
                                try
                                {
                                    YuSuanBiao ysb = new YuSuanBiao();
                                    ysb.BianHao = Guid.NewGuid().ToString();
                                    ysb.MingCheng = nameDicts[getValueWithDefault<string>(di.get("Name"), string.Empty)];
                                    ysb.ShuJu = getValueWithDefault<string>(di.get("Value"), string.Empty);

                                    ysb.copyTo(context.table("YuSuanBiao")).insert();
                                }
                                catch (Exception ex) { }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("对不起，导入失败！Ex:" + ex.ToString());
            }

            return true;
        }

        /// <summary>
        /// 获得文件中的数据表
        /// </summary>
        /// <param name="reporterDBFile"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private static DataList getDataList(string reporterDBFile, string table, string where)
        {
            //SQLite数据库工厂
            System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();
            //NDEY数据库连接
            Noear.Weed.DbContext context = new Noear.Weed.DbContext("main", "Data Source = " + reporterDBFile, factory);
            //是否在执入后执行查询（主要针对Sqlite）
            context.IsSupportSelectIdentityAfterInsert = false;
            //是否在Dispose后执行GC用于解决Dispose后无法删除的问题（主要针对Sqlite）
            context.IsSupportGCAfterDispose = true;

            try
            {
                if (string.IsNullOrEmpty(where))
                {
                    return context.table(table).select("*").getDataList();
                }
                else
                {
                    return context.table(table).where(where).select("*").getDataList();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                factory.Dispose();
                context.Dispose();
            }
        }

        /// <summary>
        /// 获得文件中的数据项
        /// </summary>
        /// <param name="reporterDBFile"></param>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        private static DataItem getDataItem(string reporterDBFile, string table, string where)
        {
            //SQLite数据库工厂
            System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();
            //NDEY数据库连接
            Noear.Weed.DbContext context = new Noear.Weed.DbContext("main", "Data Source = " + reporterDBFile, factory);
            //是否在执入后执行查询（主要针对Sqlite）
            context.IsSupportSelectIdentityAfterInsert = false;
            //是否在Dispose后执行GC用于解决Dispose后无法删除的问题（主要针对Sqlite）
            context.IsSupportGCAfterDispose = true;

            try
            {
                if (string.IsNullOrEmpty(where))
                {
                    return context.table(table).select("*").getDataItem();
                }
                else
                {
                    return context.table(table).where(where).select("*").getDataItem();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                factory.Dispose();
                context.Dispose();
            }
        }

        /// <summary>
        /// 获得文件中的数据值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reporterDBFile"></param>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static T getDataValue<T>(string reporterDBFile, string table, string where, string fieldName, T defaultValue)
        {
            //SQLite数据库工厂
            System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();
            //NDEY数据库连接
            Noear.Weed.DbContext context = new Noear.Weed.DbContext("main", "Data Source = " + reporterDBFile, factory);
            //是否在执入后执行查询（主要针对Sqlite）
            context.IsSupportSelectIdentityAfterInsert = false;
            //是否在Dispose后执行GC用于解决Dispose后无法删除的问题（主要针对Sqlite）
            context.IsSupportGCAfterDispose = true;

            try
            {
                if (string.IsNullOrEmpty(where))
                {
                    return context.table(table).select(fieldName).getValue<T>(defaultValue);
                }
                else
                {
                    return context.table(table).where(where).select(fieldName).getValue<T>(defaultValue);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return default(T);
            }
            finally
            {
                factory.Dispose();
                context.Dispose();
            }
        }

        /// <summary>
        /// 如果值为空，则使用初始值
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultString"></param>
        /// <returns></returns>
        private static T getValueWithDefault<T>(object val, T defaultVal)
        {
            return val != null ? (T)Convert.ChangeType(val.ToString(), typeof(T)) : defaultVal;
        }
    }
}