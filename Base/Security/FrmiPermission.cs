using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseBusiness.Classes;
using FTS.BaseBusiness.Security;
using FTS.BaseUI.Controls;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Layout;
using DevExpress.XtraTab;
using FTS.BaseUI.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FTS.BaseUI.Security
{
    public partial class FrmiPermission : FrmDataEditList
    {
        public FrmiPermission()
        {
            this.InitializeComponent();
        }

        public FrmiPermission(FTSMain ftsmain)
            : base(ftsmain)
        {
            this.FTSMain.SecurityManager.CheckSecurity(FTSFunctionCollection.SEC_PERMISSION, DataAction.ExecuteAction);
            this.RelTreeListIdField = "USER_GROUP_NAME";
            this.RelGridIdField = "USER_GROUP_NAME";
            //this.ParentRelGridIdField = "USER_GROUP_NAME";
            this.InitializeComponent();
            this.ToolBar.NewVisible = BarItemVisibility.Never;
            this.ToolBar.DeleteVisible = BarItemVisibility.Never;
            this.ToolBar.CopyVisible = BarItemVisibility.Never;
            this.ShowTextFooter = false;
            this.ConfigGrid();
            this.ShowTreeList = true;
            this.ClearFilter = true;
            this.BindTreeList();
            this.ConfigTreeList();
            this.LoadLayout();
            this.SetControls();
            this.cboModule.ComboChange += new System.EventHandler(this.cboModule_ComboChange);
            //this.grid.ViewGrid.ShowingEditor += new System.ComponentModel.CancelEventHandler(ViewGrid_ShowingEditor);
            string temptree;
            this.isload = false;
            for (int i = 0; i < this.treeList.Nodes.Count; i++)
            {
                temptree = (string)this.treeList.Nodes[i]["USER_GROUP_ID"];
                this.treeList.Nodes[i]["USER_GROUP_ID"] = this.treeList.Nodes[i]["USER_GROUP_NAME"];
                this.treeList.Nodes[i]["USER_GROUP_NAME"] = temptree;
                this.isload = true;
            }
            this.isload = false;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeUser.ParentFieldName = "";
            this.cboModule.ComboBox.ItemIndex = 0;
            cboModule_ComboChange(cboModule, null);
            this.grid.ViewGrid.OptionsView.ShowAutoFilterRow = true;
        }

        //void ViewGrid_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    try
        //    {
        //        DataRow currentrow = this.grid.ViewGrid.GetDataRow(this.grid.ViewGrid.FocusedRowHandle);
        //        if ((currentrow != null) && (currentrow.RowState != DataRowState.Deleted))
        //        {
        //            string columnName = this.grid.ViewGrid.FocusedColumn.FieldName.ToUpper();
        //            switch (columnName)
        //            {
        //                case "EXCHANGE_RATE":
        //                case "AMOUNT":
        //                    e.Cancel = true;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.mFTSMain,ex);
        //    }
        //}
        public override void LayoutItems()
        {
            FlowLayout layoutMain = new FlowLayout();
            layoutMain.ContainerControl = SubModule;
            layoutMain.TopMargin = 3;
            layoutMain.BottomMargin = 3;
            layoutMain.HorzNearMargin = 2;
            layoutMain.VGap = 5;
            layoutMain.HGap = 5;
            layoutMain.AutoLayout = true;
            layoutMain.Alignment = FlowAlignment.ChildConstraints;
        }
        private bool isload;

        private void cboModule_ComboChange(object sender, System.EventArgs e)
        {
            this.isload = true;
            string temptree;
            foreach (XtraTabPage tab in SubModule.TabPages)
            {
                tab.PageVisible = false;
            }
            foreach (DataRow item in this.DataObject.DataSet.Tables["SYS_MENU"].Rows)
            {
                if (cboModule.ComboBox.EditValue.ToString() == item["PROJECT_ID"].ToString() ||
                    item["PROJECT_ID"].ToString() == "SYS")
                {
                    foreach (XtraTabPage tab in SubModule.TabPages)
                    {
                        if ((tab.Tag as ItemCombobox).Id == item["MODULE_ID"].ToString())
                        {
                            tab.PageVisible = true;
                            break;
                        }
                    }
                }
            }
            this.SubModule.SelectedTabPageIndex = 0;
            //for (int i = 0; i < this.treeList.Nodes.Count; i++)
            //{
            //    temptree = (string)this.treeList.Nodes[i]["USER_GROUP_ID"];
            //    this.treeList.Nodes[i]["USER_GROUP_ID"] = this.treeList.Nodes[i]["USER_GROUP_NAME"];
            //    this.treeList.Nodes[i]["USER_GROUP_NAME"] = temptree;
            //}
            this.isload = false;
            if (SubModule.SelectedTabPage != null)
                ((iPermission)this.DataObject).FillData(this.treeList.FocusedNode["USER_GROUP_NAME"].ToString(),
                                                    (SubModule.SelectedTabPage.Tag as ItemCombobox).Id,
                                                    this.cboModule.ComboBox.EditValue.ToString());
        }

        public override void FocusedNodeChanged(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            this.FTSMain.TableManager.LoadTable(this.DataObject.DataSet, "SEC_USER", "*",
                                               "',' + USER_GROUP_ID + ',' like '%," + this.treeList.Nodes[node.Id]["USER_GROUP_NAME"] +
                                               ",%'");
            if (!this.isload)
            {
                if (SubModule.SelectedTabPage != null)
                    ((iPermission)this.DataObject).FillData(node["USER_GROUP_NAME"].ToString(),
                                                        (SubModule.SelectedTabPage.Tag as ItemCombobox).Id,
                                                        this.cboModule.ComboBox.EditValue.ToString());
            }
        }
        public override void SetControls()
        {
            LayoutItems();
            this.cboModule.Set(ProjectList.GetProjectList(this.FTSMain));
            this.cboModule.ComboBox.ItemIndex = 1;
            XtraTabPage button = null;
            int i = 0;
            SubModule.TabPages.Clear();
            string[] module_list = this.DataObject.DataSet.Tables["SEC_USER_GROUP"].Rows.Find(this.FTSMain.UserInfo.UserGroupID)["MODULE_LIST"].ToString().Split(',');
            foreach (ItemCombobox item in ModuleList.GetModuleList(FTSMain))
            {
                i++;
                if (this.FTSMain.UserInfo.UserGroupID == "ADMIN")
                {
                    button = new XtraTabPage();
                    button.Text = item.Name;
                    button.Tag = item;
                    button.Height = SubModule.Height - 5;
                    if (i % 2 == 0) button.BackColor = System.Drawing.Color.Brown;
                    else button.BackColor = System.Drawing.Color.DarkBlue;
                    button.ForeColor = System.Drawing.Color.White;
                    button.PageVisible = false;
                    SubModule.TabPages.Add(button);
                }
                else
                    for (int ii = 0; ii < module_list.Length; ii++)
                    {
                        if (module_list[ii] == item.Id)
                        {
                            button = new XtraTabPage();
                            button.Text = item.Name;
                            button.Tag = item;
                            button.Height = SubModule.Height - 5;
                            if (i % 2 == 0) button.BackColor = System.Drawing.Color.Brown;
                            else button.BackColor = System.Drawing.Color.DarkBlue;
                            button.ForeColor = System.Drawing.Color.White;
                            button.PageVisible = false;
                            SubModule.TabPages.Add(button);
                            break;
                        }
                    }

            }
            this.Grid.ViewGrid.Columns["FUNCTION_GROUP_ID"].Group();
            this.Grid.ViewGrid.OptionsBehavior.AutoExpandAllGroups = true;
        }

        private void SubModule_Selected(object sender, TabPageEventArgs e)
        {
            ((iPermission)this.DataObject).FillData(this.treeList.FocusedNode["USER_GROUP_NAME"].ToString(),
                                                    (e.Page.Tag as ItemCombobox).Id,
                                                    this.cboModule.ComboBox.EditValue.ToString());
        }

        public override void LoadData()
        {
            this.DataObject = new iPermission(this.FTSMain);
        }

        public override void BindGrid()
        {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("FUNCTION_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("FUNCTION_NAME"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("USER_GROUP_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("FUNCTION_GROUP_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MODULE_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PROJECT_ID"), false);
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_VIEW"));
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_ADDNEW"));
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_EDIT"));
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_DELETE"));
            this.grid.SetCheckColumn(this.DataObject.GetFieldInfo("IS_EXECUTE"));
            this.grid.BindData();
        }

        public override void BindTreeList()
        {
            this.treeList.CreateTreeList(this.DataObject.DataSet.Tables["SEC_USER_GROUP"], "USER_GROUP_NAME",
                                         "USER_GROUP_ID");
            this.treeList.SetTextColumn(new FieldInfo("USER_GROUP_ID", DbType.String, true, false), false);
            this.treeList.SetTextColumn(new FieldInfo("USER_GROUP_NAME", DbType.String, false, false), false);
            this.treeList.SetTextColumn(new FieldInfo("USER_GROUP_ID", DbType.String, true, false), false);

            this.treeList.BindData();
            this.treeUser.CreateTreeList(this.DataObject.DataSet.Tables["SEC_USER"], "USER_ID", "USER_NAME");
            this.treeUser.SetTextColumn(new FieldInfo("USER_ID", DbType.String, true, false), false);
            this.treeUser.SetTextColumn(new FieldInfo("USER_NAME", DbType.String, false, false), false);
            this.treeUser.SetTextColumn(new FieldInfo("USER_ID", DbType.String, true, false), false);
            this.treeUser.BindData();
            this.treeUser.Columns["USER_ID"].VisibleIndex = 0;
            this.treeUser.Columns["USER_ID"].Caption = "Người dùng";
            this.treeUser.Columns["USER_ID"].Visible = true;
        }

        private void btnAddUser_Click(object sender, System.EventArgs e)
        {
            try
            {
                FrmAdminUser frm = new FrmAdminUser(this.FTSMain, string.Empty, string.Empty, string.Empty, string.Empty,
                                                    string.Empty, string.Empty, true, false,
                                                    this.DataObject.DataSet.Tables["SEC_USER"]);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        Sec_User secUser = new Sec_User(this.FTSMain);

                        DataRow newrow = secUser.AddNew();
                        newrow["user_id"] = frm.UserId;
                        newrow["user_name"] = frm.UserName;
                        newrow["user_group_id"] = frm.UserGroup;
                        newrow["organization_id"] = frm.OrganizationID;
                        newrow["employee_id"] = frm.EmployeeID;
                        newrow["user_password"] = Functions.Encrypt(frm.PassWord);
                        newrow["active"] = frm.Active;
                        secUser.UpdateData();
                    }
                    DataObject.DataSet.Tables["SEC_USER"].Clear();
                    this.FTSMain.TableManager.LoadTable(this.DataObject.DataSet, "SEC_USER", "*", "',' + USER_GROUP_ID + ',' like '%," + this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"] + ",%'");
                    
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void btnEditUser_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.treeUser.FocusedNode == null)
                {
                    return;
                }
                if (this.treeUser.Nodes[this.treeUser.FocusedNode.Id]["USER_ID"] == null)
                {
                    return;
                }
                string userid = this.treeUser.Nodes[this.treeUser.FocusedNode.Id]["USER_ID"].ToString();
                this.DataObject.DataSet.Tables["sec_user"].PrimaryKey = new DataColumn[] { this.DataObject.DataSet.Tables["sec_user"].Columns["USER_ID"] };
                DataRow foundrow = this.DataObject.DataSet.Tables["sec_user"].Rows.Find(userid);
                if (foundrow != null)
                {
                    FrmAdminUser frm = new FrmAdminUser(this.FTSMain, foundrow["user_id"].ToString(),
                                                        foundrow["user_name"].ToString(),
                                                        foundrow["user_group_id"].ToString(),
                                                        foundrow["organization_id"].ToString(),
                                                        foundrow["employee_id"].ToString(),
                                                        Functions.Decrypt(foundrow["user_password"].ToString()),
                                                        Convert.ToBoolean(foundrow["active"]), true,
                                                        this.DataObject.DataSet.Tables["sec_user"]);
                    frm.ShowDialog();
                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {

                        Sec_User secUser = new Sec_User(this.FTSMain);
                        secUser.DataTable.PrimaryKey = new DataColumn[] { secUser.DataTable.Columns["USER_ID"] };
                        DataRow newrow = secUser.DataTable.Rows.Find(frm.UserId);
                        if (newrow != null)
                        {
                            newrow["user_id"] = frm.UserId;
                            newrow["user_name"] = frm.UserName;
                            newrow["user_group_id"] = frm.UserGroup;
                            newrow["organization_id"] = frm.OrganizationID;
                            newrow["employee_id"] = frm.EmployeeID;
                            newrow["user_password"] = Functions.Encrypt(frm.PassWord);
                            newrow["active"] = frm.Active;
                            secUser.UpdateData();
                        }
                        DataObject.DataSet.Tables["SEC_USER"].Clear();
                        this.FTSMain.TableManager.LoadTable(this.DataObject.DataSet, "SEC_USER", "*",
                                                            "',' + USER_GROUP_ID + ',' like '%," + this.treeList.Nodes[this.treeList.FocusedNode.Id][
                                                                "USER_GROUP_NAME"] + ",%'");
                        
                    }
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeUser.FocusedNode == null)
                {
                    return;
                }
                string userid = this.treeUser.Nodes[this.treeUser.FocusedNode.Id]["USER_ID"].ToString();
                Sec_User secUser = new Sec_User(this.FTSMain);
                secUser.DataTable.PrimaryKey = new DataColumn[] { secUser.DataTable.Columns["USER_ID"] };
                DataRow newrow = secUser.DataTable.Rows.Find(userid);
                if (newrow != null)
                {
                    newrow.Delete();
                    secUser.UpdateData();
                }
                DataObject.DataSet.Tables["SEC_USER"].Clear();
                this.FTSMain.TableManager.LoadTable(this.DataObject.DataSet, "SEC_USER", "*",
                                                    "',' + USER_GROUP_ID + ',' like '%," + this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"] + ",%'");
                
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void treeUser_DoubleClick(object sender, EventArgs e)
        {
            this.btnEditUser_Click(this.btnEditUser, null);
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSec_User_Group_EditDetail f = new FrmSec_User_Group_EditDetail(this.FTSMain,null,true,true,null,
                                                                  "",Find_Module_List()
                                                                  ,this.DataObject.DataSet.Tables["SEC_USER_GROUP"].Rows.Find(this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"].ToString())["MODULE_LIST"].ToString());
                f.ShowDialog();
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    ((iPermission)this.DataObject).CopyPermission(
                        f.DataObject.DataTable.Rows[0]["USER_GROUP_ID"].ToString());
                    this.FTSMain.TableManager.LoadTable(this.DataObject.DataSet, "SEC_USER_GROUP", "*", "1=1");
                }
                string temptree;
                for (int i = 0; i < this.treeList.Nodes.Count; i++)
                {
                    temptree = (string)this.treeList.Nodes[i]["USER_GROUP_ID"];
                    this.treeList.Nodes[i]["USER_GROUP_ID"] = this.treeList.Nodes[i]["USER_GROUP_NAME"];
                    this.treeList.Nodes[i]["USER_GROUP_NAME"] = temptree;
                }
                this.isload = false;
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
            // thêm nhóm người dùng và làm mới lại
        }

        private void btnCopyGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList.FocusedNode == null)
                {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowInfoMessage("Chọn nhóm người dùng cần sao chép");
                    return;
                }
                DataRow foundrow = this.DataObject.DataSet.Tables["SEC_USER_GROUP"].Rows.Find(this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"].ToString());
                if (foundrow != null)
                {
                    FrmSec_User_Group_EditDetail f = new FrmSec_User_Group_EditDetail(this.FTSMain, null, true, true,null, "",
                                                    Find_Module_List(),foundrow["MODULE_LIST"].ToString());
                    f.ShowDialog();
                    if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        ((iPermission)this.DataObject).CopyPermission(
                            f.DataObject.DataTable.Rows[0]["USER_GROUP_ID"].ToString(),
                            this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"].ToString());
                        this.FTSMain.TableManager.LoadTable(this.DataObject.DataSet, "SEC_USER_GROUP", "*",
                                                           "1=1");
                        string temptree;
                        for (int i = 0; i < this.treeList.Nodes.Count; i++)
                        {
                            temptree = (string)this.treeList.Nodes[i]["USER_GROUP_ID"];
                            this.treeList.Nodes[i]["USER_GROUP_ID"] = this.treeList.Nodes[i]["USER_GROUP_NAME"];
                            this.treeList.Nodes[i]["USER_GROUP_NAME"] = temptree;
                        }
                        this.isload = false;
                    }
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList.FocusedNode == null)
                {
                    return;
                }
                if (this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"].ToString() == "ADMIN")
                {
                    MessageBox.Show(
                        "Không được phép xóa nhóm " +
                        this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"].ToString() + " ?", "Thông báo");
                    return;
                }
                if (
                    MessageBox.Show(
                        "Bạn chắc chắn muốn xóa nhóm: " +
                        this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"].ToString() + " ?", "Thông báo",
                        MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    ((iPermission)this.DataObject).DeleteData(
                        this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"].ToString());
                    Sec_User_Group group = new Sec_User_Group(this.FTSMain);
                    group.DeleteInData(this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"]);
                    this.FTSMain.TableManager.LoadTable(this.DataObject.DataSet, "SEC_USER_GROUP", "*", "1=1");
                    string temptree;
                    for (int i = 0; i < this.treeList.Nodes.Count; i++)
                    {
                        temptree = (string)this.treeList.Nodes[i]["USER_GROUP_ID"];
                        this.treeList.Nodes[i]["USER_GROUP_ID"] = this.treeList.Nodes[i]["USER_GROUP_NAME"];
                        this.treeList.Nodes[i]["USER_GROUP_NAME"] = temptree;
                    }
                    this.isload = false;
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        protected override CustomizationForm CreateCustomizationForm(FTSMain ftsmain)
        {
            List<FTSDataGrid> lstgrid = new List<FTSDataGrid>();
            lstgrid.Add(this.grid);
            List<FTSTreeList> lsttree = new List<FTSTreeList>();
            lsttree.Add(this.treeList);
            lsttree.Add(this.treeUser);
            return new CustomizationForm(this, lstgrid, lsttree, ftsmain);
        }
        private List<ItemCombobox> Find_Module_List()
        {
            #region Lọc ModuleList theo ListProject
            List<ItemCombobox> list_module_curr = new List<ItemCombobox>();//= ModuleList.GetModuleList(this.FTSMain);
            string[] arrProjectid = this.FTSMain.ProjectID.ToArray();
            string listProject = string.Empty;
            listProject = ",";
            for (int i = 0; i < arrProjectid.Length; i++)
            {
                listProject += arrProjectid[i] + ",";
            }
            foreach (ItemCombobox item in ModuleList.GetModuleList(this.FTSMain))
            {
                string[] pro = item.Id.Split('_');
                if (Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(pro[0],listProject))
                {
                    list_module_curr.Add(new ItemCombobox(item.Id,
                                      this.FTSMain.MsgManager.GetMessage("MODULE_LIST_" + item.Id)));
                }
            }
            list_module_curr.Add(new ItemCombobox(ModuleList.SYS,
                                      this.FTSMain.MsgManager.GetMessage("MODULE_LIST_" + ModuleList.SYS)));
            #endregion
            return list_module_curr;
        }
        private void btnMapping_Menu_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grid.ViewGrid.GetFocusedDataRow() == null)
                {
                    (new FrmSys_Menu_Mapping_EditList(this.FTSMain)).Show();
                }
                else
                {
                    string function = "FUNCTION_ID ='" + this.grid.ViewGrid.GetFocusedDataRow()["FUNCTION_ID"] + "'";
                    string project = "MODULE_ID = '" + (this.SubModule.SelectedTabPage.Tag as ItemCombobox).Id + "'";
                    string module = "PROJECT_ID = '" + this.cboModule.ComboBox.EditValue + "'"; ;
                    FrmSys_Menu_Mapping_EditList fr = new FrmSys_Menu_Mapping_EditList(this.FTSMain, function + " AND " + project + " AND " + module);
                    fr.Grid.BindData();
                    fr.Grid.RefreshDataSource();
                    fr.Show();
                }
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(ex.Message);
            }
        }

        private void btnEditUserGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList.FocusedNode == null)
                {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowInfoMessage("Chọn nhóm người dùng cần sao chép");
                    return;
                }
                
                FrmSec_User_Group_EditDetail f = new FrmSec_User_Group_EditDetail(this.FTSMain,null,false,true,
                    this.treeList.Nodes[this.treeList.FocusedNode.Id]["USER_GROUP_NAME"],"",Find_Module_List(),"");
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }

        private void cmdReportPermision_Click(object sender, EventArgs e)
        {

        }
    }
}