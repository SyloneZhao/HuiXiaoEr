using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SqlSugar;
using Sylone.Comm;
using HuiXiaoEr.Model;

namespace Sylone.Service
{
    public class CommonService
    {
        private SqlSugarClient db = SqlConnect.GetInstance();

        #region 单表分页查询返回JSON
        /// <summary>
        /// 单表分页查询返回JSON
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="filter">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="paras">参数</param>
        /// <param name="fileds">字段</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public PageInfo SinglePage(string tablename, string filter, string orderby, object paras, string fileds, int pageIndex, int pageSize)
       {
            int totalCount = 0;
            var data = db.Queryable(tablename, "t").Where(filter).OrderBy(orderby+ " DESC").AddParameters(paras).Select(fileds).ToJsonPage(pageIndex + 1, pageSize, ref totalCount);
            return new PageInfo() { data = data, count = totalCount };
        }
        #endregion

        #region 多表分页查询返回JSON
        /// <summary>
        /// 多表分页查询返回JSON
        /// </summary>
        /// <param name="tablenames"></param>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <param name="paras"></param>
        /// <param name="fileds"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageInfo MultiPage(List<Join> tablenames, string filter, string orderby, object paras, string fileds, int pageIndex, int pageSize)
        {
            int totalCount = 0;
            var Queryable = db.Queryable(tablenames[0].tableName, tablenames[0].shortName);
            for (int i = 1; i < tablenames.Count; i++)
            {
                Queryable.AddJoinInfo(tablenames[i].tableName, tablenames[i].shortName, tablenames[i].JoinWhere, tablenames[i].type);
            }
            var json = Queryable.Where(filter).OrderBy(orderby + " DESC").AddParameters(paras).Select(fileds).ToJsonPage(pageIndex + 1, pageSize, ref totalCount);
            return new PageInfo() { data = json, count = totalCount };
        }
        #endregion

        #region 单表查询返回datatable
        /// <summary>
        /// 单表查询返回datatable
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <param name="paras"></param>
        /// <param name="fileds"></param>
        /// <returns></returns>
        public DataTable SingleTable(string tablename, string filter, string orderby, object paras, string fileds)
        {
            return db.Queryable(tablename, "t").Where(filter).OrderBy(orderby + " DESC").AddParameters(paras).Select(fileds).ToDataTable();
        }
        #endregion

        #region 多表查询返回datatable
        /// <summary>
        /// 多表查询返回datatable
        /// </summary>
        /// <param name="tablenames"></param>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <param name="paras"></param>
        /// <param name="fileds"></param>
        /// <returns></returns>
        public DataTable MultiTable(List<Join> tablenames, string filter, string orderby, object paras, string fileds)
        {
            var Queryable = db.Queryable(tablenames[0].tableName, tablenames[0].shortName);
            for (int i = 1; i < tablenames.Count; i++)
            {
                Queryable.AddJoinInfo(tablenames[i].tableName, tablenames[i].shortName, tablenames[i].JoinWhere, tablenames[i].type);
            }
            return Queryable.Where(filter).OrderBy(orderby + " DESC").AddParameters(paras).Select(fileds).ToDataTable();
        }
        #endregion

        #region 查询返回List<T>
        /// <summary>
        /// 查询返回List<T>
        /// </summary>
        /// <typeparam name="T">实例</typeparam>
        /// <param name="strWhere">条件</param>
        /// <param name="paras">条件值</param>
        /// <returns></returns>
        public List<T> Get<T>(List<string> strWhere, object paras) where T : class, new()
        {
            var Queryable = db.Queryable<T>();
            foreach (string item in strWhere)
            {
                Queryable.Where(item);
            }
            return Queryable.AddParameters(paras).ToList();
        }
        #endregion

        #region 查询返回T/BOOL
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">实例</typeparam>
        /// <param name="where">条件</param>
        /// <param name="paras">条件值</param>
        /// <returns></returns>
        public T Get<T>(string where, object paras) where T : class, new()
        {
            return db.Queryable<T>().Where(where, paras).First();
        }
        #endregion

        #region 添加返回自增列ID
        /// <summary>
        /// 添加返回自增列ID
        /// </summary>
        /// <param name="t">实例</param>
        /// <returns></returns>
        public int Add<T>(T t) where T : class, new()
        {
            return db.Insertable(t).ExecuteReturnIdentity(); 
        }
        #endregion

        #region 批量添加返回BOOL
        /// <summary>
        /// 批量添加返回BOOL
        /// </summary>
        /// <param name="listT">实例</param>
        /// <returns></returns>
        public bool Add<T>(List<T> listT) where T : class, new()
        {
            try
            {
                db.Ado.BeginTran();
                int flag = db.Insertable(listT.ToArray()).ExecuteCommand();
                db.Ado.CommitTran();
                return true;
            }
            catch (Exception ex)
            {
                db.Ado.RollbackTran();
                LogHelper.Error("批量增加", ex.Message);
                return false;
            }
        }
        #endregion

        #region 修改返回BOOL
        /// <summary>
        /// 修改返回BOOL
        /// </summary>
        /// <param name="t">实例</param>
        /// <returns></returns>
        public bool Update<T>(T t) where T : class, new()
        {
            int flag = db.Updateable(t).ExecuteCommand();
            if (flag > 0)
            {
                return true;
            }
            else
            {
                throw new Exception("操作失败，请稍后再试");
            }
        }
        #endregion

        #region 删除/批量删除
        /// <summary>
        /// 删除/批量删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public int Delete<T>(int[] strArr) where T : class, new()
        {
            int flag = 0;
            try
            {
                db.Ado.BeginTran();
                flag = db.Deleteable<T>().In(strArr).ExecuteCommand();
                db.Ado.CommitTran();
            }
            catch (Exception ex)
            {
                db.Ado.RollbackTran();
                LogHelper.Error("批量删除", ex.Message);
            }
            return flag;
        }
        #endregion
    }
}
