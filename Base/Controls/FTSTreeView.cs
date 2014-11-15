// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/28/2006
// Time:                      22:49
// Project Name:              Base
// Project Filename:          Base.csproj
// Project Item Name:         FTSTreeView.cs
// Project Item Filename:     FTSTreeView.cs
// Project Item Kind:         Component
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

#endregion

namespace FTS.BaseUI.Controls {
    /// <summary>
    /// Summary description for WTree.
    /// </summary>
    public class FTSTreeView : TreeView {
        // Fields
        private Container components;
        private TreeNode m_current_node;
        private int m_FolderOpenImg;
        private bool m_lock;
        private int m_StateImage;
        private bool m_UseNodeImages;
        private bool m_autoBuild = true;
        private ArrayList treeGroups = new ArrayList();
        private CurrencyManager m_currencyManager = null;
        private String m_ValueMember;
        private String m_ExtendValueMember;
        private String m_DisplayMember;
        private object m_oDataSource;
        private bool needUpdate = false;

        public FTSTreeView() {
            this.m_current_node = null;
            this.m_StateImage = -1;
            this.m_FolderOpenImg = -1;
            this.m_UseNodeImages = false;
            this.m_lock = false;
            this.InitializeComponent();
        }

        private void Check_Childs(TreeNode node, bool node_state) {
            foreach (TreeNode node1 in node.Nodes) {
                if (node1.Nodes.Count > 0) {
                    this.Check_Childs(node1, node_state);
                }
                node1.Checked = node_state;
            }
        }

        private void Check_Parents(TreeNode node, bool node_state) {
            for (TreeNode node1 = node.Parent; node1 != null; node1 = node1.Parent) {
                if (node_state) {
                    node1.Checked = true;
                    node1.ImageIndex = this.m_FolderOpenImg;
                } else if (this.Is_Last_UnChecked(node1)) {
                    node1.Checked = false;
                    node1.ImageIndex = this.m_StateImage;
                }
            }
        }

        protected override void Dispose(bool disposing) {
            if (disposing && (this.components != null)) {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.components = new Container();
        }

        private bool Is_Last_UnChecked(TreeNode node) {
            for (TreeNode node1 = node.FirstNode; node1 != null; node1 = node1.NextNode) {
                if (node1.Checked) {
                    return false;
                }
            }
            return true;
        }

        public TreeNode Loop_Tree() {
            TreeNode node1 = null;
            TreeNode node2;
            if (this.m_current_node == null) {
                this.m_current_node = node2 = base.Nodes[0];
                return node2;
            }
            if (this.m_current_node.Nodes.Count > 0) {
                this.m_current_node = node2 = this.m_current_node.Nodes[0];
                return node2;
            }
            if (this.m_current_node.NextNode != null) {
                this.m_current_node = node2 = this.m_current_node.NextNode;
                return node2;
            }
            for (node1 = this.m_current_node; node1 != null; node1 = node1.Parent) {
                if (node1.NextNode != null) {
                    this.m_current_node = node2 = node1.NextNode;
                    return node2;
                }
            }
            this.m_current_node = null;
            return this.m_current_node;
        }

        public TreeNode Loop_Tree(bool start_first) {
            this.m_current_node = null;
            return this.Loop_Tree();
        }

        public object GetValue(int index) {
            IList innerList = this.m_currencyManager.List;
            if (innerList != null) {
                if ((this.ValueMember.Length != 0) && (index >= 0 && 0 < innerList.Count)) {
                    PropertyDescriptor pdValueMember;
                    pdValueMember = this.m_currencyManager.GetItemProperties()[this.ValueMember];
                    return pdValueMember.GetValue(innerList[index]);
                }
            }
            return null;
        }

        public object GetExtendValue(int index) {
            IList innerList = this.m_currencyManager.List;
            if (innerList != null) {
                if ((this.ValueMember.Length != 0) && (index >= 0 && 0 < innerList.Count)) {
                    PropertyDescriptor pdExtendValueMember;
                    pdExtendValueMember = this.m_currencyManager.GetItemProperties()[this.ExtendValueMember];
                    return pdExtendValueMember.GetValue(innerList[index]);
                }
            }
            return null;
        }

        public object GetDisplay(int index) {
            IList innerList = this.m_currencyManager.List;
            if (innerList != null) {
                if ((this.DisplayMember.Length != 0) && (index >= 0 && 0 < innerList.Count)) {
                    PropertyDescriptor pdDisplayMember;
                    pdDisplayMember = this.m_currencyManager.GetItemProperties()[this.DisplayMember];
                    return pdDisplayMember.GetValue(innerList[index]);
                }
            }
            return null;
        }

        public void BuildTree() {
            this.Nodes.Clear();
            if ((this.m_currencyManager != null) && (this.m_currencyManager.List != null)) {
                IList innerList = this.m_currencyManager.List;
                TreeNodeCollection currNode = this.Nodes;
                int currGroupIndex = 0;
                int currListIndex = 0;
                if (this.treeGroups.Count > currGroupIndex) {
                    FTSGroupTree currGroup = (FTSGroupTree) this.treeGroups[currGroupIndex];
                    FTSTreeNode myFirstNode = null;
                    PropertyDescriptor pdGroupBy;
                    PropertyDescriptor pdValue;
                    PropertyDescriptor pdExtendValue;
                    PropertyDescriptor pdDisplay;
                    pdGroupBy = this.m_currencyManager.GetItemProperties()[currGroup.GroupBy];
                    pdValue = this.m_currencyManager.GetItemProperties()[currGroup.ValueMember];
                    pdExtendValue = this.m_currencyManager.GetItemProperties()[currGroup.ExtendValueMember];
                    pdDisplay = this.m_currencyManager.GetItemProperties()[currGroup.DisplayMember];
                    string currGroupBy = null;
                    if (innerList.Count > currListIndex) {
                        object currObject;
                        while (currListIndex < innerList.Count) {
                            currObject = innerList[currListIndex];
                            if (pdGroupBy.GetValue(currObject).ToString() != currGroupBy) {
                                currGroupBy = pdGroupBy.GetValue(currObject).ToString();
                                myFirstNode = new FTSTreeNode(currGroup.Name, pdDisplay.GetValue(currObject).ToString(),
                                                              currObject, pdValue.GetValue(innerList[currListIndex]),
                                                              pdExtendValue.GetValue(innerList[currListIndex]),
                                                              currGroup.ImageIndex, currGroup.SelectedImageIndex,
                                                              currListIndex);
                                currNode.Add((TreeNode) myFirstNode);
                            } else {
                                this.AddNodes(currGroupIndex, ref currListIndex, myFirstNode.Nodes, currGroup.GroupBy);
                            }
                        }
                    }
                } else {
                    while (currListIndex < innerList.Count) {
                        this.AddNodes(currGroupIndex, ref currListIndex, this.Nodes, string.Empty);
                    }
                }
                if (this.Nodes.Count > 0) {
                    this.SelectedNode = this.Nodes[0];
                }
            }
        }

        private void AddNodes(int currGroupIndex, ref int currentListIndex, TreeNodeCollection currNodes,
                              String prevGroupByField) {
            IList innerList = this.m_currencyManager.List;
            PropertyDescriptor pdPrevGroupBy = null;
            string prevGroupByValue = null;
            ;
            FTSGroupTree currGroup;
            if (prevGroupByField.Length != 0) {
                pdPrevGroupBy = this.m_currencyManager.GetItemProperties()[prevGroupByField];
            }
            currGroupIndex += 1;
            if (this.treeGroups.Count > currGroupIndex) {
                currGroup = (FTSGroupTree) this.treeGroups[currGroupIndex];
                PropertyDescriptor pdGroupBy = null;
                PropertyDescriptor pdValue = null;
                PropertyDescriptor pdExtendValue = null;
                PropertyDescriptor pdDisplay = null;
                pdGroupBy = this.m_currencyManager.GetItemProperties()[currGroup.GroupBy];
                pdValue = this.m_currencyManager.GetItemProperties()[currGroup.ValueMember];
                pdExtendValue = this.m_currencyManager.GetItemProperties()[currGroup.ExtendValueMember];
                pdDisplay = this.m_currencyManager.GetItemProperties()[currGroup.DisplayMember];
                string currGroupBy = null;
                if (innerList.Count > currentListIndex) {
                    if (pdPrevGroupBy != null) {
                        prevGroupByValue = pdPrevGroupBy.GetValue(innerList[currentListIndex]).ToString();
                    }
                    FTSTreeNode myFirstNode = null;
                    object currObject = null;
                    while ((currentListIndex < innerList.Count) && (pdPrevGroupBy != null) &&
                           (pdPrevGroupBy.GetValue(innerList[currentListIndex]).ToString() == prevGroupByValue)) {
                        currObject = innerList[currentListIndex];
                        if (pdGroupBy.GetValue(currObject).ToString() != currGroupBy) {
                            currGroupBy = pdGroupBy.GetValue(currObject).ToString();
                            myFirstNode = new FTSTreeNode(currGroup.Name, pdDisplay.GetValue(currObject).ToString(),
                                                          currObject, pdValue.GetValue(innerList[currentListIndex]),
                                                          pdExtendValue.GetValue(innerList[currentListIndex]),
                                                          currGroup.ImageIndex, currGroup.SelectedImageIndex,
                                                          currentListIndex);
                            currNodes.Add((TreeNode) myFirstNode);
                        } else {
                            this.AddNodes(currGroupIndex, ref currentListIndex, myFirstNode.Nodes, currGroup.GroupBy);
                        }
                    }
                }
            } else {
                FTSTreeNode myNewLeafNode;
                object currObject = this.m_currencyManager.List[currentListIndex];
                if ((this.DisplayMember != null) && (this.ValueMember != null) && (this.ExtendValueMember != null) &&
                    (this.DisplayMember.Length != 0) && (this.ValueMember.Length != 0) &&
                    (this.ExtendValueMember.Length != 0)) {
                    PropertyDescriptor pdDisplayloc = this.m_currencyManager.GetItemProperties()[this.DisplayMember];
                    PropertyDescriptor pdValueloc = this.m_currencyManager.GetItemProperties()[this.ValueMember];
                    PropertyDescriptor pdExtendValueloc =
                        this.m_currencyManager.GetItemProperties()[this.ExtendValueMember];
                    myNewLeafNode = new FTSTreeNode(this.Tag == null ? string.Empty : this.Tag.ToString(),
                                                    pdDisplayloc.GetValue(currObject).ToString(), currObject,
                                                    pdValueloc.GetValue(currObject),
                                                    pdExtendValueloc.GetValue(currObject), currentListIndex);
                } else {
                    myNewLeafNode = new FTSTreeNode(string.Empty, currentListIndex.ToString(), currObject, currObject,
                                                    currObject, this.ImageIndex, this.SelectedImageIndex,
                                                    currentListIndex);
                }
                //*** Check node leaf is null or blank
                PropertyDescriptor pdCheckDisplayloc = this.m_currencyManager.GetItemProperties()[this.DisplayMember];
                if ((pdCheckDisplayloc.GetValue(currObject).ToString().Trim().Length != 0) ||
                    (pdCheckDisplayloc.GetValue(currObject) == null)) {
                    currNodes.Add((TreeNode) myNewLeafNode);
                }
                currentListIndex += 1;
            }
        }

        public void RemoveGroup(FTSGroupTree group) {
            if (this.treeGroups.Contains(group)) {
                this.treeGroups.Remove(group);
                if (this.AutoBuildTree) {
                    this.BuildTree();
                }
            }
        }

        public void RemoveGroup(string groupName) {
            foreach (FTSGroupTree group in this.treeGroups) {
                if (group.Name == groupName) {
                    RemoveGroup(group);
                    return;
                }
            }
        }

        public void RemoveAllGroups() {
            this.treeGroups.Clear();
            if (this.AutoBuildTree) {
                this.BuildTree();
            }
        }

        public void AddGroup(FTSGroupTree group) {
            try {
                this.treeGroups.Add(group);
                if (this.AutoBuildTree) {
                    this.BuildTree();
                }
            } catch (NotSupportedException e) {
                XtraMessageBox.Show(e.Message);
            } catch (Exception) {
                throw;
            }
        }

        public void AddGroup(String name, String groupBy, String displayMember, String valueMember,
                             String extendValueMember, int imageIndex, int selectedImageIndex) {
            FTSGroupTree myNewGroup = new FTSGroupTree(name, groupBy, displayMember, valueMember, extendValueMember,
                                                       imageIndex, selectedImageIndex);
            this.AddGroup(myNewGroup);
        }

        public FTSGroupTree[] GetGroups() {
            return ((FTSGroupTree[]) this.treeGroups.ToArray(Type.GetType("FTSGroupTree")));
        }

        public void SetLeafData(String name, String displayMember, String valueMember, String extendValueMember,
                                int imageIndex, int selectedImageIndex) {
            this.Tag = name;
            this.DisplayMember = displayMember;
            this.ValueMember = valueMember;
            this.ExtendValueMember = extendValueMember;
            this.ImageIndex = imageIndex;
            this.SelectedImageIndex = selectedImageIndex;
        }

        public bool IsLeafNode(TreeNode node) {
            return (node.Nodes.Count == 0);
        }

        public TreeNode FindNodeByValue(object value) {
            return this.FindNodeByValue(value, this.Nodes);
        }

        public TreeNode FindNodeByValue(object Value, TreeNodeCollection nodesToSearch) {
            int i = 0;
            TreeNode currNode;
            FTSTreeNode leafNode;
            while (i < nodesToSearch.Count) {
                currNode = nodesToSearch[i];
                i ++;
                if (currNode.LastNode == null) {
                    leafNode = (FTSTreeNode) currNode;
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
            FTSTreeNode leafNode;
            while (i < nodesToSearch.Count) {
                currNode = nodesToSearch[i];
                i++;
                if (currNode.Nodes.Count == 0) {
                    leafNode = (FTSTreeNode) currNode;
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
            FTSTreeNode leafNode = (FTSTreeNode) e.Node;
            if (leafNode != null) {
                if (this.m_currencyManager.Position != leafNode.Position) {
                    this.m_currencyManager.Position = leafNode.Position;
                }
            }
            base.OnAfterSelect(e);
        }

        protected override void OnAfterCheck(TreeViewEventArgs e) {
            this.needUpdate = true;
            TreeNode node1 = e.Node;
            bool flag1 = node1.Checked;
            if (!this.m_UseNodeImages) {
                if (node1.IsExpanded) {
                    if (flag1) {
                        node1.ImageIndex = this.m_FolderOpenImg;
                    } else {
                        node1.ImageIndex = this.m_StateImage;
                    }
                } else if (flag1) {
                    node1.ImageIndex = base.ImageIndex;
                } else {
                    node1.ImageIndex = this.m_StateImage;
                }
            }
            base.OnAfterCheck(e);
            if (!this.m_lock) {
                this.m_lock = true;
                if (node1.Nodes.Count > 0) {
                    this.Check_Childs(node1, flag1);
                }
                if (node1.Parent != null) {
                    this.Check_Parents(node1, flag1);
                }
                this.m_lock = false;
            }
        }

        protected override void OnAfterCollapse(TreeViewEventArgs e) {
            base.OnAfterCollapse(e);
            TreeNode node1 = e.Node;
            if (node1.Checked) {
                node1.ImageIndex = base.ImageIndex;
            } else {
                node1.ImageIndex = this.m_StateImage;
            }
        }

        protected override void OnAfterExpand(TreeViewEventArgs e) {
            base.OnAfterExpand(e);
            TreeNode node1 = e.Node;
            if (node1.Checked) {
                node1.ImageIndex = this.m_FolderOpenImg;
            } else {
                node1.ImageIndex = this.m_StateImage;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                TreeNode node1 = base.GetNodeAt(e.X, e.Y);
                if (node1 != null) {
                    base.SelectedNode = node1;
                }
            }
            base.OnMouseDown(e);
        }

        [Obsolete("dummy I think ???")]
        public void Refresh_StateImages() {
            for (TreeNode node1 = this.Loop_Tree(true); node1 != null; node1 = this.Loop_Tree()) {
                if (!node1.Checked) {
                    node1.ImageIndex = this.m_StateImage;
                } else {
                    node1.ImageIndex = base.ImageIndex;
                }
            }
        }

        [Category("Appearance"), Description("Sets Image for open folder")]
        public int FolderOpenImage {
            get { return this.m_FolderOpenImg; }
            set { this.m_FolderOpenImg = value; }
        }

        [Category("Appearance"), Description("Sets state image for checked state")]
        public int StateImage {
            get { return this.m_StateImage; }
            set { this.m_StateImage = value; }
        }

        public bool UseNodeImages {
            get { return this.m_UseNodeImages; }
            set { this.m_UseNodeImages = value; }
        }

        [Category("Data")]
        public string ValueMember {
            get { return this.m_ValueMember; }
            set { this.m_ValueMember = value; }
        }

        [Category("Data")]
        public string ExtendValueMember {
            get { return this.m_ExtendValueMember; }
            set { this.m_ExtendValueMember = value; }
        }

        [Category("Data")]
        public string DisplayMember {
            get { return this.m_DisplayMember; }
            set { this.m_DisplayMember = value; }
        }

        [Category("Data")]
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
                        if (this.AutoBuildTree) {
                            this.BuildTree();
                        }
                    }
                }
            }
        }

        public bool AutoBuildTree {
            get { return this.m_autoBuild; }
            set { this.m_autoBuild = value; }
        }

        public bool NeedUpdate {
            get { return this.needUpdate; }
            set { this.needUpdate = value; }
        }
    }
}