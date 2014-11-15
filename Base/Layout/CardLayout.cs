#region

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using FTS.BaseBusiness.Utilities;
using Microsoft.Practices.EnterpriseLibrary.Global.Utilities;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for CardLayout.
    /// </summary>
    /// 
    [ToolboxItemFilter("System.Windows.Forms"), Designer(typeof (CardLayoutDesigner), typeof (IDesigner)),
     ProvideProperty("CardName", typeof (Control)), ProvideProperty("MaintainAspectRatio", typeof (Control)),
     ToolboxBitmap(typeof (CardLayout), "CardLayout.bmp")]
    public class CardLayout : LayoutManager, ISupportInitialize {
        // Fields
        private string cachedSelectedCardSetting;
        private CardLayoutMode cardLayoutMode;
        protected string CardNameBase;
        private Hashtable cardNameVsControls;
        private Hashtable controlsVsCardNames;
        private bool initializing;
        private Hashtable maintainAspectRatios;
        private Control selectedControl;

        public CardLayout() {
#if DEV
            if (!Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.InList(Microsoft.Practices.EnterpriseLibrary.Global.Utilities.Functions.GetMAC(), FTSBaseConstant.ListMac))
                throw (new Exception("Not yet implemented"));
#endif
            this.cardLayoutMode = CardLayoutMode.Default;
            this.CardNameBase = "Card";
            this.selectedControl = null;
            this.initializing = false;
            this.cachedSelectedCardSetting = string.Empty;
            this.cardNameVsControls = new Hashtable();
            this.controlsVsCardNames = new Hashtable();
            this.maintainAspectRatios = new Hashtable();
        }

        public CardLayout(IContainer container) : this() {
            if (container != null) {
                container.Add(this);
            }
        }

        public CardLayout(Control container) : this() {
            base.ContainerControl = container;
        }

        public override void AddLayoutComponent(Control childControl, object constraints) {
            if ((constraints == null) || (((string) constraints).Length == 0)) {
                throw new ArgumentException(
                    "Constraints cannot be NULL or an empty string when calling AddLayoutComponent", "constraints");
            }
            if (constraints is string) {
                if (base.ContainerControl != null) {
                    base.ContainerControl.SuspendLayout();
                }
                bool flag1 = this.selectedControl == childControl;
                string text1 = (string) constraints;
                if ((!this.initializing && (this.cardNameVsControls[text1] != null)) &&
                    (this.cardNameVsControls[text1] != childControl)) {
                    if (this.controlsVsCardNames[childControl] != null) {
                        text1 = (string) this.controlsVsCardNames[childControl];
                    } else {
                        text1 = this.GetNewCardName();
                    }
                }
                this.RemoveLayoutComponent(childControl);
                if (this.cardNameVsControls.Count > 1) {
                    childControl.Visible = false;
                }
                this.cardNameVsControls[text1] = childControl;
                this.controlsVsCardNames[childControl] = text1;
                base.AddLayoutComponent(childControl, constraints);
                if (flag1) {
                    this.selectedControl = childControl;
                }
                if (base.ContainerControl != null) {
                    base.ContainerControl.ResumeLayout(false);
                    base.ContainerControl.PerformLayout(childControl, "Bounds");
                }
            }
        }

        public void BeginInit() {
            this.initializing = true;
        }

        public void EndInit() {
            this.initializing = false;
            if (this.cachedSelectedCardSetting.Length > 0) {
                this.SelectedCard = this.cachedSelectedCardSetting;
            }
            this.cachedSelectedCardSetting = string.Empty;
            this.ValidateHiddenStates();
        }

        public void First() {
            if (this.IsInit()) {
                Monitor.Enter(this);
                IList list1 = this.GetControls();
                if (list1.Count == 0) {
                    this.SelectedCard = string.Empty;
                } else {
                    Control control1 = this.GetControls()[0] as Control;
                    if (this.selectedControl != control1) {
                        this.SelectedCard = (string) this.controlsVsCardNames[control1];
                    }
                }
                Monitor.Exit(this);
            }
        }

        [Localizable(true), MergableProperty(false), Category("Layout Manager")]
        public string GetCardName(Control control) {
            if (this.controlsVsCardNames[control] == null) {
                return string.Empty;
            }
            return (string) this.controlsVsCardNames[control];
        }

        public ArrayList GetCardNames() {
            ArrayList list1 = new ArrayList();
            IList list2 = this.GetControls();
            foreach (Control control1 in list2) {
                list1.Add((string) this.controlsVsCardNames[control1]);
            }
            return list1;
        }

        public Control GetComponentFromName(string cardName) {
            return (this.cardNameVsControls[cardName] as Control);
        }

        protected Control GetCurrentVisibleChild() {
            IList list1 = this.GetControls();
            int num1 = list1.Count;
            for (int num2 = 0; num2 < num1; num2++) {
                Control control1 = list1[num2] as Control;
                if (base.IsVisible(control1)) {
                    return control1;
                }
            }
            return null;
        }

        [MergableProperty(false), DefaultValue(false), Category("Layout Manager")]
        public virtual bool GetMaintainAspectRatio(Control control) {
            if (this.maintainAspectRatios[control] == null) {
                this.SetMaintainAspectRatio(control, false);
            }
            return (bool) this.maintainAspectRatios[control];
        }

        public virtual string GetNewCardName() {
            ArrayList list1 = this.GetCardNames();
            string text1 = string.Empty;
            int num1 = this.controlsVsCardNames.Count;
            while ((text1.Length == 0) || list1.Contains(text1)) {
                num1++;
                text1 = this.CardNameBase + num1.ToString();
            }
            return text1;
        }

        public void Last() {
            if (this.IsInit()) {
                Monitor.Enter(this);
                IList list1 = this.GetControls();
                if (list1.Count == 0) {
                    this.SelectedCard = string.Empty;
                } else {
                    Control control1 = list1[list1.Count - 1] as Control;
                    if (this.selectedControl != control1) {
                        this.SelectedCard = (string) this.controlsVsCardNames[control1];
                    }
                }
                Monitor.Exit(this);
            }
        }

        public override void LayoutContainer() {
            if (this.IsInit()) {
                Monitor.Enter(this);
                if (base.ContainerControl != null) {
                    base.ContainerControl.SuspendLayout();
                }
                IList list1 = this.GetControls();
                if ((this.SelectedCard.Length == 0) && (list1.Count > 0)) {
                    this.SelectedCard = (string) this.controlsVsCardNames[list1[0]];
                }
                int num1 = list1.Count;
                for (int num2 = 0; num2 < num1; num2++) {
                    Control control1 = list1[num2] as Control;
                    Rectangle rectangle1 = this.GetBounds();
                    Rectangle rectangle2 = new Rectangle(rectangle1.Top, rectangle1.Left, 0, 0);
                    Size size1 = new Size(rectangle1.Width, rectangle1.Height);
                    if (this.LayoutMode == CardLayoutMode.Default) {
                        Size size2 = this.GetPreferredSize(control1);
                        Size size3 = this.GetMinimumSize(control1);
                        float single1 = ((float) size2.Width)/((float) size2.Height);
                        if (size1.Width >= size2.Width) {
                            rectangle2.X += ((size1.Width - size2.Width)/2);
                            rectangle2.Width = size2.Width;
                        } else if ((size1.Width < size2.Width) && (size1.Width > size3.Width)) {
                            rectangle2.Width = size1.Width;
                        } else {
                            rectangle2.Width = size3.Width;
                        }
                        if (size1.Height >= size2.Height) {
                            rectangle2.Y += ((size1.Height - size2.Height)/2);
                            rectangle2.Height = size2.Height;
                        } else if ((size1.Height < size2.Height) && (size1.Height > size3.Height)) {
                            rectangle2.Height = size1.Height;
                        } else {
                            rectangle2.Height = size3.Height;
                        }
                        if (this.GetMaintainAspectRatio(control1)) {
                            float single2 = rectangle2.Width;
                            float single3 = rectangle2.Height;
                            float single4 = single2/single1;
                            float single5 = single3*single1;
                            if (single4 < single3) {
                                rectangle2.Height = (int) single4;
                                rectangle2.Y = (size1.Height - ((int) single4))/2;
                            } else if (single5 < single2) {
                                rectangle2.Width = (int) single5;
                                rectangle2.X = (size1.Width - ((int) single5))/2;
                            }
                        }
                    } else {
                        rectangle2.Width = size1.Width;
                        rectangle2.Height = size1.Height;
                    }
                    if (control1.Bounds != rectangle2) {
                        control1.Bounds = rectangle2;
                        control1.PerformLayout();
                    }
                }
                if (base.ContainerControl != null) {
                    base.ContainerControl.ResumeLayout(true);
                }
                Monitor.Exit(this);
            }
        }

        public override Size MinimumLayoutSize() {
            Monitor.Enter(this);
            IList list1 = this.GetControls();
            int num1 = list1.Count;
            int num2 = 0;
            int num3 = 0;
            for (int num4 = 0; num4 < num1; num4++) {
                Control control1 = list1[num4] as Control;
                Size size1 = this.GetMinimumSize(control1);
                if (size1.Width > num2) {
                    num2 = size1.Width;
                }
                if (size1.Height > num3) {
                    num3 = size1.Height;
                }
            }
            Monitor.Exit(this);
            return new Size(num2, num3);
        }

        public void Next() {
            if (this.IsInit()) {
                Monitor.Enter(this);
                int num1 = this.NextCardIndex;
                IList list1 = this.GetControls();
                if (num1 >= list1.Count) {
                    this.SelectedCard = string.Empty;
                } else {
                    Control control1 = list1[num1] as Control;
                    if (this.selectedControl != control1) {
                        this.SelectedCard = (string) this.controlsVsCardNames[control1];
                    }
                }
                Monitor.Exit(this);
            }
        }

        protected override void OnContainerControlChanged(EventArgs e) {
            base.OnContainerControlChanged(e);
            if ((base.ContainerControl != null) && !base.LoadingDocument) {
                foreach (Control control1 in base.ContainerControl.Controls) {
                    if (this.controlsVsCardNames[control1] == null) {
                        int num1 = this.controlsVsCardNames.Count + 1;
                        string text1 = this.CardNameBase + num1.ToString();
                        this.SetCardName(control1, text1);
                    }
                }
            }
        }

        protected override void OnControlAdded(object sender, ControlEventArgs e) {
            Control control1 = e.Control;
            if (this.controlsVsCardNames[control1] == null) {
                string text1 = this.GetNewCardName();
                this.SetCardName(control1, text1);
            }
            base.OnControlAdded(sender, e);
        }

        public override Size PreferredLayoutSize() {
            Monitor.Enter(this);
            IList list1 = this.GetControls();
            int num1 = list1.Count;
            int num2 = 0;
            int num3 = 0;
            for (int num4 = 0; num4 < num1; num4++) {
                Control control1 = list1[num4] as Control;
                Size size1 = this.GetPreferredSize(control1);
                if (size1.Width > num2) {
                    num2 = size1.Width;
                }
                if (size1.Height > num3) {
                    num3 = size1.Height;
                }
            }
            Monitor.Exit(this);
            return new Size(base.AdjustWidthForMargins(num2), base.AdjustHeightForMargins(num3));
        }

        public void Previous() {
            if (this.IsInit()) {
                Monitor.Enter(this);
                int num1 = this.PreviousCardIndex;
                IList list1 = this.GetControls();
                if (num1 >= list1.Count) {
                    this.SelectedCard = string.Empty;
                } else {
                    Control control1 = list1[num1] as Control;
                    if (this.selectedControl != control1) {
                        this.SelectedCard = (string) this.controlsVsCardNames[control1];
                    }
                }
                Monitor.Exit(this);
            }
        }

        public override void RemoveLayoutComponent(Control childControl) {
            if ((childControl != null) && !childControl.IsDisposed) {
                IEnumerator enumerator1 = this.cardNameVsControls.Values.GetEnumerator();
                IEnumerator enumerator2 = this.cardNameVsControls.Keys.GetEnumerator();
                while (enumerator1.MoveNext()) {
                    enumerator2.MoveNext();
                    Control control1 = (Control) enumerator1.Current;
                    if (control1 == childControl) {
                        this.cardNameVsControls.Remove(enumerator2.Current);
                        break;
                    }
                }
                this.controlsVsCardNames.Remove(childControl);
                childControl.Visible = true;
                if (this.selectedControl == childControl) {
                    this.Next();
                    if (this.selectedControl == childControl) {
                        this.SelectedCard = string.Empty;
                    }
                }
                base.RemoveLayoutComponent(childControl);
            }
        }

        protected override void ResetLayoutInfo() {
            if (base.ContainerControl != null) {
                base.ContainerControl.SuspendLayout();
            }
            foreach (Control control1 in this.GetControls()) {
                control1.Visible = true;
            }
            if (base.ContainerControl != null) {
                base.ContainerControl.ResumeLayout(false);
            }
            base.ResetLayoutInfo();
            this.cardNameVsControls.Clear();
            this.controlsVsCardNames.Clear();
            this.selectedControl = null;
        }

        [MergableProperty(false)]
        public void SetCardName(Control control, string value) {
            if (((!base.DesignMode || !base.LoadingDocument) ||
                 (!base.DesignerInTransaction || (base.ContainerControl == null))) ||
                base.ContainerControl.Contains(control)) {
                if ((value == null) || (value.Length == 0)) {
                    this.RemoveLayoutComponent(control);
                } else {
                    this.AddLayoutComponent(control, value);
                }
            }
        }

        public virtual void SetMaintainAspectRatio(Control control, bool value) {
            if (this.maintainAspectRatios[control] != null) {
                bool flag1 = (bool) this.maintainAspectRatios[control];
                if (flag1.Equals(value)) {
                    return;
                }
            }
            this.maintainAspectRatios[control] = value;
            if (base.ContainerControl != null) {
                base.ContainerControl.PerformLayout();
            }
        }

        public void Show(string cardName) {
            if (this.IsInit()) {
                this.SelectedCard = cardName;
            }
        }

        public void ValidateHiddenStates() {
            IList list1 = this.GetControls();
            foreach (Control control1 in list1) {
                if (control1 != this.selectedControl) {
                    control1.Visible = false;
                }
            }
            if (this.selectedControl != null) {
                this.selectedControl.Visible = true;
            }
        }

        [DefaultValue(CardLayoutMode.Default), Localizable(true), Category("Behavior")]
        public CardLayoutMode LayoutMode {
            get { return this.cardLayoutMode; }
            set {
                if (this.cardLayoutMode != value) {
                    this.cardLayoutMode = value;
                    if (base.ContainerControl != null) {
                        base.ContainerControl.PerformLayout();
                    }
                    base.MakeDirty();
                }
            }
        }

        public int NextCardIndex {
            get {
                if (!this.IsInit()) {
                    return -1;
                }
                IList list1 = this.GetControls();
                int num1 = (this.selectedControl == null) ? -1 : list1.IndexOf(this.selectedControl);
                return (((num1 + 1) < list1.Count) ? (num1 + 1) : 0);
            }
        }

        public int PreviousCardIndex {
            get {
                if (!this.IsInit()) {
                    return -1;
                }
                IList list1 = this.GetControls();
                int num1 = (this.selectedControl == null) ? -1 : list1.IndexOf(this.selectedControl);
                return ((num1 == 0) ? (list1.Count - 1) : (num1 - 1));
            }
        }

        [DefaultValue(""), TypeConverter(typeof (SelectedCardConverter)), Localizable(true), Category("Appearance"),
         Description("Specifies the current Card's name.")]
        public string SelectedCard {
            get {
                if (this.selectedControl == null) {
                    return string.Empty;
                }
                return (string) this.controlsVsCardNames[this.selectedControl];
            }
            set {
                if (this.initializing && (this.cardNameVsControls[value] == null)) {
                    this.cachedSelectedCardSetting = value;
                } else {
                    Control control1 = this.cardNameVsControls[value] as Control;
                    if ((this.selectedControl != control1) && ((value.Length == 0) || (control1 != null))) {
                        if (base.ContainerControl != null) {
                            base.ContainerControl.SuspendLayout();
                        }
                        if (this.selectedControl != null) {
                            this.selectedControl.Visible = false;
                        }
                        this.selectedControl = control1;
                        this.ValidateHiddenStates();
                        if (base.ContainerControl != null) {
                            base.ContainerControl.ResumeLayout(false);
                            if (this.selectedControl != null) {
                                base.ContainerControl.PerformLayout(this.selectedControl, "Visible");
                            }
                            base.MakeDirty();
                        }
                    }
                }
            }
        }
    }
}