using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PublicReporterLib
{
    public class PluginConfig
    {
        /// <summary>
        /// 当前配置
        /// </summary>
        public static PluginConfig CurrentConfig { get; set; }

        /// <summary>
        /// 插件名称(目录名)
        /// </summary>
        public string PluginName { get; set; }

        private SerialDictionary<string, object> dataDict = new SerialDictionary<string, object>();
        /// <summary>
        /// 数据字典
        /// </summary>
        public SerialDictionary<string, object> DataDict
        {
            get { return dataDict; }
        }

        /// <summary>
        /// 载入配置
        /// </summary>
        public static void loadConfig()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
            if (File.Exists(dir))
            {
                try
                {
                    CurrentConfig = SuperCodeFactoryLib.Utilities.XmlSerializeUtil.Deserialize<PluginConfig>(dir);
                }
                catch (Exception ex)
                {
                    initConfig();
                }
            }
            else
            {
                initConfig();
            }
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        private static void initConfig()
        {
            //初始化配置
            CurrentConfig = new PluginConfig();
            CurrentConfig.PluginName = "--插件目录名称--";

            //保存配置
            saveConfig();
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void saveConfig()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
            if (CurrentConfig != null)
            {
                string txt = SuperCodeFactoryLib.Utilities.XmlSerializeUtil.Serializer<PluginConfig>(CurrentConfig);
                File.WriteAllText(dir, txt);
            }
        }
    }
}