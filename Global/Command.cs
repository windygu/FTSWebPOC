#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

#endregion

namespace FTS.Global{
    [Serializable]
    public class Command{
        private string mCommandText;
        private int mCommandTimeout;
        private CommandType mCommandType;
        private List<Parameter> mParameters;
        private bool mTransaction;
        private UpdateRowSource mUpdateRowSource;
        private CommandBehavior mCommandBehavior;
        private bool mIsNull = false;

        public Command(){
            this.mIsNull = true;
            this.mParameters = new List<Parameter>();
        }

        public Command(string commandtext, int commandtimeout, CommandType commandtype, DbTransaction transaction,
                       UpdateRowSource updaterowsource){
            this.mCommandText = commandtext;
            this.mCommandTimeout = commandtimeout;
            this.mCommandType = commandtype;
            this.mParameters = new List<Parameter>();
            this.mTransaction = (transaction != null) ? true : false;
            this.mUpdateRowSource = updaterowsource;
            this.mCommandBehavior = CommandBehavior.Default;
        }

        public string CommandText{
            get { return this.mCommandText; }
            set { this.mCommandText = value; }
        }

        public int CommandTimeout{
            get { return this.mCommandTimeout; }
            set { this.mCommandTimeout = value; }
        }

        public CommandType CommandType{
            get { return this.mCommandType; }
            set { this.mCommandType = value; }
        }

        public List<Parameter> Parameters{
            get { return this.mParameters; }
            set { this.mParameters = value; }
        }

        public bool Transaction{
            get { return this.mTransaction; }
            set { this.mTransaction = value; }
        }

        public UpdateRowSource UpdateRowSource{
            get { return this.mUpdateRowSource; }
            set { this.mUpdateRowSource = value; }
        }

        public CommandBehavior CommandBehavior{
            get { return this.mCommandBehavior; }
            set { this.mCommandBehavior = value; }
        }

        public bool IsNull{
            get { return this.mIsNull; }
            set { this.mIsNull = value; }
        }
    }
}