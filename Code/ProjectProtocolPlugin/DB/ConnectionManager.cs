using System;
using System.Collections.Generic;
using System.Text;
using Noear.Weed;

namespace ProjectProtocolPlugin.DB
{
    public class ConnectionManager
    {
        private static System.Data.SQLite.SQLiteFactory factory = null;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        public static DbContext Context { get; set; }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="dbFile"></param>
        public static void Open(string dbFile)
        {
            factory = new System.Data.SQLite.SQLiteFactory();
            Context = new DbContext("main", "Data Source=" + dbFile, factory);
            Context.IsSupportSelectIdentityAfterInsert = false;
            Context.IsSupportGCAfterDispose = true;
        }

        public static void Close()
        {
            try
            {
                factory.Dispose();
            }
            catch (Exception ex) { }
            factory = null;

            try
            {
                Context.Dispose();
            }
            catch (Exception ex) { }
            Context = null;
        }
    }
}