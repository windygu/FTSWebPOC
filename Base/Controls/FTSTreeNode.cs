#region

using System;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Controls {
    public class FTSTreeNode : TreeNode {
        private String m_groupName;
        private object m_value;
        private object m_item;
        private int m_position;
        private object m_extendvalue;

        public FTSTreeNode() {
        }

        public FTSTreeNode(String groupName, String text, object item, object value, int imageIndex,
                           int selectedImgIndex, int position) {
            this.GroupName = groupName;
            this.Text = text;
            this.Item = item;
            this.Value = value;
            this.ExtendValue = null;
            this.ImageIndex = imageIndex;
            this.SelectedImageIndex = selectedImgIndex;
            this.m_position = position;
        }

        public FTSTreeNode(String groupName, String text, object item, object value, object extendvalue, int imageIndex,
                           int selectedImgIndex, int position) {
            this.GroupName = groupName;
            this.Text = text;
            this.Item = item;
            this.Value = value;
            this.ExtendValue = extendvalue;
            this.ImageIndex = imageIndex;
            this.SelectedImageIndex = selectedImgIndex;
            this.m_position = position;
        }

        public FTSTreeNode(String groupName, String text, object item, object value, int position) {
            this.GroupName = groupName;
            this.Text = text;
            this.Item = item;
            this.Value = value;
            this.m_position = position;
        }

        public FTSTreeNode(String groupName, String text, object item, object value, object extendValue, int position) {
            this.GroupName = groupName;
            this.Text = text;
            this.Item = item;
            this.Value = value;
            this.ExtendValue = extendValue;
            this.m_position = position;
        }

        public String GroupName {
            get { return this.m_groupName; }
            set { this.m_groupName = value; }
        }

        public object Item {
            get { return this.m_item; }
            set { this.m_item = value; }
        }

        public object Value {
            get { return this.m_value; }
            set { this.m_value = value; }
        }

        public object ExtendValue {
            get { return this.m_extendvalue; }
            set { this.m_extendvalue = value; }
        }

        public int Position {
            get { return this.m_position; }
        }
    }
}