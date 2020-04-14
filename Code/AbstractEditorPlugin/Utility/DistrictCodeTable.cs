using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractEditorPlugin.Utility
{
    public class DistrictCodeTable
    {
        /// <summary>
        /// 地区代码表(默认为空，需初始化：简称、全称)
        /// </summary>
        public Dictionary<string, string> m_DistrictTB = new Dictionary<string, string>();

        /// <summary>
        /// 初始化：地区代码：简称
        /// </summary>
        public void InitDistrictTable_Short()
        {
            m_DistrictTB.Clear();
            //11-15 京、津、冀、晋、蒙
            m_DistrictTB.Add("11", "京");
            m_DistrictTB.Add("12", "津");
            m_DistrictTB.Add("13", "冀");
            m_DistrictTB.Add("14", "晋");
            m_DistrictTB.Add("15", "蒙");
            //21-23 辽、吉、黑
            m_DistrictTB.Add("21", "辽");
            m_DistrictTB.Add("22", "吉");
            m_DistrictTB.Add("23", "黑");
            //31-37 沪、苏、浙、皖、闽、赣、鲁
            m_DistrictTB.Add("31", "沪");
            m_DistrictTB.Add("32", "苏");
            m_DistrictTB.Add("33", "浙");
            m_DistrictTB.Add("34", "皖");
            m_DistrictTB.Add("35", "闽");
            m_DistrictTB.Add("36", "赣");
            m_DistrictTB.Add("37", "鲁");
            //41-46 豫、鄂、湘、粤、桂、琼
            m_DistrictTB.Add("41", "豫");
            m_DistrictTB.Add("42", "鄂");
            m_DistrictTB.Add("43", "湘");
            m_DistrictTB.Add("44", "粤");
            m_DistrictTB.Add("45", "桂");
            m_DistrictTB.Add("46", "琼");
            //50-54 渝、川、贵、云、藏
            m_DistrictTB.Add("50", "渝");
            m_DistrictTB.Add("51", "川");
            m_DistrictTB.Add("52", "贵");
            m_DistrictTB.Add("53", "云");
            m_DistrictTB.Add("54", "藏");
            //61-65 陕、甘、青、宁、新
            m_DistrictTB.Add("61", "陕");
            m_DistrictTB.Add("62", "甘");
            m_DistrictTB.Add("63", "青");
            m_DistrictTB.Add("64", "宁");
            m_DistrictTB.Add("65", "新");
            //71 台湾
            m_DistrictTB.Add("71", "台");
            //81-82 港、澳
            m_DistrictTB.Add("81", "港");
            m_DistrictTB.Add("82", "澳");
            //91 国外
            m_DistrictTB.Add("91", "外");
        }

        /// <summary>
        /// 初始化：地区代码：全称
        /// </summary>
        public void InitDistrictTable_Full()
        {
            m_DistrictTB.Clear();
            //11-15 京、津、冀、晋、蒙
            m_DistrictTB.Add("11", "北京");
            m_DistrictTB.Add("12", "天津");
            m_DistrictTB.Add("13", "河北");
            m_DistrictTB.Add("14", "山西");
            m_DistrictTB.Add("15", "内蒙古");
            //21-23 辽、吉、黑
            m_DistrictTB.Add("21", "辽宁");
            m_DistrictTB.Add("22", "吉林");
            m_DistrictTB.Add("23", "黑龙江");
            //31-37 沪、苏、浙、皖、闽、赣、鲁
            m_DistrictTB.Add("31", "上海");
            m_DistrictTB.Add("32", "江苏");
            m_DistrictTB.Add("33", "浙江");
            m_DistrictTB.Add("34", "安徽");
            m_DistrictTB.Add("35", "福建");
            m_DistrictTB.Add("36", "江西");
            m_DistrictTB.Add("37", "山东");
            //41-46 豫、鄂、湘、粤、桂、琼
            m_DistrictTB.Add("41", "河南");
            m_DistrictTB.Add("42", "湖北");
            m_DistrictTB.Add("43", "湖南");
            m_DistrictTB.Add("44", "广东");
            m_DistrictTB.Add("45", "广西");
            m_DistrictTB.Add("46", "海南");
            //50-54 渝、川、贵、云、藏
            m_DistrictTB.Add("50", "重庆");
            m_DistrictTB.Add("51", "四川");
            m_DistrictTB.Add("52", "贵州");
            m_DistrictTB.Add("53", "云南");
            m_DistrictTB.Add("54", "西藏");
            //61-65 陕、甘、青、宁、新
            m_DistrictTB.Add("61", "陕西");
            m_DistrictTB.Add("62", "甘肃");
            m_DistrictTB.Add("63", "青海");
            m_DistrictTB.Add("64", "宁夏");
            m_DistrictTB.Add("65", "新疆");
            //71 台湾
            m_DistrictTB.Add("71", "台湾");
            //81-82 港、澳
            m_DistrictTB.Add("81", "香港");
            m_DistrictTB.Add("82", "澳门");
            //91 国外
            m_DistrictTB.Add("91", "国外");
        }

        /// <summary>
        /// 地区代码返回结果类型：Full(全称)、Short(简称)
        /// </summary>
        public enum DistrictResultType
        {
            /// <summary>
            /// 全称
            /// </summary>
            Full,
            /// <summary>
            /// 简称
            /// </summary>
            Short
        }

        /// <summary>
        /// 通过两位地区码得到对应的地区名称
        /// </summary>
        /// <param name="code">两位地区码</param>
        /// <param name="resType">返回类型：Full(全称)、Short(简称)</param>
        /// <returns>对应的地区名称</returns>
        public string GetDistrictCode(string code, int resType)
        {
            try
            {
                string codeStr = "错误地区";
                if (code.Length == 2)
                {
                    //初始化：全称
                    if (resType == (int)DistrictResultType.Full)
                    {
                        InitDistrictTable_Full();
                    }
                    //初始化：简称
                    if (resType == (int)DistrictResultType.Short)
                    {
                        InitDistrictTable_Short();
                    }
                    //获取对应键值的结果
                    if (m_DistrictTB.ContainsKey(code))
                    {
                        codeStr = m_DistrictTB[code].ToString();
                    }
                }
                return codeStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}