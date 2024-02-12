using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;

namespace GeneralInsuranceManagement.Models.GlobalParameters
{
    public class StopOrders
    {
        #region variables
        protected Database db;
        protected string mConnectionName;
        protected long mObjectUserID;
        protected string mMsgflg;
        protected int mId;
        protected string mName;
        protected string mEmployerName;
        protected int mEmployeeNumber;
        #endregion
        #region properties
        public int Id { get { return mId; } set { mId = value; } }
        public string MsgFlg { get { return mMsgflg; } set { mMsgflg = value; } }
        public string Name { get { return mName; } set { mName = value; } }
        public string EmployerName { get { return mName; } set { mName = value; } }
        public int EmployeeNumber { get { return mEmployeeNumber; } set { mEmployeeNumber = value; } }
        public Database Database => db;

        public string OwnerType => GetType().Name;

        public string ConnectionName => mConnectionName;
        #endregion
        public StopOrders(string ConnectionName, long ObjectUserID) 
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }
        #region methods
        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_StopOrders");
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
            db.AddInParameter(cmd, "@Name", DbType.String, mName);
            db.AddInParameter(cmd, "@EmployerName", DbType.String, mEmployerName);
            db.AddInParameter(cmd, "@EmployeeNumber", DbType.Int32, mEmployeeNumber);
        }
        protected void SetErrorDetails(string str)
        {
            mMsgflg = str;
        }
        #endregion
    }
}