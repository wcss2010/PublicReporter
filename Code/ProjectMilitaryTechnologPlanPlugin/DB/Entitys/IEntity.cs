﻿using System;
using System.Collections.Generic;
using System.Text;
using Noear.Weed;

namespace ProjectMilitaryTechnologPlanPlugin.DB.Entitys
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
    }
}