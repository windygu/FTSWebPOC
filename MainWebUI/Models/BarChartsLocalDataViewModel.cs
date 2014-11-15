using System;
using System.Linq;

namespace FTS.MainWebUI.Models
{
    public class BarChartsLocalDataViewModel : BlogComments
    {
        public BarChartsLocalDataViewModel()
        {
        }

        public BarChartsLocalDataViewModel(BlogComments blogComments)
            : base(blogComments.Blog, blogComments.Day, blogComments.Value)
        {
        }

        public string UserColor { get; set; }
    }
}