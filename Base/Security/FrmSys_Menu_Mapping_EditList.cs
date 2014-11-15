using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Security;
using FTS.BaseUI.Forms;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Classes;
using FTS.BaseUI.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace FTS.BaseUI.Security
{
    public partial class FrmSys_Menu_Mapping_EditList : FrmDataEditList
    {
        public FrmSys_Menu_Mapping_EditList()
        {
            InitializeComponent();
        }
        public FrmSys_Menu_Mapping_EditList(FTSMain ftsmain)
            : base(ftsmain)
        {
            InitializeComponent();
            this.ShowTextFooter = false;
            this.ConfigGrid();
            this.LoadLayout();
        }
        public FrmSys_Menu_Mapping_EditList(FTSMain ftsmain, string condition)
            : base(ftsmain)
        {

            InitializeComponent();
            this.ShowTextFooter = false;
            this.ConfigGrid();
            this.LoadLayout();
            (this.DataObject as Sys_Menu_Mapping).Condition = condition;
        }
        public string Condition;
        public override void LoadData()
        {
            this.DataObject = null;
            if (string.IsNullOrEmpty(Condition)) Condition = "1=1";
            this.DataObject = new Sys_Menu_Mapping(this.FTSMain);
        }
        public override void BindGrid()
        {
            this.grid.CreateGrid(this.DataObject.DataSet, this.DataObject.DataTable, this.DataObject.TableName);

            this.grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("FUNCTION_ID"), FTSFunctionCollection.GetFunctionList(FTSMain));
            this.grid.SetComboMultiColumn(this.DataObject.GetFieldInfo("MENU_ID"), this.DataObject.DataSet.Tables["SYS_MENU"], "MENU_NAME", "MENU_ID", ComboComType.NameID, false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("PROJECT_ID"), false);
            this.grid.SetTextColumn(this.DataObject.GetFieldInfo("MODULE_ID"), false);

            this.grid.BindData();
        }
        public override void GridValidatingCell(DevExpress.XtraGrid.Views.Grid.GridView gridview, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                BaseEdit textbox = gridview.ActiveEditor;
                bool tag = false;
                try
                {
                    tag = (bool)textbox.Tag;
                }
                catch (Exception) { }

                if (!(gridview.ActiveEditor is LookUpEdit || gridview.ActiveEditor is DateEdit) &&
                    gridview.ActiveEditor is TextEdit && textbox != null && textbox.Tag != null && tag &&
                    gridview.FocusedColumn != null &&
                    gridview.FocusedRowHandle >= 0)
                {
                    GridColumn ncol = gridview.FocusedColumn;
                    int nrow = gridview.FocusedRowHandle;
                    FTSDataGrid gr = ((FTSDataGrid)gridview.GridControl);
                    gr.SetValue(nrow, ncol.FieldName, e.Value);
                    BindingManagerBase bm =
                        this.BindingContext[this.DataObject.DataSet, this.DataObject.TableName];
                    bm.EndCurrentEdit();
                    this.DataObject.EndEdit();
                    switch (ncol.FieldName.ToUpper())
                    {
                        case "MENU_ID":

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (FTSException ex)
            {
                FTS.BaseUI.Utilities.ExceptionManager.ProcessException(this.FTSMain,ex);
            }
        }
    }
}