using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace GeneralInsuranceManagement.Models.GlobalParameters
{
    public class Banks
    {
        protected Database db;
        protected string mConnectionsName;
        protected int mDescription;
        protected long mObjectUserID;
        protected int mId;
        protected string mMSgflg;
        protected string mCode;
        protected string mBankName;
        protected int mNumberOfBranches;
        protected int mAccountNumberLength;
        protected DateTime mDateModified;

        public int Id { get { return mId; } set { mId = value; } }
        public string Msgflg { get { return mMSgflg; } set { mMSgflg = value; } }
        public string Code { get { return mCode; } set { mCode = value; } }
        public string BankName { get { return mBankName; } set { mBankName = value; } }
        public int NumberOfBranches { get { return mNumberOfBranches; } set { mNumberOfBranches = value; } }
        public int AccountNumberLength { get { return mAccountNumberLength; } set { mAccountNumberLength = value; } }
        public DateTime DateModified { get { return mDateModified; }set { mDateModified = value; } }
        public Database Database => db;

        public string OwnerType => GetType().Name;
        public string ConnectionName => mConnectionsName;
        public Banks(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionsName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }

        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_Banks");
            GenerateSaveParameters(ref db, ref cmd);
            try
            {
                DataSet dataSet = db.ExecuteDataSet(cmd);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    mId = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
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
            db.AddInParameter(cmd, "@Id", DbType.Int32, mId);
            db.AddInParameter(cmd, "@Code", DbType.String, mCode);
            db.AddInParameter(cmd, "@BankName", DbType.String, mBankName);
            db.AddInParameter(cmd, "@NumberOfBranches", DbType.Int32, mNumberOfBranches);
            db.AddInParameter(cmd, "@AccountNumberLength", DbType.Int32, mAccountNumberLength);
        }
        protected void SetErrorDetails(string str)
        {
            mMSgflg = str;
        }

        public virtual DataSet GetUsers(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }
        protected internal virtual void LoadDataRecord(DataRow rw)
        {
            mId = ((rw["Id"] != DBNull.Value) ? int.Parse(rw["Id"].ToString()) : 0);
            mCode = ((rw["Code"] != DBNull.Value) ? (rw["Code"].ToString()) : "");
            mBankName = ((rw["BankName"] != DBNull.Value) ? (rw["BankName"].ToString()) : "");
            mNumberOfBranches = ((rw["NumberOfBranches"] != DBNull.Value) ? int.Parse(rw["NumberOfBranches"].ToString()) : 0);
            mAccountNumberLength = ((rw["AccountNumberLength"] != DBNull.Value) ? int.Parse(rw["AccountNumberLength"].ToString()) : 0);
            mDateModified = ((rw["DateModified"] != DBNull.Value) ? DateTime.Parse(rw["DateModified"].ToString()) : DateTime.MinValue);

        }
        public virtual bool Retrieve()
        {
            return Retrieve(mId);
        }

        public virtual bool Retrieve(long ID)
        {
            string text = ID <= 0 ? "SELECT * FROM Banks WHERE ID = " + mId : "SELECT * FROM Banks WHERE ID = " + ID;
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

                SetErrorDetails("Bank not found.");
                return false;
            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return false;
            }
        }
        #region "Delete"

        public virtual bool Delete()
        {

            //Return Delete("UPDATE Users SET Deleted = 1 WHERE ID = " & mID) 
            return Delete("DELETE FROM Banks WHERE ID = " + mId);

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
    }
}
