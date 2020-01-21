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
        /// 配置
        /// </summary>
        public static JsonConfigObject Config { get; set; }

        /// <summary>
        /// 载入配置
        /// </summary>
        public static void loadConfig(string configFile)
        {
            try
            {
                Config = JsonConfigObject.loadConfig(configFile);
                if (Config == null)
                {
                    //加载失败，初始化配置文件
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
            //创建Config对象
            Config = new JsonConfigObject();

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
            JsonConfigObject.saveConfig(configFile, Config);
        }
    }

    /// <summary>
    /// 配置文件初始化
    /// </summary>
    public interface IJsonConfigInitTool
    {
        void initConfig(JsonConfigObject config);
    }

    /// <summary>
    /// 配置文件类
    /// </summary>
    public class JsonConfigObject
    {
        /// <summary>
        /// 行分割符
        /// </summary>
        public const string rowFlag = "{(<r>)}";

        /// <summary>
        /// 单元格分割符
        /// </summary>
        public const string cellFlag = "{(<c>)}";

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
        /// 从ObjectDict获得数据并进行序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public T deserializeObjectFromObjectDict<T>(string keys)
        {
            T result = default(T);
            
            if (ObjectDict.ContainsKey(keys))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(ObjectDict[keys].ToString());
            }

            return result;
        }

        /// <summary>
        /// 载入配置
        /// </summary>
        public static JsonConfigObject loadConfig(string configFile)
        {
            JsonConfigObject configObj = null;

            try
            {
                //检查是不是存在配置文件
                if (File.Exists(configFile))
                {
                    //读取配置文件
                    configObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonConfigObject>(File.ReadAllText(configFile));
                }
                else
                {
                    configObj = null;
                }
            }
            catch (Exception ex)
            {
                configObj = null;
            }

            return configObj;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void saveConfig(string configFile, JsonConfigObject configObj)
        {
            string cnt = Newtonsoft.Json.JsonConvert.SerializeObject(configObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(configFile, cnt);
        }
    }
}