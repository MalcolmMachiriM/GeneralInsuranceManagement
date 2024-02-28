using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using static GeneralInsuranceManagement.Models.Logs;
using System.Net.NetworkInformation;

namespace GeneralInsuranceManagement.Models.GlobalParameters
{
    public class Qualifications
    {
        protected Database db;
        protected string mConnectionsName;
        protected int mDescriptions;
        protected long mObjectUserID;
        protected int mId;
        protected string mMSgflg;
        protected string mQualificationName;
        protected DateTime mDateModified;

        public int Id { get { return mId; } set { mId = value; } }
        public string Msgflg { get { return mMSgflg; } set { mMSgflg = value; } }
        public string QualificationName { get { return mQualificationName; } set { mQualificationName = value; } }
        public DateTime DateModified { get { return mDateModified; } set { mDateModified = value; } }
        public Database Database => db;

        public string OwnerType => GetType().Name;
        public string ConnectionName => mConnectionsName;
        public Qualifications(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionsName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }

        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_Qualifications");
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
            db.AddInParameter(cmd, "@QualificationName", DbType.String, mQualificationName);
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
            mQualificationName = ((rw["QualificationName"] != DBNull.Value) ? (rw["QualificationName"].ToString()) : "");
            mDateModified = ((rw["DateModified"] != DBNull.Value) ? DateTime.Parse(rw["DateModified"].ToString()) : DateTime.MinValue);

        }
        public virtual bool Retrieve()
        {
            return Retrieve(mId);
        }

        public virtual bool Retrieve(long ID)
        {
            string text = ID <= 0 ? "SELECT * FROM Qualifications WHERE ID = " + mId : "SELECT * FROM Qualifications WHERE ID = " + ID;
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

                SetErrorDetails("Qualification not found.");
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
            return Delete("DELETE FROM Qualifications WHERE ID = " + mId);

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
