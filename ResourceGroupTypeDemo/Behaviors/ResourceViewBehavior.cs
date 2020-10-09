using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ResourceViewDemo
{
    /// <summary>
    /// Implements methods to add special time region (Non working hours and lunch hour) for resources.
    /// </summary>
    public class ResourceViewBehavior : Behavior<SfScheduler>
    {
        protected override void OnAttached()
        {
            var specialTimeRegions = this.GetSpecialTimeRegions();
            this.AssociatedObject.TimelineViewSettings.SpecialTimeRegions = specialTimeRegions;
            this.AssociatedObject.DaysViewSettings.SpecialTimeRegions = specialTimeRegions;
        }

        private ObservableCollection<SpecialTimeRegion> GetSpecialTimeRegions()
        {
            var resourceViewModel = this.AssociatedObject.DataContext as ResourceViewModel;
            var currentDate = DateTime.Now;
            var nonWorkingHours_1 = new SpecialTimeRegion();
            nonWorkingHours_1.StartTime = new DateTime(currentDate.Year, currentDate.AddMonths(-3).Month, 1, 0, 0, 0);
            nonWorkingHours_1.EndTime = nonWorkingHours_1.StartTime.AddHours(9);
            nonWorkingHours_1.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            nonWorkingHours_1.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";
            nonWorkingHours_1.ResourceIdCollection = new ObservableCollection<object>(resourceViewModel.Resources.Select(resource => (resource as SchedulerResource).Id).ToList());

            var nonWorkingHours_2 = new SpecialTimeRegion();
            nonWorkingHours_2.StartTime = new DateTime(currentDate.Year, currentDate.AddMonths(-3).Month, 1, 18, 0, 0);
            nonWorkingHours_2.EndTime = new DateTime(currentDate.Year, currentDate.AddMonths(-3).Month, 1, 23, 59, 59);
            nonWorkingHours_2.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            nonWorkingHours_2.ResourceIdCollection = new ObservableCollection<object>(resourceViewModel.Resources.Select(resource => (resource as SchedulerResource).Id).ToList());
            nonWorkingHours_2.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";

            var lunchHour = new SpecialTimeRegion();
            lunchHour.StartTime = new DateTime(currentDate.Year, currentDate.AddMonths(-3).Month, 1, 13, 0, 0);
            lunchHour.EndTime = new DateTime(currentDate.Year, currentDate.AddMonths(-3).Month, 1, 14, 0, 0);
            lunchHour.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            lunchHour.Text = "Lunch";
            lunchHour.CanEdit = false;
            lunchHour.ResourceIdCollection = new ObservableCollection<object>(resourceViewModel.Resources.Select(resource => (resource as SchedulerResource).Id).ToList());
            lunchHour.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";

            var specialTimeRegions = new ObservableCollection<SpecialTimeRegion>();
            specialTimeRegions.Add(nonWorkingHours_1);
            specialTimeRegions.Add(nonWorkingHours_2);
            specialTimeRegions.Add(lunchHour);
            return specialTimeRegions;
        }
    }
}
