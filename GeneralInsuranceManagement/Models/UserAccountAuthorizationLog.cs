using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GeneralInsuranceManagement.Models
{
    public class UserAccountAuthorizationLog
    {
        #region "Variables"

        protected long mID;
        protected long mRecordUpdateTypeID;
        protected long mUserID;
        protected long mCurrentStatusID;
        protected long mRequestStatusID;
        protected long mRequestUpdateBy;
        protected long mApprovalStatusID;
        protected long mApprovalBy;
        protected string mDateCreated;
        protected string mApprovalDate;

        protected string mMsgFlg;
        protected Database db;
        protected string mConnectionName;

        protected long mObjectUserID;
        #endregion

        #region "Properties"

        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }
        public Database Database
        {
            get { return db; }
        }

        public string OwnerType
        {
            get { return this.GetType().Name; }
        }

        public string ConnectionName
        {
            get { return mConnectionName; }
        }

        public long ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public long RecordUpdateTypeID
        {
            get { return mRecordUpdateTypeID; }
            set { mRecordUpdateTypeID = value; }
        }

        public long UserID
        {
            get { return mUserID; }
            set { mUserID = value; }
        }

        public long CurrentStatusID
        {
            get { return mCurrentStatusID; }
            set { mCurrentStatusID = value; }
        }

        public long RequestStatusID
        {
            get { return mRequestStatusID; }
            set { mRequestStatusID = value; }
        }

        public long RequestUpdateBy
        {
            get { return mRequestUpdateBy; }
            set { mRequestUpdateBy = value; }
        }

        public long ApprovalStatusID
        {
            get { return mApprovalStatusID; }
            set { mApprovalStatusID = value; }
        }

        public long ApprovalBy
        {
            get { return mApprovalBy; }
            set { mApprovalBy = value; }
        }

        public string DateCreated
        {
            get { return mDateCreated; }
            set { mDateCreated = value; }
        }

        public string ApprovalDate
        {
            get { return mApprovalDate; }
            set { mApprovalDate = value; }
        }

        #endregion

        #region "Methods"

        #region "Constructors"


        public UserAccountAuthorizationLog(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        protected void SetErrorDetails(string str)
        {
            mMsgFlg = str;
        }


        #endregion


        public void Clear()
        {
            ID = 0;
            mRecordUpdateTypeID = 0;
            mUserID = 0;
            mCurrentStatusID = 0;
            mRequestStatusID = 0;
            mRequestUpdateBy = 0;
            mApprovalStatusID = 0;
            mApprovalBy = 0;
            mDateCreated = "";
            mApprovalDate = "";

        }

        #region "Retrieve Overloads"

        public virtual bool Retrieve()
        {

            return this.Retrieve(mID);

        }

        public virtual bool Retrieve(long ID)
        {

            string sql = null;

            if (ID > 0)
            {
                sql = "SELECT * FROM UserAccountsAuthorizationLog WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM UserAccountsAuthorizationLog WHERE ID = " + mID;
            }

            return Retrieve(sql);

        }

        protected virtual bool Retrieve(string sql)
        {


            try
            {
                DataSet dsRetrieve = db.ExecuteDataSet(CommandType.Text, sql);


                if (dsRetrieve != null && dsRetrieve.Tables.Count > 0 && dsRetrieve.Tables[0].Rows.Count > 0)
                {
                    LoadDataRecord(dsRetrieve.Tables[0].Rows[0]);

                    dsRetrieve = null;
                    return true;


                }
                else
                {
                    SetErrorDetails("UserAccountAuthorizationLog not found.");

                    return false;

                }


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }

        public virtual System.Data.DataSet GetUserAccountAuthorizationLog()
        {

            return GetUserAccountAuthorizationLog(mID);

        }

        public virtual DataSet GetUserAccountAuthorizationLog(long ID)
        {

            string sql = null;

            if (ID > 0)
            {
                sql = "SELECT * FROM UserAccountsAuthorizationLog WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM UserAccountsAuthorizationLog WHERE ID = " + mID;
            }

            return GetUserAccountAuthorizationLog(sql);

        }

        protected virtual DataSet GetUserAccountAuthorizationLog(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }

        #endregion


        protected internal virtual void LoadDataRecord(DataRow rw)
        {

            mID = ((rw["ID"] != DBNull.Value) ? int.Parse(rw["ID"].ToString()) : 0);
            mRecordUpdateTypeID = ((rw["RecordUpdateTypeID"] != DBNull.Value) ? int.Parse(rw["RecordUpdateTypeID"].ToString()) : 0);
            mUserID = ((rw["UserID"] != DBNull.Value) ? int.Parse(rw["UserID"].ToString()) : 0);
            mCurrentStatusID = ((rw["CurrentStatusID"] != DBNull.Value) ? int.Parse(rw["CurrentStatusID"].ToString()) : 0);
            mRequestStatusID = ((rw["RequestStatusID"] != DBNull.Value) ? int.Parse(rw["RequestStatusID"].ToString()) : 0);
            mRequestUpdateBy = ((rw["RequestUpdateBy"] != DBNull.Value) ? int.Parse(rw["RequestUpdateBy"].ToString()) : 0);
            mApprovalStatusID = ((rw["ApprovalStatusID"] != DBNull.Value) ? int.Parse(rw["ApprovalStatusID"].ToString()) : 0);
            mApprovalBy = ((rw["ApprovalBy"] != DBNull.Value) ? int.Parse(rw["ApprovalBy"].ToString()) : 0);
            mDateCreated = ((rw["DateCreated"] == DBNull.Value) ? string.Empty : rw["DateCreated"].ToString());
            mApprovalDate = ((rw["ApprovalDate"] == DBNull.Value) ? string.Empty : rw["ApprovalDate"].ToString());


        }

        #region "Save"


        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@ID", DbType.Int32, mID);
            db.AddInParameter(cmd, "@RecordUpdateTypeID", DbType.Int32, mRecordUpdateTypeID);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, mUserID);
            db.AddInParameter(cmd, "@CurrentStatusID", DbType.Int32, mCurrentStatusID);
            db.AddInParameter(cmd, "@RequestStatusID", DbType.Int32, mRequestStatusID);
            db.AddInParameter(cmd, "@RequestUpdateBy", DbType.Int32, mRequestUpdateBy);
            db.AddInParameter(cmd, "@ApprovalStatusID", DbType.Int32, mApprovalStatusID);
            db.AddInParameter(cmd, "@ApprovalBy", DbType.Int32, mApprovalBy);
            db.AddInParameter(cmd, "@DateCreated", DbType.String, mDateCreated);
            db.AddInParameter(cmd, "@ApprovalDate", DbType.String, mApprovalDate);

        }

        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_UserAccountAuthorizationLog");

            GenerateSaveParameters(ref db, ref cmd);


            try
            {
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    mID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                }

                return true;


            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return false;

            }

        }

        #endregion

        #region "Delete"

        public virtual bool Delete()
        {

            //Return Delete("UPDATE UserAccountsAuthorizationLog SET Deleted = 1 WHERE ID = " & mID) 
            return Delete("DELETE FROM UserAccountsAuthorizationLog WHERE ID = " + mID);

        }

        protected virtual bool Delete(string DeleteSQL)
        {


            try
            {
                db.ExecuteNonQuery(CommandType.Text, DeleteSQL);
                return true;


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }

        #endregion

        #endregion

    }
}