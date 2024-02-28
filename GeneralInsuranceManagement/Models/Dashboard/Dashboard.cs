using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;

namespace GeneralInsuranceManagement.Models.Dashboard
{
    public class Dashboard
    {
        protected Database db;
        protected string mConnectionsName;
        protected int mDescription;
        protected long mObjectUserID;
        protected int mId;
        protected string mMSgflg;

        public int Id { get { return mId; } set { mId = value; } }
        public string MSgflg { get { return mMSgflg; }set { mMSgflg = value; } }
        public Database Database => db;

        public string OwnerType => GetType().Name;
        public string ConnectionName => mConnectionsName;
        public Dashboard(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionsName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }

        public virtual DataSet GetStats()
        {
            DbCommand cmd = db.GetStoredProcCommand("GetData");
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual DataSet GetNewStats()
        {
            DbCommand cmd = db.GetStoredProcCommand("NewData");
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual DataSet GetDataTable()
        {
            DbCommand cmd = db.GetStoredProcCommand("DataTable");
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}