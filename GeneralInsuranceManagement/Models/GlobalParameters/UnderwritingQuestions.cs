﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;

namespace GeneralInsuranceManagement.Models.GlobalParameters
{
    public class UnderwritingQuestions
    {
        #region variables
        protected Database db;
        protected string mConnectionName;
        protected long mObjectUserID;
        protected string mMsgflg;
        protected int mId;
        protected string mQuestionType;
        protected string mQuestionDescription;
        protected DateTime mDateModified;
        #endregion
        #region properties
        public int Id { get { return mId; } set { mId = value; } }
        public string MsgFlg { get { return mMsgflg; } set { mMsgflg = value; } }
        public string QuestionType { get { return mQuestionType; } set { mQuestionType = value; } }
        public string QuestionDescription { get { return mQuestionDescription; } set { mQuestionDescription = value; } }
        public DateTime DateModified { get { return mDateModified; } set { mDateModified = value; } }
        public Database Database => db;

        public string OwnerType => GetType().Name;

        public string ConnectionName => mConnectionName;
        #endregion
        public UnderwritingQuestions(string ConnectionName, long ObjectUserID) 
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
        }
        #region methods
        public virtual bool Save()
        {
            DbCommand cmd = db.GetStoredProcCommand("sp_Save_UnderwritingQuestions");
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
            db.AddInParameter(cmd, "@QuestionType", DbType.String, mQuestionType);
            db.AddInParameter(cmd, "@QuestionDescription", DbType.String, mQuestionDescription);
        }
        protected void SetErrorDetails(string str)
        {
            mMsgflg = str;
        }
        #endregion
        public virtual DataSet GetUsers(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }
        protected internal virtual void LoadDataRecord(DataRow rw)
        {
            mId = ((rw["Id"] != DBNull.Value) ? int.Parse(rw["Id"].ToString()) : 0);
            mQuestionType = ((rw["QuestionType"] != DBNull.Value) ? (rw["QuestionType"].ToString()) : "");
            mQuestionDescription = ((rw["QuestionDescription"] != DBNull.Value) ? (rw["QuestionDescription"].ToString()) : "");
            mDateModified = ((rw["DateModified"] != DBNull.Value) ? DateTime.Parse(rw["DateModified"].ToString()) : DateTime.MinValue);

        }
        public virtual bool Retrieve()
        {
            return Retrieve(mId);
        }

        public virtual bool Retrieve(long ID)
        {
            string text = ID <= 0 ? "SELECT * FROM UnderwritingQuestions WHERE ID = " + mId : "SELECT * FROM UnderwritingQuestions WHERE ID = " + ID;
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

                SetErrorDetails("Underwriting Question not found.");
                return false;
            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return false;
            }
        }
        #region "Delete"

        public virtual bool Delete()
        {

            //Return Delete("UPDATE Users SET Deleted = 1 WHERE ID = " & mID) 
            return Delete("DELETE FROM UnderwritingQuestions WHERE ID = " + mId);

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
    }
}