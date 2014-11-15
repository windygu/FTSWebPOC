using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FTS.BaseUI.Layout;
using FTS.BaseBusiness.Systems;
using Softgroup.NetButton;
using FTS.BaseBusiness.Utilities;

namespace FTS.BaseUI.Controls
{
    public partial class ButtonItemView : XtraUserControl
    {
        public event ItemChoiceEventHandler ItemChoice;
        public event GroupChoiceEventHandler GroupChoice;

        private int mMaxGroupPages = 0;
        private int mMaxItemPages = 0;
        private int mCurrentGroupPages = 0;
        private int mCurrentItemPages = 0;
        private int mItemsOnRow = 5;
        private int mItemsOnColum = 5;
        private int mButtonWidth = 75;
        private int mButtonHeight = 50;
        private List<GroupInfo> mListGroup = new List<GroupInfo>();
        private List<ItemInfo> mListItem = new List<ItemInfo>();
        private NetButton mCurrentGroup = null;
        private bool mShowId = true;
        private FTSMain mFtsMain;
        private bool mMerger = false;
        private int mMenu_Font_Size = -1;

        public ButtonItemView()
        {
            InitializeComponent();
        }
        public void Set(int itemsOnrow, int itemsOncolumn, List<GroupInfo> listGroup, List<ItemInfo> listItem)
        {
            this.mMerger = true;
            this.mShowId = false;
            this.mItemsOnRow = itemsOnrow;
            this.mItemsOnColum = itemsOncolumn;
            this.mListGroup = listGroup;
            this.mListItem = listItem;
            this.SetLayout();
            this.CalcLayout();
            this.LoadGroups();
        }
        public void Set(int itemsOnrow, int itemsOncolumn, List<GroupInfo> listGroup, List<ItemInfo> listItem, bool showId)
        {
            this.mMerger = false;
            this.mShowId = showId;
            this.mItemsOnRow = itemsOnrow;
            this.mItemsOnColum = itemsOncolumn;
            this.mListGroup = listGroup;
            this.mListItem = listItem;
            this.SetLayout();         
            this.CalcLayout();
            this.LoadGroups();
        }
        public void Set(FTSMain ftsmain, int itemsOnrow, int itemsOncolumn, List<GroupInfo> listGroup, List<ItemInfo> listItem, bool showId)
        {
            this.mMerger = false;
            this.mFtsMain = ftsmain;
            this.mShowId = showId;
            this.mItemsOnRow = itemsOnrow;
            this.mItemsOnColum = itemsOncolumn;
            this.mListGroup = listGroup;
            this.mListItem = listItem;
            this.SetLayout();
            this.CalcLayout();
            this.LoadGroups();
        }
        private void SetLayout()
        {
            FlowLayout layoutGroup = new FlowLayout();
            layoutGroup.TopMargin = 4;
            layoutGroup.BottomMargin = 4;
            layoutGroup.HorzNearMargin = 4;
            layoutGroup.HGap = 4;
            layoutGroup.VGap = 4;
            layoutGroup.Alignment = FlowAlignment.Near;
            layoutGroup.ContainerControl = this.palGroup;
            layoutGroup.AutoHeight = true;
            layoutGroup.AutoLayout = true;

            FlowLayout layoutItem = new FlowLayout();
            layoutItem.TopMargin = 4;
            layoutItem.BottomMargin = 4;
            layoutItem.HorzNearMargin = 4;
            layoutItem.HGap = 4;
            layoutItem.VGap = 4;
            layoutItem.Alignment = FlowAlignment.Near;
            layoutItem.ContainerControl = this.palItem;
            layoutItem.AutoHeight = true;
            layoutItem.AutoLayout = true;            
        }
        private void CalcLayout()
        {
            int AreaWidth = this.Width - this.palBGroup.Width - this.palBItem.Width - 4 * (2 + this.mItemsOnRow + 1);
            int AreaHeight = this.Height - 4 * (this.mItemsOnColum + 1);
            this.mButtonWidth = AreaWidth / (this.mItemsOnRow+1);
            this.mButtonHeight = AreaHeight / this.mItemsOnColum;            
            this.palGroup.Dock = DockStyle.None;
            this.palBGroup.Dock = DockStyle.None;
            this.palItem.Dock = DockStyle.None;
            this.palBItem.Dock = DockStyle.None;
            this.palGroup.Location = new Point(0, 0);
            this.palGroup.Width = this.mButtonWidth + 8;
            this.palGroup.Height = this.Height;
            this.palBGroup.Location = new Point(this.palGroup.Width, 0);
            this.palBGroup.Height = this.Height;
            this.palItem.Location = new Point(this.palGroup.Width + this.palBGroup.Width, 0);
            this.palItem.Width = this.mButtonWidth * this.mItemsOnRow + 4 * (this.mItemsOnRow + 1);
            this.palItem.Height = this.Height;
            this.palBItem.Location = new Point(this.palGroup.Width + this.palBGroup.Width + this.palItem.Width, 0);
            this.palBItem.Height = this.Height;
            Control parent = this.Parent;
            parent.Padding = new Padding(0, 0, AreaWidth - this.mButtonWidth * (this.mItemsOnRow + 1), AreaHeight - this.mButtonHeight * this.mItemsOnColum);            
        }
        private void LoadGroups()
        {
            int countGroup = this.mListGroup.Count;
            if (countGroup > 0)
                countGroup--;
            this.mMaxGroupPages = countGroup / this.mItemsOnColum;
            this.mCurrentGroupPages = 0;
            this.btnGDown.Enabled = false;
            this.btnGUp.Enabled = false;
            if (this.mMaxGroupPages > 0)            
                this.btnGDown.Enabled = true;            
            ((System.ComponentModel.ISupportInitialize)(this.palGroup)).BeginInit();
            int index = 0;
            foreach (GroupInfo group in this.mListGroup)
            {
                NetButton btn = new NetButton();
                btn.Name = "Group" + index.ToString();
                btn.TextButton = group.GroupName;                
                btn.Tag = group; 
                if(this.mMenu_Font_Size==-1)                               
                    btn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                else
                    btn.Font = new System.Drawing.Font("Tahoma", this.mMenu_Font_Size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                if (group.Color.Trim() != string.Empty)
                    btn.ColorBottom = UIFunctions.String2Color(group.Color);                    
                else
                    btn.ColorBottom = Color.FromName("RoyalBlue");
                btn.Click += new EventHandler(Group_Click);
                this.palGroup.Controls.Add(btn);
                btn.Size = new Size(this.mButtonWidth, this.mButtonHeight);                
                index++;
            }
            ((System.ComponentModel.ISupportInitialize)(this.palGroup)).EndInit();
            if(this.palGroup.Controls["Group0"] != null)
                this.Group_Click(this.palGroup.Controls["Group0"], new EventArgs());
        }

        private void Group_Click(object sender, EventArgs e)
        {
            if (this.mCurrentGroup != null)            
                this.mCurrentGroup.Enabled = true;
            this.mCurrentGroup = (NetButton)sender;
            this.mCurrentGroup.Enabled = false;
            this.mCurrentItemPages = 0;
            this.palItem.Location = new Point(this.palItem.Location.X, 0);
            this.btnIDown.Enabled = false;
            this.btnIUp.Enabled = false;
            ((System.ComponentModel.ISupportInitialize)(this.palItem)).BeginInit();
            this.palItem.Controls.Clear();
            int index = 0;
            foreach (ItemInfo item in this.mListItem)
            {
                if (item.GroupId == ((GroupInfo)this.mCurrentGroup.Tag).GroupId)
                {
                    NetButton btn = new NetButton();
                    btn.Name = "Item" + index.ToString();
                    if(this.mShowId)
                        btn.TextButton = item.ItemId + ": " + item.ItemName;
                    else
                        btn.TextButton = item.ItemName;
                    btn.Tag = item;   
                    if(this.mMenu_Font_Size ==-1)                  
                        btn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    else
                        btn.Font = new System.Drawing.Font("Tahoma", this.mMenu_Font_Size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (item.Color.Trim() != string.Empty)                        
                        btn.ColorBottom = UIFunctions.String2Color(item.Color);                        
                    else
                        btn.ColorBottom = Color.FromName("RoyalBlue");
                    if (item.Active)
                    {                                              
                        if (this.mMerger)
                            btn.Image = global::FTS.BaseUI.Properties.Resources.users_family;
                        else
                            btn.Image = global::FTS.BaseUI.Properties.Resources.users3;                                                   
                    }
                    btn.Click += new EventHandler(Item_Click);
                    this.palItem.Controls.Add(btn);
                    btn.Size = new Size(this.mButtonWidth, this.mButtonHeight);
                    index++;
                }
            }
            ((System.ComponentModel.ISupportInitialize)(this.palItem)).EndInit();
            if (index > 0)
                index--;
            this.mMaxItemPages = index / (this.mItemsOnRow *this.mItemsOnColum);
            if (this.mMaxItemPages > 0)
                this.btnIDown.Enabled = true;
            if (GroupChoice != null)
                GroupChoice(sender, new GroupChoiceEventArgs(((GroupInfo)this.mCurrentGroup.Tag)));
        }
        private void Item_Click(object sender, EventArgs e)
        {            
            if (this.ItemChoice != null)
                ItemChoice(sender, new ItemChoiceEventArgs((ItemInfo)((NetButton)sender).Tag));
        }

        private void btnGUp_Click(object sender, EventArgs e)
        {
            this.mCurrentGroupPages--;
            this.btnGDown.Enabled = true;
            if (this.mCurrentGroupPages == 0)
                this.btnGUp.Enabled = false;
            this.palGroup.Location = new Point(this.palGroup.Location.X, this.palGroup.Location.Y + this.mItemsOnColum * (this.mButtonHeight + 4));
            this.Group_Click(this.palGroup.Controls["Group" + (this.mCurrentGroupPages)*this.mItemsOnColum], new EventArgs());
        }
        public void RefreshItem(List<GroupInfo> listGroup, List<ItemInfo> listItem)
        {
            this.mListGroup = listGroup;
            this.mListItem = listItem;
            string group_id = string.Empty;
            if (this.mCurrentGroup != null)
                group_id = ((GroupInfo)this.mCurrentGroup.Tag).GroupId;
            int countGroup = this.mListGroup.Count;
            if (countGroup > 0)
                countGroup--;
            this.mMaxGroupPages = countGroup / this.mItemsOnColum;
            this.mCurrentGroupPages = 0;
            this.btnGDown.Enabled = false;
            this.btnGUp.Enabled = false;
            if (this.mMaxGroupPages > 0)
                this.btnGDown.Enabled = true;
            ((System.ComponentModel.ISupportInitialize)(this.palGroup)).BeginInit();
            this.palGroup.Controls.Clear();
            int index = 0;
            foreach (GroupInfo group in this.mListGroup)
            {
                NetButton btn = new NetButton();
                btn.Name = "Group" + index.ToString();
                btn.TextButton = group.GroupName;
                btn.Tag = group;                                
                if(this.mMenu_Font_Size==-1)
                    btn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                else
                    btn.Font = new System.Drawing.Font("Tahoma", this.mMenu_Font_Size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                if (group.Color.Trim() != string.Empty)
                    btn.ColorBottom = UIFunctions.String2Color(group.Color);                    
                else
                    btn.ColorBottom = Color.FromName("RoyalBlue");
                btn.Click += new EventHandler(Group_Click);
                this.palGroup.Controls.Add(btn);
                btn.Size = new Size(this.mButtonWidth, this.mButtonHeight);
                index++;
                if (group.GroupId == group_id)
                    this.mCurrentGroup = btn;
            }
            ((System.ComponentModel.ISupportInitialize)(this.palGroup)).EndInit();

            this.Group_Click(this.mCurrentGroup, new EventArgs());            
        }
        private void btnGDown_Click(object sender, EventArgs e)
        {
            this.mCurrentGroupPages++;
            this.btnGUp.Enabled = true;
            if (this.mCurrentGroupPages == this.mMaxGroupPages)
                this.btnGDown.Enabled = false;
            this.palGroup.Location = new Point(this.palGroup.Location.X, this.palGroup.Location.Y - this.mItemsOnColum * (this.mButtonHeight + 4));
            this.Group_Click(this.palGroup.Controls["Group" + (this.mCurrentGroupPages) * this.mItemsOnColum], new EventArgs());
        }

        private void btnIUp_Click(object sender, EventArgs e)
        {
            this.mCurrentItemPages--;
            this.btnIDown.Enabled = true;
            if (this.mCurrentItemPages == 0)
                this.btnIUp.Enabled = false;
            this.palItem.Location = new Point(this.palItem.Location.X, this.palItem.Location.Y + this.mItemsOnColum * (this.mButtonHeight + 4));
        }

        private void btnIDown_Click(object sender, EventArgs e)
        {
            this.mCurrentItemPages++;
            this.btnIUp.Enabled = true;
            if (this.mCurrentItemPages == this.mMaxItemPages)
                this.btnIDown.Enabled = false;
            this.palItem.Location = new Point(this.palItem.Location.X, this.palItem.Location.Y - this.mItemsOnColum * (this.mButtonHeight + 4));
        }
        [DefaultValue(-1)]
        public int Menu_Font_Size
        {
            get { return this.mMenu_Font_Size; }
            set { this.mMenu_Font_Size = value; }
        }
    }
    public class GroupInfo
    {
        string mGroupId = string.Empty;
        string mGroupName = string.Empty;
        string mColor = string.Empty;

        public GroupInfo(string groupId, string groupName, string color)
        {
            this.mGroupId = groupId;
            this.mGroupName = groupName;
            this.mColor = color;
        }
        public string GroupId
        {
            get { return this.mGroupId; }
        }
        public string GroupName
        {
            get { return this.mGroupName; }
        }
        public string Color
        {
            get { return this.mColor; }
        }
        public override string ToString()
        {
            return this.mGroupName;
        }
    }
    public class ItemInfo
    {
        string mItemId = string.Empty;
        string mGroupId = string.Empty;
        string mItemName = string.Empty;
        string mColor = string.Empty;        
        bool mActive = false;
        bool mIs_Service = false;

        public ItemInfo(string itemId, string groupId, string itemName, string color, bool is_service)
        {
            this.mItemId = itemId;
            this.mGroupId = groupId;
            this.mItemName = itemName;
            this.mColor = color;
            this.mIs_Service = is_service;
        }
        public ItemInfo(string itemId, string groupId, string itemName, string color,bool is_service, bool active):this(itemId,groupId,itemName,color,is_service)
        {
            this.mActive = active;
        }
        public string ItemId
        {
            get { return this.mItemId; }
        }
        public string GroupId
        {
            get { return this.mGroupId; }
        }
        public string ItemName
        {
            get { return this.mItemName; }
        }
        public string Color
        {
            get { return this.mColor; }
        }
        internal bool Active
        {
            get { return this.mActive; }
            set { this.mActive = value; }
        }
        public bool IsService
        {
            get { return this.mIs_Service; }
        }
        public override string ToString()
        {
            return this.ItemId + ": " + this.mItemName;
        }
    }
    public class ItemChoiceEventArgs : EventArgs
    {
        ItemInfo mItemInfo;
        public ItemChoiceEventArgs(ItemInfo itemInfo)
        {
            this.mItemInfo = itemInfo;
        }
        public ItemInfo ItemInfo
        {
            get { return this.mItemInfo; }
        }
    }
    public class GroupChoiceEventArgs : EventArgs
    {
        GroupInfo mGroupInfo;
        public GroupChoiceEventArgs(GroupInfo groupInfo)
        {
            this.mGroupInfo = groupInfo;
        }
        public GroupInfo GroupInfo
        {
            get { return this.mGroupInfo; }
        }
    }
    public delegate void ItemChoiceEventHandler(object sender, ItemChoiceEventArgs e);
    public delegate void GroupChoiceEventHandler(object sender, GroupChoiceEventArgs e);
}
