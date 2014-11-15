using System;
using System.Linq;

namespace FTS.MainWebUI.Models
{
    public class NavigationWidget : NavigationItem
    {
        public string ThumbnailUrl { get; set; }
        public string SpriteCssClass { get; set; }
        public bool Tablet { get; set; }
        public bool Expanded { get; set; }
        public NavigationExample[] Items { get; set; }
    }
}
