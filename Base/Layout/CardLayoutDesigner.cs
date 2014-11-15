#region

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;

#endregion

namespace FTS.BaseUI.Layout {
    /// <summary>
    /// Summary description for CardLayoutDesigner.
    /// </summary>
    public class CardLayoutDesigner : LMDesigner {
        private DesignerVerbCollection verbs;

        public CardLayoutDesigner() {
            //
            // TODO: Add constructor logic here
            //
        }

        private void Designer_SerializationComplete(object sender, EventArgs e) {
            if (base.Component is ISupportInitialize) {
                ((ISupportInitialize) base.Component).EndInit();
            }
            IDesignerSerializationManager manager1 =
                (IDesignerSerializationManager) this.GetService(typeof (IDesignerSerializationManager));
            if (manager1 != null) {
                manager1.SerializationComplete -= new EventHandler(this.Designer_SerializationComplete);
            }
        }

        public override void Initialize(IComponent component) {
            base.Initialize(component);
            if (component is ISupportInitialize) {
                ((ISupportInitialize) component).BeginInit();
                IDesignerSerializationManager manager1 =
                    (IDesignerSerializationManager) this.GetService(typeof (IDesignerSerializationManager));
                if (manager1 != null) {
                    manager1.SerializationComplete += new EventHandler(this.Designer_SerializationComplete);
                }
            }
        }

        private void OnFirstPage(object sender, EventArgs e) {
            CardLayout layout1 = base.Component as CardLayout;
            if (layout1 != null) {
                layout1.First();
            }
        }

        private void OnLastPage(object sender, EventArgs e) {
            CardLayout layout1 = base.Component as CardLayout;
            if (layout1 != null) {
                layout1.Last();
            }
        }

        private void OnNextPage(object sender, EventArgs e) {
            CardLayout layout1 = base.Component as CardLayout;
            if (layout1 != null) {
                layout1.Next();
            }
        }

        private void OnPreviousPage(object sender, EventArgs e) {
            CardLayout layout1 = base.Component as CardLayout;
            if (layout1 != null) {
                layout1.Previous();
            }
        }

        public override DesignerVerbCollection Verbs {
            get {
                if (this.verbs == null) {
                    this.verbs = new DesignerVerbCollection();
                    this.verbs.Add(new DesignerVerb("First Card", new EventHandler(this.OnFirstPage)));
                    this.verbs.Add(new DesignerVerb("Last Card", new EventHandler(this.OnLastPage)));
                    this.verbs.Add(new DesignerVerb("Next Card", new EventHandler(this.OnNextPage)));
                    this.verbs.Add(new DesignerVerb("Previous Card", new EventHandler(this.OnPreviousPage)));
                }
                return this.verbs;
            }
        }
    }
}