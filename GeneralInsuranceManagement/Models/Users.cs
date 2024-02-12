using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;

namespace GeneralInsuranceManagement.Models
{
    public class Users
    {
        #region "Variables"

        protected string mLastPasswordUpdatedOn;
        protected long mID;
        protected long mUserRoleID;
        protected long mDepartmentID;
        protected long mStatusID;
        protected long mCreatedBy;
        protected string mDateCreated;
        protected bool mPasswordExpires;
        protected bool mAllowPasswordReuse;
        protected decimal mPasswordLifeSpan;
        protected string mUsername;
        protected string mFirstnames;
        protected string mSurname;
        protected string mPassword;
        protected string mLastUsedPassword;
        protected string mContactNumber;
        protected string mEmailAddress;

        protected string mMsgflg;
        protected Database db;
        protected string mConnectionName;

        protected long mObjectUserID;
        #endregion

        #region "Properties"

        public string ContactNumber
        {
            get { return mContactNumber; }
            set { mContactNumber = value; }
        }
        public string EmailAddress
        {
            get { return mEmailAddress; }
            set { mEmailAddress = value; }
        }
        public string MsgFlg
        {

            get { return mMsgflg; }
            set { mMsgflg = value; }
        }
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

        public string LastPasswordUpdatedOn
        {
            get { return mLastPasswordUpdatedOn; }
            set { mLastPasswordUpdatedOn = value; }
        }

        public long ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public long UserRoleID
        {
            get { return mUserRoleID; }
            set { mUserRoleID = value; }
        }

        public long DepartmentID
        {
            get { return mDepartmentID; }
            set { mDepartmentID = value; }
        }

        public long StatusID
        {
            get { return mStatusID; }
            set { mStatusID = value; }
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

        public bool PasswordExpires
        {
            get { return mPasswordExpires; }
            set { mPasswordExpires = value; }
        }

        public bool AllowPasswordReuse
        {
            get { return mAllowPasswordReuse; }
            set { mAllowPasswordReuse = value; }
        }

        public decimal PasswordLifeSpan
        {
            get { return mPasswordLifeSpan; }
            set { mPasswordLifeSpan = value; }
        }

        public string Username
        {
            get { return mUsername; }
            set { mUsername = value; }
        }

        public string Firstnames
        {
            get { return mFirstnames; }
            set { mFirstnames = value; }
        }

        public string Surname
        {
            get { return mSurname; }
            set { mSurname = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public string LastUsedPassword
        {
            get { return mLastUsedPassword; }
            set { mLastUsedPassword = value; }
        }

        #endregion

        #region "Methods"

        #region "Constructors"


        public Users(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion


        public void Clear()
        {
            mLastPasswordUpdatedOn = "";
            mID = 0;
            mUserRoleID = 0;
            mDepartmentID = 0;
            mStatusID = 0;
            mCreatedBy = mObjectUserID;
            mDateCreated = "";
            mPasswordExpires = false;
            mAllowPasswordReuse = false;
            mPasswordLifeSpan = 0;
            mUsername = "";
            mFirstnames = "";
            mSurname = "";
            mPassword = "";
            mLastUsedPassword = "";

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
                sql = "SELECT * FROM Users WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM Users WHERE ID = " + mID;
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
                    SetErrorDetails("Users not found.");

                    return false;

                }


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }
        protected DataSet ReturnDs(string str)
        {
            try
            {
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgflg = ex.Message;
                return null;
            }
        }
        public DataSet getUserRoles()
        {
            try
            {
                string str = "select * from userRoles";
                return ReturnDs(str);

            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return null;
            }
        }
        public DataSet getDepartments()
        {
            string str = "select * from Departments";
            return ReturnDs(str);
        }
        public DataSet getSavedUsers()
        {
            string str = "select U.ID ,U.Username,U.Surname,U.Firstnames ,Ur.Description as UserRole,D.DepartmentName from Users U  inner join UserRoles Ur on Ur.ID=U.UserRoleID INNER JOIN Departments D on D.ID=U.DepartmentID ";
            return ReturnDs(str);
        }
        public virtual System.Data.DataSet GetUsers()
        {

            return GetUsers(mID);

        }

        public virtual DataSet GetUsers(long ID)
        {

            string sql = null;

            if (ID > 0)
            {
                sql = "SELECT * FROM Users WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM Users WHERE ID = " + mID;
            }

            return GetUsers(sql);

        }

        public bool ActionUserAccountStatusRequest(int UserID, int ApprovalStatusID, int NewAccountAccountStatusID, int RequestID)
        {
            try
            {
                string str = "update Users set StatusID=" + NewAccountAccountStatusID + " where ID=" + UserID + "";
                db.ExecuteNonQuery(CommandType.Text, str);

                str = "update UserAccountsAuthorizationLog set ApprovalStatusID=" + ApprovalStatusID + ", ApprovalBy=" + mObjectUserID + ", ApprovalDate=getDate() where ID=" + RequestID + "";
                db.ExecuteNonQuery(CommandType.Text, str);
                return true;
            }
            catch (Exception ex)
            {
                mMsgflg = ex.Message;
                return false;
            }
        }

        public DataSet getUserAccountsByStatus(int StatusID)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("getUserAccountByStatus");
                db.AddInParameter(cmd, "@StatusID", DbType.Int32, StatusID);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {
                mMsgflg = ex.Message;
                return null;
            }
        }

        public virtual DataSet GetUsers(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }
        protected void SetErrorDetails(string str)
        {
            mMsgflg = str;
        }
        #endregion


        protected internal virtual void LoadDataRecord(DataRow rw)
        {

            mLastPasswordUpdatedOn = ((rw["DateCreated"] == DBNull.Value) ? string.Empty : rw["DateCreated"].ToString());
            mID = ((rw["ID"] != DBNull.Value) ? int.Parse(rw["ID"].ToString()) : 0);
            mUserRoleID = ((rw["UserRoleID"] != DBNull.Value) ? int.Parse(rw["UserRoleID"].ToString()) : 0);
            mDepartmentID = ((rw["DepartmentID"] != DBNull.Value) ? int.Parse(rw["DepartmentID"].ToString()) : 0);
            mStatusID = ((rw["StatusID"] != DBNull.Value) ? int.Parse(rw["StatusID"].ToString()) : 0);
            mCreatedBy = ((rw["CreatedBy"] != DBNull.Value) ? int.Parse(rw["CreatedBy"].ToString()) : 0);
            mDateCreated = ((rw["DateCreated"] == DBNull.Value) ? string.Empty : rw["DateCreated"].ToString());
            mPasswordExpires = ((rw["PasswordExpires"] != DBNull.Value) ? bool.Parse(rw["PasswordExpires"].ToString()) : false);
            mAllowPasswordReuse = ((rw["AllowPasswordReuse"] != DBNull.Value) ? bool.Parse(rw["AllowPasswordReuse"].ToString()) : false);
            mPasswordLifeSpan = ((rw["PasswordLifeSpan"] != DBNull.Value) ? int.Parse(rw["PasswordLifeSpan"].ToString()) : 0);
            mUsername = ((rw["Username"] == DBNull.Value) ? string.Empty : rw["Username"].ToString());
            mFirstnames = ((rw["Firstnames"] == DBNull.Value) ? string.Empty : rw["Firstnames"].ToString());
            mSurname = ((rw["Surname"] == DBNull.Value) ? string.Empty : rw["Surname"].ToString());

            mContactNumber = ((rw["ContactNumber"] == DBNull.Value) ? string.Empty : rw["ContactNumber"].ToString());
            mEmailAddress = ((rw["EmailAddress"] == DBNull.Value) ? string.Empty : rw["EmailAddress"].ToString());

            mPassword = ((rw["Password"] == DBNull.Value) ? string.Empty : rw["Password"].ToString());
            mLastUsedPassword = ((rw["LastUsedPassword"] == DBNull.Value) ? string.Empty : rw["LastUsedPassword"].ToString());


        }

        #region "Save"


        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@LastPasswordUpdatedOn", DbType.Date, mLastPasswordUpdatedOn);
            db.AddInParameter(cmd, "@ID", DbType.Int32, mID);
            db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, mObjectUserID);
            db.AddInParameter(cmd, "@UserRoleID", DbType.Int32, mUserRoleID);
            db.AddInParameter(cmd, "@DepartmentID", DbType.Int32, mDepartmentID);
            db.AddInParameter(cmd, "@StatusID", DbType.Int32, mStatusID);
            db.AddInParameter(cmd, "@DateCreated", DbType.String, mDateCreated);
            db.AddInParameter(cmd, "@PasswordExpires", DbType.Boolean, mPasswordExpires);
            db.AddInParameter(cmd, "@AllowPasswordReuse", DbType.Boolean, mAllowPasswordReuse);
            db.AddInParameter(cmd, "@PasswordLifeSpan", DbType.Decimal, mPasswordLifeSpan);
            db.AddInParameter(cmd, "@Username", DbType.String, mUsername);
            db.AddInParameter(cmd, "@Firstnames", DbType.String, mFirstnames);
            db.AddInParameter(cmd, "@Surname", DbType.String, mSurname);

            db.AddInParameter(cmd, "@ContactNumber", DbType.String, mContactNumber);
            db.AddInParameter(cmd, "@EmailAddress", DbType.String, mEmailAddress);

            db.AddInParameter(cmd, "@Password", DbType.String, mPassword);
            db.AddInParameter(cmd, "@LastUsedPassword", DbType.String, mLastUsedPassword);

        }

        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_Users");

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

            //Return Delete("UPDATE Users SET Deleted = 1 WHERE ID = " & mID) 
            return Delete("DELETE FROM Users WHERE ID = " + mID);

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

        #endregion

        #endregion
    }
}