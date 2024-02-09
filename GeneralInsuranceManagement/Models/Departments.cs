using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GeneralInsuranceManagement.Models
{
    public class Departments
    {
        #region "Variables"

        protected long mID;
        protected long mCreatedBy;
        protected string mDateCreated;
        protected string mMsgFlg;

        protected string mDepartmentName;
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

        public long ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public long CreatedBy
        {
            get { return mCreatedBy; }
            set { mCreatedBy = value; }
        }

        public string DateCreated
        {
            get { return mDateCreated; }
            set { mDateCreated = value; }
        }

        public string DepartmentName
        {
            get { return mDepartmentName; }
            set { mDepartmentName = value; }
        }

        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }

        #endregion

        #region "Methods"

        #region "Constructors"


        public Departments(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion


        public void Clear()
        {
            ID = 0;
            mCreatedBy = mObjectUserID;
            mDateCreated = "";
            mDepartmentName = "";

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
                sql = "SELECT * FROM Departments WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM Departments WHERE ID = " + mID;
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
                    SetErrorDetails("Departments not found.");

                    return false;

                }


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }

        public virtual System.Data.DataSet GetDepartments()
        {

            return GetDepartments(mID);

        }

        public virtual DataSet GetDepartments(long ID)
        {

            string sql = null;

            if (ID > 0)
            {
                sql = "SELECT * FROM Departments WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM Departments WHERE ID = " + mID;
            }

            return GetDepartments(sql);

        }

        protected virtual DataSet GetDepartments(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }

        #endregion


        protected internal virtual void LoadDataRecord(DataRow rw)
        {


            mID = ((rw["ID"] != DBNull.Value) ? int.Parse(rw["ID"].ToString()) : 0);
            mCreatedBy = ((rw["CreatedBy"] != DBNull.Value) ? int.Parse(rw["CreatedBy"].ToString()) : 0);
            mDateCreated = ((rw["DateCreated"] == DBNull.Value) ? string.Empty : rw["DateCreated"].ToString());
            mDepartmentName = ((rw["DepartmentName"] == DBNull.Value) ? string.Empty : rw["DepartmentName"].ToString());


        }

        #region "Save"


        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@ID", DbType.Int32, mID);
            db.AddInParameter(cmd, "@DateCreated", DbType.String, mDateCreated);
            db.AddInParameter(cmd, "@DepartmentName", DbType.String, mDepartmentName);

        }

        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_Departments");

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

            //Return Delete("UPDATE Departments SET Deleted = 1 WHERE ID = " & mID) 
            return Delete("DELETE FROM Departments WHERE ID = " + mID);

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