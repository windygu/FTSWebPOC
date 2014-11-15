// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:47
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         ObjectInfo.cs
// Project Item Filename:     ObjectInfo.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

namespace FTS.BaseBusiness.Classes {
    public class ObjectInfo {
        private string mID;
        private string mName;
        private object mTag;

        public ObjectInfo(string id, string name) {
            this.mID = id;
            this.mName = name;
        }

        public ObjectInfo(string id, string name, object tag) {
            this.mID = id;
            this.mName = name;
            this.mTag = tag;
        }

        public string ID {
            get { return this.mID; }
            set { this.mID = value; }
        }

        public string Name {
            get { return this.mName; }
            set { this.mName = value; }
        }

        public object Tag {
            get { return this.mTag; }
            set { this.mTag = value; }
        }

        public override string ToString() {
            return this.mName;
        }
    }
}