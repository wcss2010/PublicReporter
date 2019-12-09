using SuperCodeFactoryLib.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectMilitaryTechnologPlanPlugin
{
    public class UIControlConfig
    {
        /// <summary>
        /// 配置文件
        /// </summary>
        public static string configFile = "";

        /// <summary>
        /// 配置数据
        /// </summary>
        public static UIControlConfig ConfigObj { get; set; }

        public UIControlConfig()
        {
            Params = new SerialDictionary<string, object>();
        }

        /// <summary>
        /// 参数配置
        /// </summary>
        public SerialDictionary<string, object> Params { get; set; }

        /// <summary>
        /// 载入
        /// </summary>
        public static void loadConfig()
        {
            if (File.Exists(configFile))
            {
                ConfigObj = Newtonsoft.Json.JsonConvert.DeserializeObject<UIControlConfig>(File.ReadAllText(configFile));
            }
            else
            {
                ConfigObj = new UIControlConfig();
                setDefaultConfig();
                saveConfig();
            }
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        private static void setDefaultConfig()
        {
            
        }

        /// <summary>
        /// 保存
        /// </summary>
        public static void saveConfig()
        {
            Newtonsoft.Json.JsonSerializerSettings jss = new Newtonsoft.Json.JsonSerializerSettings();
            jss.Formatting = Newtonsoft.Json.Formatting.Indented;
            File.WriteAllText(configFile, Newtonsoft.Json.JsonConvert.SerializeObject(ConfigObj, typeof(UIControlConfig), jss));
        }
    }
}