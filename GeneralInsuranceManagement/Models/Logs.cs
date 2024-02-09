﻿using GeneralInsuranceBusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Net.Mail;

namespace GeneralInsuranceManagement.Models
{
    public class Logs
    {
        #region enums
        public enum Actions
        {
            CREATE = 1,
            UPDATE = 2,
            DELETE = 3,
            LOGIN = 4,
        };
        public enum Descriptions
        {
            Success = 1,
            Fail = 2,
        };
        #endregion
        #region variables
        protected Database db;
        protected string mConnectionName;
        protected int mDescription;
        protected long mObjectUserID;
        protected int mID;
        protected long mUserID;
        protected int mActionID;
        protected long mCreatedBy;
        protected DateTime mDateOfAction;
        protected string mMsgflg;
        #endregion
        #region properties
        public string MsgFlg { get { return mMsgflg; } set { mMsgflg = value; } }
        public int Description { get { return mDescription; } set { mDescription = value; } }
        public int ID { get { return mID; } set { mID = value; } }
        public long UserID { get { return mUserID; } set { mUserID = value; } }
        public long ActionedByID { get { return mCreatedBy; } set { mCreatedBy = value; } }
        public int ActionID { get { return mActionID; } set { mActionID = value; } }
        public DateTime DateOfAction { get { return mDateOfAction; } set { mDateOfAction = value; } }

        public Database Database => db;

        public string OwnerType => GetType().Name;

        public string ConnectionName => mConnectionName;
        #endregion
        #region constructor
        public Logs(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }
        #endregion

        #region methods
        public DataSet getAllLogs(long userId)
        {
            try
            {
                string str = "select ah.ID,format(DateOfAction,'yyyy-MM-dd') DateOfAction,aa.Action,ah.CreatedBy,Firstnames,Surname,ad.Description " +
                    "from AuditHistory ah inner join AuditActions aa on ah.ActionId = aa.ID inner join Users u on ah.CreatedBy = u.ID inner join " +
                    $"AuditDescription ad on ah.Description = ad.ID where ah.CreatedBy = {userId} order by DateOfAction desc";
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return null;
            }
        }
        public virtual bool Retrieve()
        {
            return Retrieve(mID);
        }

        public virtual bool Retrieve(long ID)
        {
            string text = ID <= 0 ? "SELECT * FROM Logs WHERE ID = " + mID : "SELECT * FROM Logs WHERE ID = " + ID;
            return Retrieve(text);
        }

        protected virtual bool Retrieve(string sql)
        {
            try
            {
                DataSet dataSet = db.ExecuteDataSet(CommandType.Text, sql);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    LoadDataRecord(dataSet.Tables[0].Rows[0]);
                    dataSet = null;
                    return true;
                }

                SetErrorDetails("Log not found.");
                return false;
            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return false;
            }
        }

        protected DataSet ReturnDs(string str)
        {
            try
            {
                DataSet dataSet = db.ExecuteDataSet(CommandType.Text, str);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return dataSet;
                }

                return null;
            }
            catch (Exception ex)
            {
                mMsgflg = ex.Message;
                return null;
            }
        }
        protected internal virtual void LoadDataRecord(DataRow rw)
        {
            mID = ((rw["ID"] != DBNull.Value) ? int.Parse(rw["ID"].ToString()) : 0);
            mUserID = ((rw["UserId"] != DBNull.Value) ? int.Parse(rw["UserId"].ToString()) : 0);
            mCreatedBy = ((rw["CreatedBy"] != DBNull.Value) ? int.Parse(rw["CreatedBy"].ToString()) : 0);
            mDescription = ((rw["Description"] != DBNull.Value) ? int.Parse(rw["Description"].ToString()) : 0);
            mDateOfAction = (rw["DateOfAction"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(rw["DateOfAction"]);
            mActionID = ((rw["ActionId"] == DBNull.Value) ? int.Parse (rw["ActionId"].ToString()):0);
        }
        protected void SetErrorDetails(string str)
        {
            mMsgflg = str;
        }

        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_Audit_History");
            GenerateSaveParameters(ref db, ref cmd);
            try
            {
                DataSet dataSet = db.ExecuteDataSet(cmd);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    mID = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
                }

                return true;
            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return false;
            }
        }
        public virtual void GenerateSaveParameters(ref Database db, ref DbCommand cmd)
        {
            db.AddInParameter(cmd, "@UserId", DbType.Int64, mUserID);
            db.AddInParameter(cmd, "@ActionId", DbType.Int32, mActionID);
            db.AddInParameter(cmd, "@Description", DbType.Int32, mDescription);
            db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, mCreatedBy);
            db.AddInParameter(cmd, "@DateOfAction", DbType.String, mDateOfAction);
        }
        #endregion
        //must be in users
        public virtual DataSet GetUsers(string sql)
        {
            return db.ExecuteDataSet(CommandType.Text, sql);
        }
    }
}