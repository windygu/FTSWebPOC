#region

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for LMDesigner.
    /// </summary>
    public class LMDesigner : ComponentDesigner {
        public LMDesigner() {
            //
            // TODO: Add constructor logic here
            //
        }

        private void Designer_ComponentAdded(object sender, ComponentEventArgs e) {
            if ((e.Component is Control) && !(e.Component is Form)) {
                (e.Component as Control).ParentChanged += new EventHandler(this.OnControlParentChanged);
            } else if (e.Component == base.Component) {
                IDesignerHost host1 = this.GetService(typeof (IDesignerHost)) as IDesignerHost;
                foreach (IComponent component1 in host1.Container.Components) {
                    if ((component1 is Control) && !(component1 is Form)) {
                        Control control1 = component1 as Control;
                        control1.ParentChanged += new EventHandler(this.OnControlParentChanged);
                    }
                }
            }
        }

        private void Designer_ComponentRemoved(object sender, ComponentEventArgs e) {
            if ((e.Component is Control) && !(e.Component is Form)) {
                (e.Component as Control).ParentChanged -= new EventHandler(this.OnControlParentChanged);
            }
        }

        private void Designer_SerializationComplete(object sender, EventArgs e) {
            IExtenderProviderService service1 =
                (IExtenderProviderService) this.GetService(typeof (IExtenderProviderService));
            service1.AddExtenderProvider((IExtenderProvider) base.Component);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                IDesignerHost host1 = (IDesignerHost) this.GetService(typeof (IDesignerHost));
                if (host1 != null) {
                    foreach (IComponent component1 in host1.Container.Components) {
                        if ((component1 is Control) && !(component1 is Form)) {
                            (component1 as Control).ParentChanged -= new EventHandler(this.OnControlParentChanged);
                        }
                    }
                }
                IComponentChangeService service1 =
                    (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
                if (service1 != null) {
                    service1.ComponentAdded -= new ComponentEventHandler(this.Designer_ComponentAdded);
                    service1.ComponentRemoved -= new ComponentEventHandler(this.Designer_ComponentRemoved);
                }
                IDesignerSerializationManager manager1 =
                    (IDesignerSerializationManager) this.GetService(typeof (IDesignerSerializationManager));
                if (manager1 != null) {
                    manager1.SerializationComplete -= new EventHandler(this.Designer_SerializationComplete);
                }
            }
            base.Dispose(disposing);
        }

        public override void Initialize(IComponent component) {
            base.Initialize(component);
            LayoutManager manager1 = (LayoutManager) component;
            IDesignerHost host1 = (IDesignerHost) this.GetService(typeof (IDesignerHost));
            manager1.DesignerHost = host1;
            Control control1 = null;
            if (!host1.Loading) {
                ISelectionService service1 = (ISelectionService) base.GetService(typeof (ISelectionService));
                if (service1 != null) {
                    ICollection collection1 = service1.GetSelectedComponents();
                    if (collection1 != null) {
                        IEnumerator enumerator1 = collection1.GetEnumerator();
                        if ((enumerator1 != null) && enumerator1.MoveNext()) {
                            IComponent component1 = (IComponent) enumerator1.Current;
                            if ((component1 != null) && (component1 is Control)) {
                                Control control2 = (Control) component1;
                                if (((control2 != null) && (manager1 != null)) &&
                                    (MessageBox.Show(
                                        "Do you want to make " + control2.Name +
                                        " the LayoutManager's ContainerControl?", "LayoutManager Designer",
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)) {
                                    control1 = control2;
                                }
                            }
                        }
                    }
                }
            }
            IExtenderListService service2 = (IExtenderListService) base.GetService(typeof (IExtenderListService));
            if ((service2 != null) && (control1 != null)) {
                IExtenderProvider[] providerArray1 = service2.GetExtenderProviders();
                IExtenderProvider[] providerArray2 = providerArray1;
                for (int num1 = 0; num1 < providerArray2.Length; num1++) {
                    IExtenderProvider provider1 = providerArray2[num1];
                    LayoutManager manager2 = provider1 as LayoutManager;
                    if (((manager2 != null) && (manager1 != manager2)) &&
                        ((manager2.ContainerControl != null) && (manager2.ContainerControl == control1))) {
                        MessageBox.Show(
                            "Specified container is already bound to a Layout Manager. Try a different container.",
                            "LayoutManager Designer Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        control1 = null;
                    }
                }
            }
            if (!host1.Loading && (control1 != null)) {
                manager1.ContainerControl = control1;
            }
            IComponentChangeService service3 =
                (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
            if (service3 != null) {
                service3.ComponentAdded += new ComponentEventHandler(this.Designer_ComponentAdded);
                service3.ComponentRemoved += new ComponentEventHandler(this.Designer_ComponentRemoved);
            }
            manager1.ContainerControlChanged += new EventHandler(this.LM_ContainerControlChanged);
            IDesignerSerializationManager manager3 =
                (IDesignerSerializationManager) this.GetService(typeof (IDesignerSerializationManager));
            if (manager3 != null) {
                manager3.SerializationComplete += new EventHandler(this.Designer_SerializationComplete);
            }
        }

        private void LM_ContainerControlChanged(object sender, EventArgs e) {
            IDesignerHost host1 = this.GetService(typeof (IDesignerHost)) as IDesignerHost;
            foreach (IComponent component1 in host1.Container.Components) {
                if ((component1 is Control) && !(component1 is Form)) {
                    Control control1 = component1 as Control;
                    TypeDescriptor.Refresh(control1);
                }
            }
        }

        public void OnControlParentChanged(object sender, EventArgs e) {
            Control control1 = sender as Control;
            TypeDescriptor.Refresh(control1);
        }

        private void ReloadDesigner() {
            IDesignerHost host1 = (IDesignerHost) this.GetService(typeof (IDesignerHost));
            if ((host1 != null) && !host1.Loading) {
                IDesignerLoaderService service1 =
                    (IDesignerLoaderService) this.GetService(typeof (IDesignerLoaderService));
                if (service1 != null) {
                    IDesignerSerializationManager manager1 =
                        (IDesignerSerializationManager) this.GetService(typeof (IDesignerSerializationManager));
                    if (manager1 != null) {
                        manager1.SerializationComplete += new EventHandler(this.Designer_SerializationComplete);
                    }
                    service1.Reload();
                }
            }
        }
    }
}