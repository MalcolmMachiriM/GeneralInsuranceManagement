using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GeneralInsuranceManagement.Models
{
    public class CategoryPackages
    {
        #region "Variables"

        protected long mID;
        protected long mProductID;
        protected long mProcessTime;
        protected long mSumAssuredBasis;
        protected long mMaxPremiumTerm;
        protected string mEffectiveDate;
        protected string mRetention;
        protected string mMinSumAssured;
        protected string mMaxSumAssured;
        protected string mPackage;
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

        public long ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public long ProductID
        {
            get { return mProductID; }
            set { mProductID = value; }
        }

        public long ProcessTime
        {
            get { return mProcessTime; }
            set { mProcessTime = value; }
        }

        public long SumAssuredBasis
        {
            get { return mSumAssuredBasis; }
            set { mSumAssuredBasis = value; }
        }

        public long MaxPremiumTerm
        {
            get { return mMaxPremiumTerm; }
            set { mMaxPremiumTerm = value; }
        }

        public string EffectiveDate
        {
            get { return mEffectiveDate; }
            set { mEffectiveDate = value; }
        }

        public string Retention
        {
            get { return mRetention; }
            set { mRetention = value; }
        }

        public string MinSumAssured
        {
            get { return mMinSumAssured; }
            set { mMinSumAssured = value; }
        }

        public string MaxSumAssured
        {
            get { return mMaxSumAssured; }
            set { mMaxSumAssured = value; }
        }

        public string Package
        {
            get { return mPackage; }
            set { mPackage = value; }
        }
        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { MsgFlg = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        #endregion

        #region "Methods"

        #region "Constructors"


        public CategoryPackages(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion


        public void Clear()
        {
            ID = 0;
            mProductID = 0;
            mProcessTime = 0;
            mSumAssuredBasis = 0;
            mMaxPremiumTerm = 0;
            mEffectiveDate = "";
            mRetention = "";
            mMinSumAssured = "";
            mMaxSumAssured = "";
            mPackage = "";
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
                sql = "SELECT * FROM CategoryPackages WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM CategoryPackages WHERE ID = " + mID;
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
                    SetErrorDetails("CategoryPackages not found.");

                    return false;

                }


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }

        public virtual System.Data.DataSet GetCategoryPackages()
        {

            return GetCategoryPackages(mID);

        }

        public virtual DataSet GetCategoryPackages(long ID)
        {

            string sql = null;

            if (ID > 0)
            {
                sql = "SELECT * FROM CategoryPackages WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM CategoryPackages WHERE ID = " + mID;
            }

            return GetCategoryPackages(sql);

        }

        protected virtual DataSet GetCategoryPackages(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }
        public virtual DataSet GetAllCategoryPackages()
        {
            string sql = "Select cp.ID,Package,ProcessTime,Retention,Name,format(EffectiveDate,'yyyy-MM-dd')EffectiveDate " +
                "from CategoryPackages cp left join ProductCategory pc on cp.ProductID=pc.ID ";
            return db.ExecuteDataSet(CommandType.Text, sql);

        }

        #endregion


        protected internal virtual void LoadDataRecord(DataRow rw)
        {
            mID = ((rw["ID"] != DBNull.Value) ? int.Parse(rw["ID"].ToString()) : 0);
            mProductID = ((rw["ProductID"] != DBNull.Value) ? int.Parse(rw["ProductID"].ToString()) : 0);
            mProcessTime = ((rw["ProcessTime"] != DBNull.Value) ? int.Parse(rw["ProcessTime"].ToString()) : 0);
            mSumAssuredBasis = ((rw["SumAssuredBasis"] != DBNull.Value) ? int.Parse(rw["SumAssuredBasis"].ToString()) : 0);
            mMaxPremiumTerm = ((rw["MaxPremiumTerm"] != DBNull.Value) ? int.Parse(rw["MaxPremiumTerm"].ToString()) : 0);
            mEffectiveDate = ((rw["EffectiveDate"] == DBNull.Value) ? string.Empty : rw["EffectiveDate"].ToString());
            mRetention = ((rw["Retention"] == DBNull.Value) ? string.Empty : rw["Retention"].ToString());
            mMinSumAssured = ((rw["MinSumAssured"] == DBNull.Value) ? string.Empty : rw["MinSumAssured"].ToString());
            mMaxSumAssured = ((rw["MaxSumAssured"] == DBNull.Value) ? string.Empty : rw["MaxSumAssured"].ToString());
            mPackage = ((rw["Package"] == DBNull.Value) ? string.Empty : rw["Package"].ToString());
            mDescription = ((rw["Description"] == DBNull.Value) ? string.Empty : rw["Description"].ToString());



        }

        #region "Save"


        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@ID", DbType.Int32, mID);
            db.AddInParameter(cmd, "@ProductID", DbType.Int32, mProductID);
            db.AddInParameter(cmd, "@ProcessTime", DbType.Int32, mProcessTime);
            db.AddInParameter(cmd, "@SumAssuredBasis", DbType.Int32, mSumAssuredBasis);
            db.AddInParameter(cmd, "@MaxPremiumTerm", DbType.Int32, mMaxPremiumTerm);
            db.AddInParameter(cmd, "@EffectiveDate", DbType.String, mEffectiveDate);
            db.AddInParameter(cmd, "@Retention", DbType.Decimal, mRetention);
            db.AddInParameter(cmd, "@MinSumAssured", DbType.Decimal, mMinSumAssured);
            db.AddInParameter(cmd, "@MaxSumAssured", DbType.Decimal, mMaxSumAssured);
            db.AddInParameter(cmd, "@Package", DbType.String, mPackage);
            db.AddInParameter(cmd, "@Description", DbType.String, mDescription);

        }

        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_CategoryPackages");

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

            //Return Delete("UPDATE CategoryPackages SET Deleted = 1 WHERE ID = " & mID) 
            return Delete("DELETE FROM CategoryPackages WHERE ID = " + mID);

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