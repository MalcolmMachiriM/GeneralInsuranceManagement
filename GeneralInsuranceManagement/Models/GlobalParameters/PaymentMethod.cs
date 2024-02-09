using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace GeneralInsuranceManagement.Models.GlobalParameters
{
    public class PaymentMethod
    {
        protected Database db;
        protected string mConnectionName;
        protected int mDescription;
        protected long mObjectUserID;
        protected int mId;
        protected string mMsgflg;

        public int Id { get { return mId; } set { mId = value; } }
        public string MsgFlg { get { return mMsgflg; } set { mMsgflg = value; } }
        public PaymentMethod(string ConnectionName, long ObjectUserID) 
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }

        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_Audit_History");
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
            db.AddInParameter(cmd, "@Id", DbType.Int64, mId);
            //db.AddInParameter(cmd, "@ActionId", DbType.Int32, mActionID);
            //db.AddInParameter(cmd, "@Description", DbType.Int32, mDescription);
            //db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, mCreatedBy);
            //db.AddInParameter(cmd, "@DateOfAction", DbType.String, mDateOfAction);
        }
        protected void SetErrorDetails(string str)
        {
            mMsgflg = str;
        }
    }
}