﻿using Noear.Weed;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace RobotSpeaker.SportDB
{
    public class DBInstance
    {
        private static DbContext _dbHelper = null;
        /// <summary>
        /// 数据访问接口
        /// </summary>
        public static DbContext DbHelper
        {
            get { return _dbHelper; }
        }

        public static void Init(string dbFile)
        {
            _dbHelper = new DbContext("main", "Data Source=" + dbFile, new SQLiteFactory());
            _dbHelper.IsSupportInsertAfterSelectIdentity = false;
        }

        /// <summary>
        /// 查询问题
        /// </summary>
        /// <param name="ask"></param>
        /// <returns></returns>
        public static Robot_Questions GetQuestion(string ask)
        {
            return DbHelper.table("Robot_Questions").where("Ask=?", new string[] { ask }).select("*").getItem<Robot_Questions>(new Robot_Questions());
        }

        /// <summary>
        /// 查询动作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Robot_Actions GetAction(long id)
        {
            return DbHelper.table("Robot_Actions").where("Id=?", new object[] { id }).select("*").getItem<Robot_Actions>(new Robot_Actions());
        }

        /// <summary>
        /// 查询动作
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Robot_Actions GetAction(string code)
        {
            return DbHelper.table("Robot_Actions").where("Code=?", new object[] { code }).select("*").getItem<Robot_Actions>(new Robot_Actions());
        }

        /// <summary>
        /// 查询动作指令
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Robot_Steps> GetSteps(long id)
        {
            return DbHelper.table("Robot_Steps").where("ActionId=?", new object[] { id }).select("*").getList<Robot_Steps>(new Robot_Steps());
        }
    }

    /// <summary>
    /// 问答表
    /// </summary>
    [Serializable]
    public class Robot_Questions : IBinder
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 问
        /// </summary>
        public string Ask { get; set; }

        /// <summary>
        /// 答
        /// </summary>
        public string Answer { get; set; }

        public void bind(GetHandlerEx source)
        {
            Id = source("Id").value<long>(0);
            Ask = source("Ask").value("");
            Answer = source("Answer").value("");
        }

        public IBinder clone()
        {
            return new Robot_Questions();
        }
    }

    /// <summary>
    /// 动作表
    /// </summary>
    [Serializable]
    public class Robot_Actions : IBinder
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 触发条件
        /// </summary>
        public string Condition { get; set; }

        public void bind(GetHandlerEx source)
        {
            Id = source("Id").value<long>(0);
            Code = source("Code").value("");
            Name = source("Name").value("");
            Condition = source("Condition").value("");
        }

        public IBinder clone()
        {
            return new Robot_Actions();
        }
    }

    /// <summary>
    /// 动作序列表
    /// </summary>
    [Serializable]
    public class Robot_Steps : IBinder
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 动作ID
        /// </summary>
        public long ActionId { get; set; }

        /// <summary>
        /// 电机序号
        /// </summary>
        public long MotorIndex { get; set; }

        /// <summary>
        /// 电机类型
        /// </summary>
        public long MotorType { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public long Value { get; set; }

        /// <summary>
        /// 备用项
        /// </summary>
        public string Tag { get; set; }

        public void bind(GetHandlerEx source)
        {
            Id = source("Id").value<long>(0);
            ActionId = source("ActionId").value<long>(0);
            MotorIndex = source("MotorIndex").value<long>(0);
            MotorType = source("MotorType").value<long>(0);
            Value = source("Value").value<long>(0);
            Tag = source("Tag").value("");
        }

        public IBinder clone()
        {
            return new Robot_Steps();
        }
    }
}