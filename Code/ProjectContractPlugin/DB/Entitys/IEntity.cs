using System;
using System.Collections.Generic;
using System.Text;
using Noear.Weed;
using PublicReporterLib;

namespace ProjectContractPlugin.DB.Entitys
{
    /// <summary>
    /// 数据实体抽象类
    /// </summary>
    public abstract class IEntity : IBinder
    {
        /// <summary>
        /// 将数据复制到
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public abstract Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query);

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="source"></param>
        public abstract void bind(GetHandlerEx source);

        public virtual IBinder clone()
        {
            return (IBinder)this.MemberwiseClone();
        }

        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 更新保存日期
        /// </summary>
        protected void updateSaveDate()
        {
            try
            {
                if (PluginLoader.CurrentPlugin is NewPluginRoot)
                {
                    ((NewPluginRoot)PluginLoader.CurrentPlugin).updateSaveDate();
                }
            }
            catch (Exception ex) { }
        }
    }
}