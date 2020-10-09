using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ResourceViewDemo
{
    public class ResourceViewModel: NotificationObject
    {
        private ScheduleAppointmentCollection events;
        private ObservableCollection<object> resources;
        private List<string> eventNames;

        public ResourceViewModel()
        {
            CreateResources();
            CreateResourceAppointments();
        }
        public ScheduleAppointmentCollection Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged("Events");
            }
        }

        public ObservableCollection<object> Resources
        {
            get
            {
                return resources;
            }
            set
            {
                resources = value;
                RaisePropertyChanged("Resources");
            }
        }

        private void CreateResourceAppointments()
        {
            Events = new ScheduleAppointmentCollection();
            Random randomTime = new Random();

            List<Point> randomTimeCollection = this.GettingTimeRanges();
            var resurceCollection = this.Resources as ObservableCollection<object>;

            this.eventNames = new List<string>();
            this.eventNames.Add("General Meeting");
            this.eventNames.Add("Plan Execution");
            this.eventNames.Add("Project Plan");
            this.eventNames.Add("Consulting");
            this.eventNames.Add("Performance Check");
            this.eventNames.Add("Yoga Therapy");

            for (int resource = 0; resource < resurceCollection.Count; resource++)
            {
                var scheduleResource = resurceCollection[resource] as SchedulerResource;
                DateTime date;
                DateTime dateFrom = DateTime.Now.AddDays(-15);
                DateTime dateTo = DateTime.Now.AddDays(15);
                DateTime dateRangeStart = DateTime.Now.AddDays(-15);
                DateTime dateRangeEnd = DateTime.Now.AddDays(15);

                for (date = dateFrom; date < dateTo; date = date.AddDays(1))
                {
                    if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                    {
                        for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 4; additionalAppointmentIndex++)
                        {
                            //int dateTime = randomTime.Next(0, 23);
                            DateTime dateTime1 = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
                            Events.Add(new ScheduleAppointment()
                            {
                                StartTime = dateTime1,
                                EndTime = dateTime1.AddHours(2),
                                Subject = this.eventNames[randomTime.Next(4)],
                                ResourceIdCollection = new ObservableCollection<object>() { scheduleResource.Id },
                                AppointmentBackground = scheduleResource.Background,
                            });
                        }
                    }

                }
            }
        }

        private void CreateResources()
        {
            Resources = new ObservableCollection<object>()
            {
            new SchedulerResource() { Name = "Sophia", Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")), Background =  new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9d65c9")), Id = "1000" },
            new SchedulerResource() { Name = "Zoey Addison", Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),Background =  new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f08a5d")), Id = "1001" },
            new SchedulerResource() { Name = "James William",Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")), Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#679b9b")), Id = "1002" },
            };
        }
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }
    }
}
