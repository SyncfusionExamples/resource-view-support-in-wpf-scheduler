using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ResourceViewDemo
{
    public class ResourceTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceTemplateSelector" /> class.
        /// </summary>
        public ResourceTemplateSelector()
        {
        }

        public DataTemplate DayViewResourceTemplate { get; set; }

        public DataTemplate TimelineViewResourceTemplate { get; set; }

        /// <summary>
        /// Template selection method
        /// </summary>
        /// <param name="item">return the object</param>
        /// <param name="container">return the bindable object</param>
        /// <returns>return the template</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var schedule = Syncfusion.Windows.Shared.VisualUtils.FindVisualParent<SfScheduler>(container);
            if (schedule == null)
                return null;

            if (schedule.ViewType != SchedulerViewType.Timeline)
                return DayViewResourceTemplate;
            else
                return TimelineViewResourceTemplate;
        }
    }
}
