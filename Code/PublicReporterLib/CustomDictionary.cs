using System;
using System.Collections.Generic;
using System.Text;

namespace PublicReporterLib
{
    /// <summary>
    /// 用于实现以添加顺序来进行foreach的字典
    /// </summary>
    public class CustomDictionary<TKey, TValue> : List<KeyValuePair<TKey, TValue>>
    {
        /// <summary>
        /// 获取或设置指定索引处的元素
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                TValue result = default(TValue);
                foreach (KeyValuePair<TKey, TValue> kvp in this)
                {
                    if (kvp.Key.Equals(key))
                    {
                        result = kvp.Value;
                        break;
                    }
                }
                return result;
            }
            set
            {
                bool needAdd = true;
                int existIndex = -1;
                for (int kk = 0; kk < this.Count; kk++)
                {
                    if (this[kk].Key.Equals(key))
                    {
                        needAdd = false;
                        existIndex = kk;
                        break;
                    }
                }

                if (needAdd)
                {
                    this.Add(new KeyValuePair<TKey, TValue>(key, value));
                }
                else
                {
                    this[existIndex] = new KeyValuePair<TKey, TValue>(key, value);
                }
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            this[key] = value;
        }

        /// <summary>
        /// 确定是否包含特定键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            bool exists = false;
            foreach (KeyValuePair<TKey, TValue> kvp in this)
            {
                if (kvp.Key.Equals(key))
                {
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        /// <summary>
        /// 移除带有指定键的元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            KeyValuePair<TKey, TValue> existObj = default(KeyValuePair<TKey, TValue>);
            foreach (KeyValuePair<TKey, TValue> kvp in this)
            {
                if (kvp.Key.Equals(key))
                {
                    existObj = kvp;
                    break;
                }
            }
            return this.Remove(existObj);
        }

        /// <summary>
        /// 键列表
        /// </summary>
        public IList<TKey> Keys
        {
            get
            {
                IList<TKey> results = new List<TKey>();
                foreach (KeyValuePair<TKey, TValue> kvp in this)
                {
                    results.Add(kvp.Key);
                }
                return results;
            }
        }

        /// <summary>
        /// 值列表
        /// </summary>
        public IList<TValue> Values
        {
            get
            {
                IList<TValue> results = new List<TValue>();
                foreach (KeyValuePair<TKey, TValue> kvp in this)
                {
                    results.Add(kvp.Value);
                }
                return results;
            }
        }
    }
}