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
    public class AddressTypes
    {
        protected Database db;
        protected string mConnectionsName;
        protected int mDescriptions;
        protected long mObjectUserID;
        protected int mId;
        protected string mMSgflg;
        protected string mDescription;

        public int Id { get { return mId; } set { mId = value; } }
        public string Msgflg { get { return mMSgflg; } set { mMSgflg = value; } }
        public string Description { get { return mDescription; } set { mDescription = value; } }
        public Database Database => db;

        public string OwnerType => GetType().Name;
        public string ConnectionName => mConnectionsName;
        public AddressTypes(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionsName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }

        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_AddressTypes");
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
            db.AddInParameter(cmd, "@Description", DbType.String, mDescription);
        }
        protected void SetErrorDetails(string str)
        {
            mMSgflg = str;
        }

        public virtual DataSet GetUsers(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }
    }
}
