// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:48
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FTSGroupTree.cs
// Project Item Filename:     FTSGroupTree.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;

#endregion

namespace FTS.BaseUI.Controls {
    public class FTSGroupTree {
        private String groupName;
        private String groupByMember;
        private String groupByDisplayMember;
        private String groupByValueMember;
        private String groupByExtendValueMember;

        private int groupImageIndex;
        private int groupSelectedImageIndex;

        public FTSGroupTree(String name, String groupBy, String displayMember, String valueMember,
                            String extendValueMember, int imageIndex, int selectedImageIndex) {
            this.ImageIndex = imageIndex;
            this.Name = name;
            this.GroupBy = groupBy;
            this.DisplayMember = displayMember;
            this.ValueMember = valueMember;
            this.ExtendValueMember = extendValueMember;
            this.SelectedImageIndex = selectedImageIndex;
        }

        public FTSGroupTree(String name, String groupBy, String displayMember, String valueMember, int imageIndex,
                            int selectedImageIndex)
            : this(name, groupBy, displayMember, valueMember, null, imageIndex, selectedImageIndex) {
        }

        public FTSGroupTree(String name, String groupBy, String displayMember, String valueMember, int imageIndex)
            : this(name, groupBy, displayMember, valueMember, imageIndex, imageIndex) {
        }

        public FTSGroupTree(String name, String groupBy) : this(name, groupBy, groupBy, groupBy, -1, -1) {
        }

        public int SelectedImageIndex {
            get { return this.groupSelectedImageIndex; }
            set { this.groupSelectedImageIndex = value; }
        }

        public int ImageIndex {
            get { return this.groupImageIndex; }
            set { this.groupImageIndex = value; }
        }

        public String Name {
            get { return this.groupName; }
            set { this.groupName = value; }
        }

        public String GroupBy {
            get { return this.groupByMember; }
            set { this.groupByMember = value; }
        }

        public String DisplayMember {
            get { return this.groupByDisplayMember; }
            set { this.groupByDisplayMember = value; }
        }

        public String ValueMember {
            get { return this.groupByValueMember; }
            set { this.groupByValueMember = value; }
        }

        public String ExtendValueMember {
            get { return this.groupByExtendValueMember; }
            set { this.groupByExtendValueMember = value; }
        }
    }
}