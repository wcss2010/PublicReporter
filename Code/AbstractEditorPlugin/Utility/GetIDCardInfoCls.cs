using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AbstractEditorPlugin.Utility
{
    public class GetIDCardInfoCls
    {
        //地区代码表
        private DistrictCodeTable m_DistrictCode = new DistrictCodeTable();

        /// <summary>
        /// 分析身份证号，返回：生日、性别、地区(简)、地区(全)
        /// </summary>
        public string[] AnalyzeIDCard(string strIDNum, out bool isOK)
        {
            try
            {
                string[] retInfo = new string[4];
                int strLen = strIDNum.Length;//数据长度

                #region 粗过滤：用正则表达式去校验身份证号的输入
                string rule = string.Empty;
                if (strLen == 15) rule = @"\d{6}\d{2}[0-1]\d[0-3]\d{4}";
                if (strLen == 18) rule = @"\d{6}[1-2]\d{3}[0-1]\d[0-3]\d{4}[0-9X]";
                if (!rule.Equals(string.Empty))
                {
                    System.Text.RegularExpressions.Regex regex = new Regex(rule);
                    isOK = regex.IsMatch(strIDNum);
                }
                else
                {
                    isOK = false;
                }
                #endregion

                #region 细过滤：判断前两位数字是否为正确的地区代码
                if (isOK)
                {
                    string headAB = strIDNum.Substring(0, 2);
                    m_DistrictCode.InitDistrictTable_Short();
                    //若前两位数字在地区代码中不存在，则为假
                    if (!m_DistrictCode.m_DistrictTB.ContainsKey(headAB))
                    {
                        isOK = false;
                    }
                }
                #endregion

                #region 细过滤：出生日期是否可转换
                if (isOK)
                {
                    //更改15位身份证中的日期格式
                    if (strLen == 15) strIDNum = strIDNum.Insert(6, "19");
                    string testBir = strIDNum.Substring(6, 8).Insert(4, "-").Insert(7, "-");
                    DateTime testRes;
                    DateTime.TryParse(testBir, out testRes);
                    //若转换结果为最小值，这说明转换失败
                    if (testRes == DateTime.MinValue)
                    {
                        isOK = false;
                    }
                }
                #endregion

                //基础检查完成后的操作
                if (!isOK)
                {
                    throw new Exception("请输入15位或18位有效身份证号！");
                }
                else
                {
                    retInfo = GetIDCardInfo(strIDNum);
                }
                return retInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取身份证信息
        /// </summary>
        /// <returns>生日、性别、地区(简)、地区(全)</returns>
        private string[] GetIDCardInfo(string IDCardNo)
        {
            try
            {
                string[] info = new string[4];
                int sex = -1;
                //更改15位身份证中的日期格式
                if (IDCardNo.Length == 15) IDCardNo = IDCardNo.Insert(6, "19");
                //info[0]==生日
                info[0] = IDCardNo.Substring(6, 8).Insert(4, "-").Insert(7, "-");
                //info[1]==性别
                sex = int.Parse(IDCardNo.Substring(16, 1));
                info[1] = sex % 2 == 1 ? "男" : "女";
                //info[2]==地区(简)
                info[2] = m_DistrictCode.GetDistrictCode(IDCardNo.Substring(0, 2), (int)DistrictCodeTable.DistrictResultType.Short);
                //info[3]==地区(全)
                info[3] = m_DistrictCode.GetDistrictCode(IDCardNo.Substring(0, 2), (int)DistrictCodeTable.DistrictResultType.Full);
                return info;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}