using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using System.IO;

namespace System.Data.SQLite
{
    /// <summary>   
    /// SQLite数据库操作帮助类  
    /// 提供一系列方便的调用:  
    /// Execute,Save,Update,Delete...  
    ///   
    /// 不是线程安全的  
    ///   
    /// @author pcenshao  
    /// </summary>  
    public class SQLiteHelper
    {
        private bool _showSql = true;

        /// <summary>  
        /// 是否输出生成的SQL语句  
        /// </summary>  
        public bool ShowSql
        {
            get
            {
                return this._showSql;
            }
            set
            {
                this._showSql = value;
            }
        }

        private readonly string _dataFile;

        private SQLiteConnection _conn;

        public SQLiteHelper(string dataFile)
        {
            if (dataFile == null)
                throw new ArgumentNullException("dataFile=null");
            this._dataFile = dataFile;
        }

        /// <summary>  
        /// <para>打开SQLiteManager使用的数据库连接</para>  
        /// </summary>  
        public void Open()
        {
            this._conn = OpenConnection(this._dataFile);
        }

        public void Close()
        {
            if (this._conn != null)
            {
                this._conn.Close();
            }
        }

        /// <summary>  
        /// <para>安静地关闭连接,保存不抛出任何异常</para>  
        /// </summary>  
        public void CloseQuietly()
        {
            if (this._conn != null)
            {
                try
                {
                    this._conn.Close();
                }
                catch { }
            }
        }

        /// <summary>  
        /// <para>创建一个连接到指定数据文件的SQLiteConnection,并Open</para>  
        /// <para>如果文件不存在,创建之</para>  
        /// </summary>  
        /// <param name="dataFile"></param>  
        /// <returns></returns>  
        public static SQLiteConnection OpenConnection(string dataFile)
        {
            if (dataFile == null)
                throw new ArgumentNullException("dataFile=null");

            if (!File.Exists(dataFile))
            {
                SQLiteConnection.CreateFile(dataFile);
            }

            SQLiteConnection conn = new SQLiteConnection();
            SQLiteConnectionStringBuilder conStr = new SQLiteConnectionStringBuilder();
            conStr.DataSource = dataFile;
            conn.ConnectionString = conStr.ToString();
            conn.Open();
            return conn;
        }

        /// <summary>  
        /// <para>读取或设置SQLiteManager使用的数据库连接</para>  
        /// </summary>  
        public SQLiteConnection Connection
        {
            get
            {
                return this._conn;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this._conn = value;
            }
        }

        protected void EnsureConnection()
        {
            if (this._conn == null)
            {
                throw new Exception("SQLiteManager.Connection=null");
            }
        }

        public string GetDataFile()
        {
            return this._dataFile;
        }

        /// <summary>  
        /// <para>判断表table是否存在</para>  
        /// </summary>  
        /// <param name="table"></param>  
        /// <returns></returns>  
        public bool TableExists(string table)
        {
            if (table == null)
                throw new ArgumentNullException("table=null");
            this.EnsureConnection();
            // SELECT count(*) FROM sqlite_master WHERE type='table' AND name='test';  
            SQLiteCommand cmd = new SQLiteCommand("SELECT count(*) as c FROM sqlite_master WHERE type='table' AND name=@tableName ");
            cmd.Connection = this.Connection;
            cmd.Parameters.Add(new SQLiteParameter("tableName", table));
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int c = reader.GetInt32(0);
            reader.Close();
            reader.Dispose();
            cmd.Dispose();
            //return false;  
            return c == 1;
        }

        /// <summary>  
        /// <para>执行SQL,返回受影响的行数</para>  
        /// <para>可用于执行表创建语句</para>  
        /// <para>paramArr == null 表示无参数</para>  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <returns></returns>  
        public int ExecuteNonQuery(string sql, SQLiteParameter[] paramArr)
        {
            if (sql == null)
            {
                throw new ArgumentNullException("sql=null");
            }
            this.EnsureConnection();

            if (this.ShowSql)
            {
                Console.WriteLine("SQL: " + sql);
            }

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = sql;
            if (paramArr != null)
            {
                foreach (SQLiteParameter p in paramArr)
                {
                    cmd.Parameters.Add(p);
                }
            }
            cmd.Connection = this.Connection;
            int c = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return c;
        }

        /// <summary>  
        /// <para>执行SQL,返回SQLiteDataReader</para>  
        /// <para>返回的Reader为原始状态,须自行调用Read()方法</para>  
        /// <para>paramArr=null,则表示无参数</para>  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="paramArr"></param>  
        /// <returns></returns>  
        public SQLiteDataReader ExecuteReader(string sql, SQLiteParameter[] paramArr)
        {
            return (SQLiteDataReader)ExecuteReader(sql, paramArr, (ReaderWrapper)null);
        }

        /// <summary>  
        /// <para>执行SQL,如果readerWrapper!=null,那么将调用readerWrapper对SQLiteDataReader进行包装,并返回结果</para>  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="paramArr">null 表示无参数</param>  
        /// <param name="readerWrapper">null 直接返回SQLiteDataReader</param>  
        /// <returns></returns>  
        public object ExecuteReader(string sql, SQLiteParameter[] paramArr, ReaderWrapper readerWrapper)
        {
            if (sql == null)
            {
                throw new ArgumentNullException("sql=null");
            }
            this.EnsureConnection();

            SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection);
            if (paramArr != null)
            {
                foreach (SQLiteParameter p in paramArr)
                {
                    cmd.Parameters.Add(p);
                }
            }
            SQLiteDataReader reader = cmd.ExecuteReader();
            object result = null;
            if (readerWrapper != null)
            {
                result = readerWrapper(reader);
            }
            else
            {
                result = reader;
            }
            reader.Close();
            reader.Dispose();
            cmd.Dispose();
            return result;
        }

        /// <summary>  
        /// <para>执行SQL,返回结果集,使用RowWrapper对每一行进行包装</para>  
        /// <para>如果结果集为空,那么返回空List (List.Count=0)</para>  
        /// <para>rowWrapper = null时,使用WrapRowToDictionary</para>  
        /// </summary>  
        /// <param name="sql"></param>  
        /// <param name="paramArr"></param>  
        /// <param name="rowWrapper"></param>  
        /// <returns></returns>  
        public List<object> ExecuteRow(string sql, SQLiteParameter[] paramArr, RowWrapper rowWrapper)
        {
            if (sql == null)
            {
                throw new ArgumentNullException("sql=null");
            }
            this.EnsureConnection();

            SQLiteCommand cmd = new SQLiteCommand(sql, this.Connection);
            if (paramArr != null)
            {
                foreach (SQLiteParameter p in paramArr)
                {
                    cmd.Parameters.Add(p);
                }
            }

            if (rowWrapper == null)
            {
                rowWrapper = new RowWrapper(SQLiteHelper.WrapRowToDictionary);
            }

            SQLiteDataReader reader = cmd.ExecuteReader();
            List<object> result = new List<object>();
            if (reader.HasRows)
            {
                int rowNum = 0;
                while (reader.Read())
                {
                    object row = rowWrapper(rowNum, reader);
                    result.Add(row);
                    rowNum++;
                }
            }
            reader.Close();
            reader.Dispose();
            cmd.Dispose();
            return result;
        }

        public static object WrapRowToDictionary(int rowNum, SQLiteDataReader reader)
        {
            int fc = reader.FieldCount;
            Dictionary<string, object> row = new Dictionary<string, object>();
            for (int i = 0; i < fc; i++)
            {
                string fieldName = reader.GetName(i);
                object value = reader.GetValue(i);
                row.Add(fieldName, value);
            }
            return row;
        }

        /// <summary>  
        /// <para>执行insert into语句</para>  
        /// </summary>  
        /// <param name="table"></param>  
        /// <param name="entity"></param>  
        /// <returns></returns>  
        public int Save(string table, Dictionary<string, object> entity)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table=null");
            }
            this.EnsureConnection();
            string sql = BuildInsert(table, entity);
            return this.ExecuteNonQuery(sql, BuildParamArray(entity));
        }

        private static SQLiteParameter[] BuildParamArray(Dictionary<string, object> entity)
        {
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            foreach (string key in entity.Keys)
            {
                list.Add(new SQLiteParameter(key, entity[key]));
            }
            if (list.Count == 0)
                return null;
            return list.ToArray();
        }

        private static string BuildInsert(string table, Dictionary<string, object> entity)
        {
            StringBuilder buf = new StringBuilder();
            buf.Append("insert into ").Append(table);
            buf.Append(" (");
            foreach (string key in entity.Keys)
            {
                buf.Append(key).Append(",");
            }
            buf.Remove(buf.Length - 1, 1); // 移除最后一个,  
            buf.Append(") ");
            buf.Append("values(");
            foreach (string key in entity.Keys)
            {
                buf.Append("@").Append(key).Append(","); // 创建一个参数  
            }
            buf.Remove(buf.Length - 1, 1);
            buf.Append(") ");

            return buf.ToString();
        }

        private static string BuildUpdate(string table, Dictionary<string, object> entity)
        {
            StringBuilder buf = new StringBuilder();
            buf.Append("update ").Append(table).Append(" set ");
            foreach (string key in entity.Keys)
            {
                buf.Append(key).Append("=").Append("@").Append(key).Append(",");
            }
            buf.Remove(buf.Length - 1, 1);
            buf.Append(" ");
            return buf.ToString();
        }

        /// <summary>  
        /// <para>执行update语句</para>  
        /// <para>where参数不必要包含'where'关键字</para>  
        ///   
        /// <para>如果where=null,那么忽略whereParams</para>  
        /// <para>如果where!=null,whereParams=null,where部分无参数</para>  
        /// </summary>  
        /// <param name="table"></param>  
        /// <param name="entity"></param>  
        /// <param name="where"></param>  
        /// <param name="whereParams"></param>  
        /// <returns></returns>  
        public int Update(string table, Dictionary<string, object> entity, string where, SQLiteParameter[] whereParams)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table=null");
            }
            this.EnsureConnection();
            string sql = BuildUpdate(table, entity);
            SQLiteParameter[] arr = BuildParamArray(entity);
            if (where != null)
            {
                sql += " where " + where;
                if (whereParams != null)
                {
                    SQLiteParameter[] newArr = new SQLiteParameter[arr.Length + whereParams.Length];
                    Array.Copy(arr, newArr, arr.Length);
                    Array.Copy(whereParams, 0, newArr, arr.Length, whereParams.Length);

                    arr = newArr;
                }
            }
            return this.ExecuteNonQuery(sql, arr);
        }

        /// <summary>  
        /// <para>查询一行记录,无结果时返回null</para>  
        /// <para>conditionCol = null时将忽略条件,直接执行select * from table </para>  
        /// </summary>  
        /// <param name="table"></param>  
        /// <param name="conditionCol"></param>  
        /// <param name="conditionVal"></param>  
        /// <returns></returns>  
        public Dictionary<string, object> QueryOne(string table, string conditionCol, object conditionVal)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table=null");
            }
            this.EnsureConnection();

            string sql = "select * from " + table;
            if (conditionCol != null)
            {
                sql += " where " + conditionCol + "=@" + conditionCol;
            }
            if (this.ShowSql)
            {
                Console.WriteLine("SQL: " + sql);
            }

            List<object> list = this.ExecuteRow(sql, new SQLiteParameter[] {   
                new SQLiteParameter(conditionCol,conditionVal)  
            }, null);
            if (list.Count == 0)
                return null;
            return (Dictionary<string, object>)list[0];
        }

        /// <summary>  
        /// 执行delete from table 语句  
        /// where不必包含'where'关键字  
        /// where=null时将忽略whereParams  
        /// </summary>  
        /// <param name="table"></param>  
        /// <param name="where"></param>  
        /// <param name="whereParams"></param>  
        /// <returns></returns>  
        public int Delete(string table, string where, SQLiteParameter[] whereParams)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table=null");
            }
            this.EnsureConnection();
            string sql = "delete from " + table + " ";
            if (where != null)
            {
                sql += "where " + where;
            }

            return this.ExecuteNonQuery(sql, whereParams);
        }
    }

    /// <summary>  
    /// 在SQLiteManager.Execute方法中回调,将SQLiteDataReader包装成object   
    /// </summary>  
    /// <param name="reader"></param>  
    /// <returns></returns>  
    public delegate object ReaderWrapper(SQLiteDataReader reader);

    /// <summary>  
    /// 将SQLiteDataReader的行包装成object  
    /// </summary>  
    /// <param name="rowNum"></param>  
    /// <param name="reader"></param>  
    /// <returns></returns>  
    public delegate object RowWrapper(int rowNum, SQLiteDataReader reader);
}