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
        protected string mMinimumLengthRequired;
        protected string mMaximumLengthRequired;

        public int Id { get { return mId; } set { mId = value; } }
        public string Msgflg { get { return mMSgflg; } set { mMSgflg = value; } }
        public string IdentificationTypeName { get { return mIdentificationTypeName; } set { mIdentificationTypeName = value; } }
        public string Format { get { return mFormat; } set { mFormat = value; } }
        public string MinimumLengthRequired { get { return mMinimumLengthRequired; ; } set { mMinimumLengthRequired = value; } }
        public string MaximumLengthRequired { get { return mMaximumLengthRequired; } set { mMaximumLengthRequired = value; } }
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
            db.AddInParameter(cmd, "@Description", DbType.String, mIdentificationTypeName);
            db.AddInParameter(cmd, "@Description", DbType.String, mFormat);
            db.AddInParameter(cmd, "@Description", DbType.String, mMinimumLengthRequired);
            db.AddInParameter(cmd, "@Description", DbType.String, mMaximumLengthRequired);
        }
        protected void SetErrorDetails(string str)
        {
            mMSgflg = str;
        }
    }
}
