using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AbstractEditorPlugin.Utility
{
    public class InputControlDict
    {
        private List<Type> inputControlTypeList = new List<Type>();
        /// <summary>
        /// 输入控件类型列表
        /// </summary>
        public List<Type> InputControlTypeList
        {
            get { return inputControlTypeList; }
        }

        private Dictionary<string, Control> ctrlDicts = new Dictionary<string, Control>();
        /// <summary>
        /// 控件字典
        /// </summary>
        public Dictionary<string, Control> CtrlDicts
        {
            get { return ctrlDicts; }
        }

        /// <summary>
        /// 基于输入类型列表递归搜索出一个输入控件字典表
        /// </summary>
        /// <param name="parent"></param>
        public void searchAllControls(Control parent)
        {
            if (parent != null)
            {
                foreach (Control subs in parent.Controls)
                {
                    //检查是不是要找的对象
                    foreach (Type inputType in InputControlTypeList)
                    {
                        if (inputType.FullName == subs.GetType().FullName)
                        {
                            CtrlDicts[subs.Name] = subs;
                            break;
                        }
                    }

                    //递归继续搜索
                    searchAllControls(subs);
                }
            }
        }

        /// <summary>
        /// 获得指定名称的控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctrlName"></param>
        /// <returns></returns>
        public T getControl<T>(string ctrlName) where T : Control
        {
            T result = default(T);
            if (ctrlDicts.ContainsKey(ctrlName))
            {
                result = (T)ctrlDicts[ctrlName];
            }
            return result;
        }
    }
}