using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraNavBar.ViewInfo;
using System.Drawing;
using DevExpress.XtraNavBar;

namespace FTS.BaseUI.Controls
{
    public class CustomSkinNavPaneViewInfo : SkinNavigationPaneViewInfo
    {
        public CustomSkinNavPaneViewInfo(NavBarControl navBar) : base(navBar) { }
        protected override NavigationPaneHeaderPainter CreateNavPaneHeaderPainter()
        {
            return new CustomSkinNavPaneHeaderPainter(this);
        }
    }
    public class CustomSkinNavPaneHeaderPainter : SkinNavigationPaneHeaderPainter
    {
        public CustomSkinNavPaneHeaderPainter(NavigationPaneViewInfo navInfo) : base(navInfo) { }
        public override Rectangle CalcObjectMinBounds(ObjectInfoArgs e)
        {
            return Rectangle.Empty;
        }
    }
    public class CustomSkinNavPaneViewInfoRegistrator : SkinNavigationPaneViewInfoRegistrator
    {
        public override string ViewName { get { return "CustomNavPaneView"; } }
        public override NavBarViewInfo CreateViewInfo(NavBarControl navBar)
        {
            return new CustomSkinNavPaneViewInfo(navBar);
        }
    }
}
