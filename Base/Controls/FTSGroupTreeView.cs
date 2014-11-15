#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Controls {
    public class FTSGroupTreeView : TreeView {
        private Container components = null;

        public FTSGroupTreeView() {
            this.InitializeComponent();
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
        }

        #endregion

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }

        private bool m_autoBuild = true;

        public bool AutoBuildTree {
            get { return this.m_autoBuild; }
            set { this.m_autoBuild = value; }
        }

        private CurrencyManager m_currencyManager = null;
        private String m_ValueMember;
        private String m_DisplayMember;
        private object m_oDataSource;
        private DataView dtview;

        public object DataSource {
            get { return this.m_oDataSource; }
            set {
                if (value == null) {
                    this.m_currencyManager = null;
                    this.Nodes.Clear();
                } else {
                    if (!(value is IList || this.m_oDataSource is IListSource)) {
                        throw (new Exception("Invalid DataSource"));
                    } else {
                        if (value is IListSource) {
                            IListSource myListSource = (IListSource) value;
                            if (myListSource.ContainsListCollection == true) {
                                throw (new Exception("Invalid DataSource"));
                            }
                        }
                        this.m_oDataSource = value;
                        this.m_currencyManager = (CurrencyManager) this.BindingContext[value];
                        this.dtview = (DataView) this.m_currencyManager.List;
                        if (this.AutoBuildTree) {
                            this.BuildTree();
                        }
                    }
                }
            }
        }

        // end of DataSource property

        [Category("Data")]
        public string ValueMember {
            get { return this.m_ValueMember; }
            set { this.m_ValueMember = value; }
        }

        public string DisplayMember {
            get { return this.m_DisplayMember; }
            set { this.m_DisplayMember = value; }
        }

        public object GetValue(int index) {
            IList innerList = this.m_currencyManager.List;
            if (innerList != null) {
                if ((this.ValueMember != "") && (index >= 0 && 0 < innerList.Count)) {
                    int index_value = this.dtview.Table.Columns.IndexOf(this.ValueMember);
                    PropertyDescriptor pdValueMember;
                    pdValueMember = this.m_currencyManager.GetItemProperties()[this.ValueMember];
                    return pdValueMember.GetValue(innerList[index]);
                }
            }
            return null;
        }

        public object GetDisplay(int index) {
            IList innerList = this.m_currencyManager.List;
            if (innerList != null) {
                if ((this.DisplayMember != "") && (index >= 0 && 0 < innerList.Count)) {
                    int index_value = this.dtview.Table.Columns.IndexOf(this.ValueMember);
                    PropertyDescriptor pdDisplayMember;
                    pdDisplayMember = this.m_currencyManager.GetItemProperties()[this.ValueMember];
                    return pdDisplayMember.GetValue(innerList[index]);
                }
            }
            return null;
        }

        #region Building the Tree

        private ArrayList treeGroups = new ArrayList();

        public void BuildTree() {
            this.Nodes.Clear();
            if ((this.m_currencyManager != null) && (this.m_currencyManager.List != null)) {
                IList innerList = this.m_currencyManager.List;
                TreeNodeCollection currNode = this.Nodes;
                int currGroupIndex = 0;
                int currListIndex = 0;
                int treegroupcount = this.treeGroups.Count;
                if (this.treeGroups.Count > currGroupIndex) {
                    FTSGroup currGroup = (FTSGroup) this.treeGroups[currGroupIndex];
                    FTSGroupTreeNode myFirstNode = null;
                    PropertyDescriptor pdGroupBy;
                    PropertyDescriptor pdValue;
                    PropertyDescriptor pdDisplay;
                    pdGroupBy = this.m_currencyManager.GetItemProperties()[currGroup.GroupBy];
                    pdValue = this.m_currencyManager.GetItemProperties()[currGroup.ValueMember];
                    pdDisplay = this.m_currencyManager.GetItemProperties()[currGroup.DisplayMember];
                    string currGroupBy = null;
                    int innerListCount = innerList.Count;
                    if (innerList.Count > currListIndex) {
                        object currObject;
                        int innerListCount1 = innerList.Count;
                        while (currListIndex < innerList.Count) {
                            currObject = innerList[currListIndex];
                            if (pdGroupBy.GetValue(currObject).ToString() != currGroupBy) {
                                currGroupBy = pdGroupBy.GetValue(currObject).ToString();
                                myFirstNode = new FTSGroupTreeNode(currGroup.Name,
                                                                   pdDisplay.GetValue(currObject).ToString(), currObject,
                                                                   pdValue.GetValue(innerList[currListIndex]),
                                                                   currGroup.ImageIndex, currGroup.SelectedImageIndex,
                                                                   currListIndex);
                                currNode.Add((FTSGroupTreeNode) myFirstNode);
                            } else {
                                this.AddNodes(currGroupIndex, ref currListIndex, myFirstNode.Nodes, currGroup.GroupBy);
                            }
                        } // end while
                    } // end if
                } // end if
                else {
                    while (currListIndex < innerList.Count) {
                        this.AddNodes(currGroupIndex, ref currListIndex, this.Nodes, "");
                    }
                } // end else
                if (this.Nodes.Count > 0) {
                    this.SelectedNode = this.Nodes[0];
                }
            } // end if
        }

        private void AddNodes(int currGroupIndex, ref int currentListIndex, TreeNodeCollection currNodes,
                              String prevGroupByField) {
            IList innerList = this.m_currencyManager.List;
            PropertyDescriptor pdPrevGroupBy = null;
            string prevGroupByValue = null;
            ;
            FTSGroup currGroup;
            if (prevGroupByField != "") {
                pdPrevGroupBy = this.m_currencyManager.GetItemProperties()[prevGroupByField];
            }
            int currGroupindex = currGroupIndex;
            currGroupIndex += 1;
            if (this.treeGroups.Count > currGroupIndex) {
                currGroup = (FTSGroup) this.treeGroups[currGroupIndex];
                PropertyDescriptor pdGroupBy = null;
                PropertyDescriptor pdValue = null;
                PropertyDescriptor pdDisplay = null;
                pdGroupBy = this.m_currencyManager.GetItemProperties()[currGroup.GroupBy];
                pdValue = this.m_currencyManager.GetItemProperties()[currGroup.ValueMember];
                pdDisplay = this.m_currencyManager.GetItemProperties()[currGroup.DisplayMember];
                string currGroupBy = null;
                int innerListcount = innerList.Count;
                if (innerList.Count > currentListIndex) {
                    if (pdPrevGroupBy != null) {
                        prevGroupByValue = pdPrevGroupBy.GetValue(innerList[currentListIndex]).ToString();
                    }
                    FTSGroupTreeNode myFirstNode = null;
                    object currObject = null;
                    while ((currentListIndex < innerList.Count) && (pdPrevGroupBy != null) &&
                           (pdPrevGroupBy.GetValue(innerList[currentListIndex]).ToString() == prevGroupByValue)) {
                        currObject = innerList[currentListIndex];
                        if (pdGroupBy.GetValue(currObject).ToString() != currGroupBy &&
                            pdGroupBy.GetValue(currObject).ToString() != "") {
                            currGroupBy = pdGroupBy.GetValue(currObject).ToString();
                            myFirstNode = new FTSGroupTreeNode(currGroup.Name, pdDisplay.GetValue(currObject).ToString(),
                                                               currObject, pdValue.GetValue(innerList[currentListIndex]),
                                                               currGroup.ImageIndex, currGroup.SelectedImageIndex,
                                                               currentListIndex);
                            currNodes.Add((FTSGroupTreeNode) myFirstNode);
                        } else if (pdGroupBy.GetValue(currObject).ToString() == currGroupBy) {
                            this.AddNodes(currGroupIndex, ref currentListIndex, myFirstNode.Nodes, currGroup.GroupBy);
                        } else if (pdGroupBy.GetValue(currObject).ToString() == "") {
                            currentListIndex += 1;
                        }
                    }
                }
            } else {
                FTSGroupTreeNode myNewLeafNode;
                object currObject = this.m_currencyManager.List[currentListIndex];
                if ((this.DisplayMember != null) && (this.ValueMember != null) && (this.DisplayMember != "") &&
                    (this.ValueMember != "")) {
                    PropertyDescriptor pdDisplayloc = this.m_currencyManager.GetItemProperties()[this.DisplayMember];
                    PropertyDescriptor pdValueloc = this.m_currencyManager.GetItemProperties()[this.ValueMember];
                    myNewLeafNode = new FTSGroupTreeNode(this.Tag == null ? "" : this.Tag.ToString(),
                                                         pdDisplayloc.GetValue(currObject).ToString(), currObject,
                                                         pdValueloc.GetValue(currObject), currentListIndex);
                    if (pdDisplayloc.GetValue(currObject).ToString() != "") {
                        currNodes.Add((FTSGroupTreeNode) myNewLeafNode);
                    }
                    currentListIndex += 1;
                } else {
                    myNewLeafNode = new FTSGroupTreeNode("", currentListIndex.ToString(), currObject, currObject,
                                                         this.ImageIndex, this.SelectedImageIndex, currentListIndex);
                    currNodes.Add((FTSGroupTreeNode) myNewLeafNode);
                    currentListIndex += 1;
                }
            }
        }

        #endregion

        #region Groups

        public void RemoveGroup(FTSGroup group) {
            try {
                if (this.treeGroups.Contains(group)) {
                    this.treeGroups.Remove(group);
                    if (this.AutoBuildTree) {
                        this.BuildTree();
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void RemoveGroup(string groupName) {
            try {
                foreach (FTSGroup group in this.treeGroups) {
                    if (group.Name == groupName) {
                        RemoveGroup(group);
                        return;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void RemoveAllGroups() {
            try {
                this.treeGroups.Clear();
                if (this.AutoBuildTree) {
                    this.BuildTree();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void AddGroup(FTSGroup group) {
            try {
                this.treeGroups.Add(group);
                if (this.AutoBuildTree) {
                    this.BuildTree();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void AddGroup(String name, String groupBy, String displayMember, String valueMember, int imageIndex,
                             int selectedImageIndex) {
            try {
                FTSGroup myNewGroup = new FTSGroup(name, groupBy, displayMember, valueMember, imageIndex,
                                                   selectedImageIndex);
                this.AddGroup(myNewGroup);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public FTSGroup[] GetGroups() {
            return ((FTSGroup[]) this.treeGroups.ToArray(Type.GetType("Group")));
        }

        #endregion

        public void SetLeafData(String name, String displayMember, String valueMember, int imageIndex,
                                int selectedImageIndex) {
            try {
                this.Tag = name;
                this.DisplayMember = displayMember;
                this.ValueMember = valueMember;
                this.ImageIndex = imageIndex;
                this.SelectedImageIndex = selectedImageIndex;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool IsLeafNode(TreeNode node) {
            return (node.Nodes.Count == 0);
        }

        #region Keeping Everything In Sync

        public TreeNode FindNodeByValue(object value) {
            return this.FindNodeByValue(value, this.Nodes);
        }

        public TreeNode FindNodeByValue(object Value, TreeNodeCollection nodesToSearch) {
            int i = 0;
            TreeNode currNode;
            FTSGroupTreeNode leafNode;
            while (i < nodesToSearch.Count) {
                currNode = nodesToSearch[i];
                i ++;
                if (currNode.LastNode == null) {
                    leafNode = (FTSGroupTreeNode) currNode;
                    if (leafNode.Value.ToString() == Value.ToString()) {
                        return currNode;
                    }
                } else {
                    currNode = this.FindNodeByValue(Value, currNode.Nodes);
                    if (currNode != null) {
                        return currNode;
                    }
                }
            }
            return null;
        }

        private TreeNode FindNodeByPosition(int posIndex) {
            return this.FindNodeByPosition(posIndex, this.Nodes);
        }

        private TreeNode FindNodeByPosition(int posIndex, TreeNodeCollection nodesToSearch) {
            int i = 0;
            TreeNode currNode;
            FTSGroupTreeNode leafNode;
            while (i < nodesToSearch.Count) {
                currNode = nodesToSearch[i];
                i++;
                if (currNode.Nodes.Count == 0) {
                    leafNode = (FTSGroupTreeNode) currNode;
                    if (leafNode.Position == posIndex) {
                        return currNode;
                    } else {
                        currNode = this.FindNodeByPosition(posIndex, currNode.Nodes);
                        if (currNode != null) {
                            return currNode;
                        }
                    }
                }
            }
            return null;
        }

        protected override void OnAfterSelect(TreeViewEventArgs e) {
            FTSGroupTreeNode leafNode = (FTSGroupTreeNode) e.Node;
            if (leafNode != null) {
                if (this.m_currencyManager.Position != leafNode.Position) {
                    this.m_currencyManager.Position = leafNode.Position;
                }
            }
            // TODO:  Add MyTreeViewCtrl.OnAfterSelect implementation
            base.OnAfterSelect(e);
        }

        #endregion
    }

    public class FTSGroup {
        private String groupName;
        private String groupByMember;
        private String groupByDisplayMember;
        private String groupByValueMember;

        private int groupImageIndex;
        private int groupSelectedImageIndex;

        public FTSGroup(String name, String groupBy, String displayMember, String valueMember, int imageIndex,
                        int selectedImageIndex) {
            this.ImageIndex = imageIndex;
            this.Name = name;
            this.GroupBy = groupBy;
            this.DisplayMember = displayMember;
            this.ValueMember = valueMember;
            this.SelectedImageIndex = selectedImageIndex;
        }

        public FTSGroup(String name, String groupBy, String displayMember, String valueMember, int imageIndex)
            : this(name, groupBy, displayMember, valueMember, imageIndex, imageIndex) {
        }

        public FTSGroup(String name, String groupBy) : this(name, groupBy, groupBy, groupBy, -1, -1) {
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
    }

    public class FTSGroupTreeNode : TreeNode {
        private String m_groupName;
        private object m_value;
        private object m_item;
        private int m_position;

        public FTSGroupTreeNode() {
        }

        public FTSGroupTreeNode(String groupName, String text, object item, object value, int imageIndex,
                                int selectedImgIndex, int position) {
            this.GroupName = groupName;
            this.Text = text;
            this.Item = item;
            this.Value = value;
            this.ImageIndex = imageIndex;
            this.SelectedImageIndex = selectedImgIndex;
            this.m_position = position;
        }

        public FTSGroupTreeNode(String groupName, String text, object item, object value, int position) {
            this.GroupName = groupName;
            this.Text = text;
            this.Item = item;
            this.Value = value;
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

        public int Position {
            get { return this.m_position; }
        }
    }
}