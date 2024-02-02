using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;

namespace GeneralInsuranceManagement.Models
{
    public class Logs
    {
        protected Database db;
        protected string mConnectionName;
        protected long mObjectUserID;
        protected long mID;
        protected long mActionedByID;
        protected string mDescription;
        protected string mDateOfAction;
        protected string mMsgflg;

        public string MsgFlg { get { return mMsgflg; } set { mMsgflg = value; } }
        public long ID { get { return mID; } set { mID = value; } }
        public long ActionedByID { get { return mID; } set { mID = value; } }
        public string Description { get { return mDescription; } set { mDescription = value; } }
        public string DateOfAction { get { return mDateOfAction; } set { mDateOfAction = value; } }

        public Database Database => db;

        public string OwnerType => GetType().Name;

        public string ConnectionName => mConnectionName;
        public Logs(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }

        public DataSet getAllLogs()
        {
            string text = null;
            text = ("SELECT * FROM Logs WHERE ID = " + mID);
            return ReturnDs(text);
        }
        public virtual bool Retrieve()
        {
            return Retrieve(mID);
        }

        public virtual bool Retrieve(long ID)
        {
            string text = null;
            text = ((ID <= 0) ? ("SELECT * FROM Logs WHERE ID = " + mID) : ("SELECT * FROM Logs WHERE ID = " + ID));
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

                SetErrorDetails("Log not found.");
                return false;
            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return false;
            }
        }

        protected DataSet ReturnDs(string str)
        {
            try
            {
                DataSet dataSet = db.ExecuteDataSet(CommandType.Text, str);
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return dataSet;
                }

                return null;
            }
            catch (Exception ex)
            {
                mMsgflg = ex.Message;
                return null;
            }
        }
        protected internal virtual void LoadDataRecord(DataRow rw)
        {
            mID = ((rw["ID"] != DBNull.Value) ? int.Parse(rw["ID"].ToString()) : 0);
            mActionedByID = ((rw["ActionedBy"] != DBNull.Value) ? int.Parse(rw["ActionedBy"].ToString()) : 0);
            mDateOfAction = ((rw["DateOfAction"] == DBNull.Value) ? string.Empty : rw["DateOfAction"].ToString());
            mDescription = ((rw["Description"] == DBNull.Value) ? string.Empty : rw["Description"].ToString());
        }
        protected void SetErrorDetails(string str)
        {
            mMsgflg = str;
        }
    }
}