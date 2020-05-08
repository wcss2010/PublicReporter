using AbstractEditorPlugin.Utility;
using Noear.Weed;
using ProjectContractPlugin.DB.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ProjectContractPlugin.Utility
{
    public class OldContactDBImporter
    {
        private static Dictionary<string, Dictionary<string, PropertyInfo>> entityDict = new Dictionary<string, Dictionary<string, PropertyInfo>>();

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
                    #region 复制Files目录
                    string sourceFilesDir = Path.Combine(Path.GetDirectoryName(reporterDBFile), "Files");
                    try
                    {
                        Directory.Delete(pluginObj.filesDir, true);
                    }
                    catch (Exception ex) { }
                    try
                    {
                        FileOp.copyDirectory(sourceFilesDir, pluginObj.filesDir, true);
                    }
                    catch (Exception ex) { }
                    #endregion

                    #region 复制PDFFile
                    string sourcePDFFile = Path.Combine(Path.GetDirectoryName(reporterDBFile), "合同书.pdf");
                    try
                    {
                        File.Copy(sourcePDFFile, Path.Combine(pluginObj.dataDir, "合同书.pdf"), true);
                    }
                    catch (Exception ex) { }
                    #endregion
                                       
                    try
                    {
                        #region 处理项目信息
                        //提取当前项目的基本信息
                        JiBenXinXiBiao projectItem = context.table("JiBenXinXiBiao").select("*").getItem<JiBenXinXiBiao>(new JiBenXinXiBiao());

                        //填充基本信息数据
                        DataItem diProject = getDataItem(reporterDBFile, "JiBenXinXiBiao", string.Empty);
                        fillToEntity(projectItem, diProject);
                        projectItem.copyTo(context.table("JiBenXinXiBiao")).where("BianHao='" + projectItem.BianHao + "'").update();
                        #endregion

                        #region 类型字典
                        SortedList<string, DB.Entitys.IEntity> typeDict = new SortedList<string, DB.Entitys.IEntity>();
                        typeDict["KeTiBiao"] = new KeTiBiao();
                        typeDict["RenYuanBiao"] = new RenYuanBiao();
                        typeDict["YuSuanBiao"] = new YuSuanBiao();
                        typeDict["RenWuBiao"] = new RenWuBiao();
                        typeDict["BoFuBiao"] = new BoFuBiao();
                        typeDict["JinDuBiao"] = new JinDuBiao();
                        typeDict["RenWuBiao"] = new RenWuBiao();
                        typeDict["TiJiaoYaoQiuBiao"] = new TiJiaoYaoQiuBiao();
                        typeDict["ZhiBiaoBiao"] = new ZhiBiaoBiao();
                        typeDict["ZiDianBiao"] = new ZiDianBiao();
                        typeDict["KeTiJieDianJingFeiBiao"] = new KeTiJieDianJingFeiBiao();
                        typeDict["DanWeiJieDianJingFeiBiao"] = new DanWeiJieDianJingFeiBiao();
                        #endregion

                        //导入其它表的数据
                        foreach (KeyValuePair<string,DB.Entitys.IEntity> kvppp in typeDict)
                        {
                            string tableName = kvppp.Key;

                            try
                            {
                                //读取旧的数据
                                DataList dlData = getDataList(reporterDBFile, tableName, string.Empty);
                                if (dlData.getRowCount() == 0)
                                {
                                    continue;
                                }

                                //清空数据
                                context.table(tableName).delete();

                                //导入数据
                                foreach (DataItem di in dlData.getRows())
                                {
                                    try
                                    {
                                        //生成实体对象
                                        DB.Entitys.IEntity entityObj = (DB.Entitys.IEntity)kvppp.Value.clone();

                                        //填充数据
                                        fillToEntity(entityObj, di);

                                        //插入数据
                                        entityObj.copyTo(context.table(tableName)).insert();
                                    }
                                    catch (Exception ex) { }
                                }
                            }
                            catch (Exception ex) { }
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
        /// 向实体中填充对应的属性值
        /// </summary>
        /// <param name="entityObj"></param>
        /// <param name="dataRecord"></param>
        private static void fillToEntity(object entityObj, DataItem dataRecord)
        {
            Dictionary<string, PropertyInfo> propertyDict = new Dictionary<string, PropertyInfo>();

            #region 取得属性字典
            Type entityType = entityObj.GetType();
            PropertyInfo[] piTeams = entityType.GetProperties();
            
            if (entityDict.ContainsKey(entityType.FullName))
            {
                propertyDict = entityDict[entityType.FullName];
            }
            else
            {
                entityDict[entityType.FullName] = propertyDict;
                foreach (PropertyInfo pi in piTeams)
                {
                    propertyDict[pi.Name] = pi;
                }
            }
            #endregion

            #region 初始化属性
            foreach (KeyValuePair<string, PropertyInfo> kvpppp in propertyDict)
            {
                try
                {
                    string valueType = kvpppp.Value.PropertyType.FullName;
                    if (valueType == typeof(string).FullName)
                    {
                        kvpppp.Value.SetValue(entityObj, string.Empty, null);
                    }
                    else if (valueType == typeof(DateTime).FullName)
                    {
                        kvpppp.Value.SetValue(entityObj, DateTime.Now, null);
                    }
                    else if (valueType == typeof(double).FullName)
                    {
                        kvpppp.Value.SetValue(entityObj, 0d, null);
                    }
                    else if (valueType == typeof(decimal).FullName)
                    {
                        kvpppp.Value.SetValue(entityObj, 0, null);
                    }
                    else if (valueType == typeof(int).FullName)
                    {
                        kvpppp.Value.SetValue(entityObj, 0, null);
                    }
                    else if (valueType == typeof(float).FullName)
                    {
                        kvpppp.Value.SetValue(entityObj, 0, null);
                    }
                    else if (valueType == typeof(long).FullName)
                    {
                        kvpppp.Value.SetValue(entityObj, 0, null);
                    }
                }
                catch (Exception ex) { }
            }
            #endregion

            //属性赋值
            dataRecord.forEach((string cKey, object cVal) =>
            {
                if (propertyDict.ContainsKey(cKey))
                {
                    try
                    {
                        propertyDict[cKey].SetValue(entityObj, cVal, null);
                    }
                    catch (Exception ex) { }
                }
            });
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