using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GeneralInsuranceManagement.Models
{
    public class HabitsAndInterests
    {
        #region "Variables"

        protected long mId;
        protected string mDateCreated;
        protected string mDateModified;
        protected string mDescription;

        protected string mMsgFlg;
        protected Database db;
        protected string mConnectionName;

        protected long mObjectUserID;
        #endregion

        #region "Properties"

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

        public long Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public string DateCreated
        {
            get { return mDateCreated; }
            set { mDateCreated = value; }
        }

        public string DateModified
        {
            get { return mDateModified; }
            set { mDateModified = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }

        #endregion

        #region "Methods"

        #region "Constructors"


        public HabitsAndInterests(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion


        public void Clear()
        {
            Id = 0;
            mDateCreated = "";
            mDateModified = "";
            mDescription = "";

        }

        #region "Retrieve Overloads"

        public virtual bool Retrieve()
        {

            return this.Retrieve(mId);

        }

        public virtual bool Retrieve(long Id)
        {

            string sql = null;

            if (Id > 0)
            {
                sql = "SELECT * FROM HabitsAndInterests WHERE Id = " + Id;
            }
            else
            {
                sql = "SELECT * FROM HabitsAndInterests WHERE Id = " + mId;
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
                    SetErrorDetails("HabitsAndInterests not found.");

                    return false;

                }


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }

        public virtual System.Data.DataSet GetHabitsAndInterests()
        {

            return GetHabitsAndInterests(mId);

        }

        public virtual DataSet GetHabitsAndInterests(long Id)
        {

            string sql = null;

            if (Id > 0)
            {
                sql = "SELECT * FROM HabitsAndInterests WHERE Id = " + Id;
            }
            else
            {
                sql = "SELECT * FROM HabitsAndInterests WHERE Id = " + mId;
            }

            return GetHabitsAndInterests(sql);

        }

        protected virtual DataSet GetHabitsAndInterests(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }

        #endregion


        protected internal virtual void LoadDataRecord(DataRow rw)
        {

            mId = ((rw["ID"] != DBNull.Value) ? int.Parse(rw["ID"].ToString()) : 0);
            mDateCreated = ((rw["DateCreated"] == DBNull.Value) ? string.Empty : rw["DateCreated"].ToString());
            mDateModified = ((rw["DateModified"] == DBNull.Value) ? string.Empty : rw["DateModified"].ToString());
            mDescription = ((rw["Description"] == DBNull.Value) ? string.Empty : rw["Description"].ToString());


        }

        #region "Save"


        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@Id", DbType.Int32, mId);
            db.AddInParameter(cmd, "@DateCreated", DbType.String, mDateCreated);
            db.AddInParameter(cmd, "@DateModified", DbType.String, mDateModified);
            db.AddInParameter(cmd, "@Description", DbType.String, mDescription);

        }

        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_HabitsAndInterests");

            GenerateSaveParameters(ref db, ref cmd);


            try
            {
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    mId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

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

            //Return Delete("UPDATE HabitsAndInterests SET Deleted = 1 WHERE Id = " & mId) 
            return Delete("DELETE FROM HabitsAndInterests WHERE Id = " + mId);

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

        protected void SetErrorDetails(string str)
        {
            mMsgFlg = str;
        }
        #endregion

        #endregion

    }
    
}