using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace PublicReporterLib
{
    /// <summary>
    /// 插件载入类
    /// </summary>
    public class PluginLoader
    {
        /// <summary>
        /// 当前插件
        /// </summary>
        public static IReportPluginRoot CurrentPlugin { get; set; }

        /// <summary>
        /// 在指定目录查找并加载插件
        /// </summary>
        /// <param name="dir"></param>
        public static void searchAndLoadPlugin(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                return;
            }

            //判断是否需要停止先前的插件
            if (CurrentPlugin != null)
            {
                CurrentPlugin.stop(null);
                CurrentPlugin = null;
            }

            //判断目录是否存在
            if (Directory.Exists(dir))
            {
                string[] filess = Directory.GetFiles(dir);
                foreach (string sFile in filess)
                {
                    if (sFile.ToLower().EndsWith("dll"))
                    {
                        try
                        {
                            //加载DLL文件
                            Assembly asmm = Assembly.LoadFile(sFile);
                            if (asmm != null)
                            {
                                //获得所有类
                                Type[] tList= asmm.GetTypes();

                                //查找启动类
                                foreach (Type t in tList)
                                {
                                    //判断是否为启动类
                                    if (t.BaseType != null && t.BaseType.FullName.Equals(typeof(IReportPluginRoot).FullName))
                                    {
                                        //调用默认构造器实例化
                                        ConstructorInfo ci = t.GetConstructors()[0];
                                        CurrentPlugin = (IReportPluginRoot)ci.Invoke(null);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}