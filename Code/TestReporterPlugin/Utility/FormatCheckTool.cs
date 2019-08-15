using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReporter.Utility
{
    /// <summary>
    /// 格式检查工具
    /// </summary>
    public class FormatCheckTool
    {
        /// <summary>
        /// 验证电话号码
        /// </summary>
        /// <param name="str_telephone"></param>
        /// <returns></returns>
        public static bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }

        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="str_handset"></param>
        /// <returns></returns>
        public static bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[2,3,4,5,6,7,8,9]+\d{9}");
        }

        /// <summary>
        /// 验证身份证号
        /// </summary>
        /// <param name="str_idcard"></param>
        /// <returns></returns>
        public static bool IsIDcard(string str_idcard)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_idcard, @"(^\d{18}$)|(^\d{15}$)");
        }

        /// <summary>
        /// 验证输入为数字
        /// </summary>
        /// <param name="str_number"></param>
        /// <returns></returns>
        public static bool IsNumber(string str_number)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_number, @"^[0-9]*$");
        }

        /// <summary>
        /// 验证邮编
        /// </summary>
        /// <param name="str_postalcode"></param>
        /// <returns></returns>
        public static bool IsPostalcode(string str_postalcode)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }
    }
}