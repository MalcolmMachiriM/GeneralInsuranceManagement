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
        protected string mMethod;
        protected string mCode;
        protected bool mBankDetailsRequired;
        protected bool mMobileNumberRequired;

        public int Id { get { return mId; } set { mId = value; } }
        public string MsgFlg { get { return mMsgflg; } set { mMsgflg = value; } }
        public string Method { get { return mMethod; } set { mMethod = value; } }
        public string Code { get { return mCode; } set { mCode = value; } }
        public bool BankDetailsRequired { get { return mBankDetailsRequired; } set { mBankDetailsRequired = value; } }
        public bool MobileNumberRequired { get { return mMobileNumberRequired; } set { mMobileNumberRequired = value; } }
        public Database Database => db;

        public string OwnerType => GetType().Name;

        public string ConnectionName => mConnectionName;
        public PaymentMethod(string ConnectionName, long ObjectUserID) 
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }

        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_PaymentMethods");
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
            db.AddInParameter(cmd, "@Method", DbType.String, mMethod);
            db.AddInParameter(cmd, "@Code", DbType.String, mCode);
            db.AddInParameter(cmd, "@BankDetailsRequired", DbType.Boolean, mBankDetailsRequired);
            db.AddInParameter(cmd, "@MobileNumberRequired", DbType.Boolean, mMobileNumberRequired);
        }
        protected void SetErrorDetails(string str)
        {
            mMsgflg = str;
        }
    }
}