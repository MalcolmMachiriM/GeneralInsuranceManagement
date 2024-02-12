using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GeneralInsuranceManagement.Models
{
    public class ProductCategory
    {
        #region "Variables"

        protected long mID;
        protected long mSchemeID;
        protected string mName;

        protected string mDescription;
        protected Database db;
        protected string mConnectionName;
        protected long mObjectUserID;

        protected string mMsgFlg;
        #endregion

        #region "Properties"

        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }
        public Database Database => db;

        public string OwnerType => GetType().Name;

        public string ConnectionName => mConnectionName;

        public long ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public long SchemeID
        {
            get { return mSchemeID; }
            set { mSchemeID = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        #endregion

        #region "Methods"

        #region "Constructors"


        public ProductCategory(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion


        public void Clear()
        {
            ID = 0;
            mSchemeID = 0;
            mName = "";
            mDescription = "";

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
                sql = "SELECT * FROM ProductCategory WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM ProductCategory WHERE ID = " + mID;
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
                    SetErrorDetails("ProductCategory not found.");

                    return false;

                }


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }

        public virtual System.Data.DataSet GetProductCategory()
        {

            return GetProductCategory(mID);

        }

        public virtual DataSet GetProductCategory(long ID)
        {

            string sql = null;

            if (ID > 0)
            {
                sql = "SELECT * FROM ProductCategory WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM ProductCategory WHERE ID = " + mID;
            }

            return GetProductCategory(sql);

        }

        protected virtual DataSet GetProductCategory(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }
        public virtual DataSet GetAllProductCategory()
        {
            string sql = "Select * from ProductCategory";
            return db.ExecuteDataSet(CommandType.Text, sql);

        }

        #endregion


        protected internal virtual void LoadDataRecord(DataRow rw)
        {


            mID = ((rw["ID"] != DBNull.Value) ? int.Parse(rw["ID"].ToString()) : 0);
            mSchemeID = ((rw["SchemeID"] != DBNull.Value) ? int.Parse(rw["SchemeID"].ToString()) : 0);
            mName = ((rw["Name"] == DBNull.Value) ? string.Empty : rw["Name"].ToString());
            mDescription = ((rw["Description"] == DBNull.Value) ? string.Empty : rw["Description"].ToString());


        }

        #region "Save"


        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@ID", DbType.Int32, mID);
            db.AddInParameter(cmd, "@SchemeID", DbType.Int32, mSchemeID);
            db.AddInParameter(cmd, "@Name", DbType.String, mName);
            db.AddInParameter(cmd, "@Description", DbType.String, mDescription);

        }

        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_ProductCategory");

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

            //Return Delete("UPDATE ProductCategory SET Deleted = 1 WHERE ID = " & mID) 
            return Delete("DELETE FROM ProductCategory WHERE ID = " + mID);

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