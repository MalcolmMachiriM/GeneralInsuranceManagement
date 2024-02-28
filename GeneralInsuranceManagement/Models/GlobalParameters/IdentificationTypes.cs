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
    public class IdentificationTypes
    {
        protected Database db;
        protected string mConnectionsName;
        protected int mDescriptions;
        protected long mObjectUserID;
        protected int mId;
        protected string mMSgflg;
        protected string mIdentificationTypeName;
        protected string mFormat;
        protected int mMinimumLengthRequired;
        protected int mMaximumLengthRequired;
        protected DateTime mDateModified;

        public int Id { get { return mId; } set { mId = value; } }
        public string Msgflg { get { return mMSgflg; } set { mMSgflg = value; } }
        public string IdentificationTypeName { get { return mIdentificationTypeName; } set { mIdentificationTypeName = value; } }
        public string Format { get { return mFormat; } set { mFormat = value; } }
        public int MinimumLengthRequired { get { return mMinimumLengthRequired; ; } set { mMinimumLengthRequired = value; } }
        public int MaximumLengthRequired { get { return mMaximumLengthRequired; } set { mMaximumLengthRequired = value; } }
        public DateTime DateModified { get { return mDateModified; }set { mDateModified = value; } }
        public Database Database => db;

        public string OwnerType => GetType().Name;
        public string ConnectionName => mConnectionsName;
        public IdentificationTypes(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionsName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }

        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_IdentificationTypes");
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
            db.AddInParameter(cmd, "@IdentificationTypeName", DbType.String, mIdentificationTypeName);
            db.AddInParameter(cmd, "@Format", DbType.String, mFormat);
            db.AddInParameter(cmd, "@MinimumLengthRequired", DbType.Int32, mMinimumLengthRequired);
            db.AddInParameter(cmd, "@MaximumLengthRequired", DbType.Int32, mMaximumLengthRequired);
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
            mIdentificationTypeName = ((rw["IdentificationTypeName"] != DBNull.Value) ? (rw["IdentificationTypeName"].ToString()) : "");
            mFormat = ((rw["Format"] != DBNull.Value) ? (rw["Format"].ToString()) : "");
            mMinimumLengthRequired = ((rw["MinimumLengthRequired"] != DBNull.Value) ? int.Parse(rw["MinimumLengthRequired"].ToString()) : 0);
            mMaximumLengthRequired = ((rw["MaximumLengthRequired"] != DBNull.Value) ? int.Parse(rw["MaximumLengthRequired"].ToString()) : 0);
            mDateModified = ((rw["DateModified"] != DBNull.Value) ? DateTime.Parse(rw["DateModified"].ToString()) : DateTime.MinValue);

        }
        public virtual bool Retrieve()
        {
            return Retrieve(mId);
        }

        public virtual bool Retrieve(long ID)
        {
            string text = ID <= 0 ? "SELECT * FROM IdentificationTypes WHERE ID = " + mId : "SELECT * FROM IdentificationTypes WHERE ID = " + ID;
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

                SetErrorDetails("Identification Type not found.");
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
            return Delete("DELETE FROM IdentificationTypes WHERE ID = " + mId);

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
