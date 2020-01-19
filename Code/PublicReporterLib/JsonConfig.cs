using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PublicReporterLib
{
    /// <summary>
    /// Json配置文件类
    /// </summary>
    public class JsonConfig
    {
        /// <summary>
        /// 配置文件初始化工具
        /// </summary>
        public static IJsonConfigInitTool JsonConfigInitTool = null;

        /// <summary>
        /// 行分割符
        /// </summary>
        public const string rowFlag = "{(<r>)}";

        /// <summary>
        /// 单元格分割符
        /// </summary>
        public const string cellFlag = "{(<c>)}";

        /// <summary>
        /// 配置
        /// </summary>
        public static JsonConfig Config { get; set; }

        private SerialDictionary<string, string> stringDict = new SerialDictionary<string, string>();
        /// <summary>
        /// 字符数据字典
        /// </summary>
        public SerialDictionary<string, string> StringDict
        {
            get { return stringDict; }
        }

        private SerialDictionary<string, object> objectDict = new SerialDictionary<string, object>();
        /// <summary>
        /// 对象数据字典
        /// </summary>
        public SerialDictionary<string, object> ObjectDict
        {
            get { return objectDict; }
        }

        /// <summary>
        /// 载入配置
        /// </summary>
        public static void loadConfig(string configFile)
        {
            try
            {
                //检查是不是存在配置文件
                if (File.Exists(configFile))
                {
                    //读取配置文件
                    Config = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonConfig>(File.ReadAllText(configFile));
                }
                else
                {
                    //初始化
                    initConfig(configFile);
                }
            }
            catch (Exception ex)
            {
                //初始化
                initConfig(configFile);
            }
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        public static void initConfig(string configFile)
        {
            Config = new JsonConfig();

            //初始化配置
            if (JsonConfigInitTool != null)
            {
                JsonConfigInitTool.initConfig(Config);
            }

            //保存初始化内容
            saveConfig(configFile);

            //重新加载一次
            loadConfig(configFile);
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void saveConfig(string configFile)
        {
            string cnt = Newtonsoft.Json.JsonConvert.SerializeObject(Config, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(configFile, cnt);
        }
    }

    /// <summary>
    /// 配置文件初始化
    /// </summary>
    public interface IJsonConfigInitTool
    {
        void initConfig(JsonConfig config);
    }
}