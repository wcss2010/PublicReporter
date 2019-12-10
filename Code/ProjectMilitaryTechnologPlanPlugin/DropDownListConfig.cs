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
        /// 行分割符
        /// </summary>
        public const string rowFlag = "{{(<<rows>>)}}";

        /// <summary>
        /// 单元格分割符
        /// </summary>
        public const string cellFlag = "{{(<<cells>>)}}";

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
            ConfigObj.Params.Add("预期成果项目", new string[] { "著作(本)", "综合报告(份)", "分报告(份)", "学术论文(篇)", "作战想定(份)", "工具手册(本)", "译著(本)", "标准规范(套)", "需求清单(套)", "思维导图集(套)", "专利(项)", "软件系统(套)", "分析算法(套)", "数据库(套)", "资料整编(份)" });
            ConfigObj.Params.Add("研究周期", new string[] { "6个月" + rowFlag + "6", "12个月" + rowFlag + "12", "18个月" + rowFlag + "18", "24个月" + rowFlag + "24", "36个月" + rowFlag + "36" });
            ConfigObj.Params.Add("项目类别", new string[] { "重大学术研究" + rowFlag + "[100,180]" + rowFlag + "[5,10]", "重点学术研究" + rowFlag + "[90,150]" + rowFlag + "[3,7]", "能力建设" + rowFlag + "[100,180]" + rowFlag + "[5,10]", "专题活动" + rowFlag + "[100,180]" + rowFlag + "[5,10]" });
            ConfigObj.Params.Add("责任单位", new string[] { "东部战区", "南部战区", "西部战区", "北部战区", "中部战区", "陆军", "海军", "空军", "火箭军", "战略支援部队", "联勤保障部队", "军委办公厅", "军委联合参谋部", "军委政治工作部", "军委后勤保障部", "军委装备发展部", "军委训练管理部", "军委国防动员部", "军委纪律检察委员会", "军委政法委员会", "军委科学技术委员会", "军委战略规划办公室", "军委改革和编制办公室", "军委国际军事合作办公室", "军委审计署", "军委机关事务管理总局", "军事科学院", "国防大学", "国防科技大学", "武装警察部队" });
            ConfigObj.Params.Add("备注", new string[] { "强敌研究", "高级指挥员领衔项目", "跨大单位联合研究", "军地联合研究", "其他" });
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