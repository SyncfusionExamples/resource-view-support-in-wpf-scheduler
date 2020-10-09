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
        private ObservableCollection<AppointmentsModel> events;
        private ObservableCollection<object> resources;
        private List<string> eventNames;

        public ResourceViewModel()
        {
            CreateResources();
            CreateResourceAppointments();
        }
        public ObservableCollection<AppointmentsModel> Events
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
            Events = new ObservableCollection<AppointmentsModel>();
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
                var scheduleResource = resurceCollection[resource] as Employee;
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
                            DateTime dateTime1 = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
                            Events.Add(new AppointmentsModel()
                            {
                                From = dateTime1,
                                To = dateTime1.AddHours(2),
                                EventName = this.eventNames[randomTime.Next(4)],
                                ResourceIdCollection = new ObservableCollection<object>() { scheduleResource.Id },
                                Background = scheduleResource.BackgroundBrush,
                            });
                        }
                    }

                }
            }
        }

        private void CreateResources()
        {
            Random random = new Random();
            this.Resources = new ObservableCollection<object>();
            var nameCollection = new List<string>();
            nameCollection.Add("Sophia");
            nameCollection.Add("Zoey Addison");
            nameCollection.Add("James William");
            nameCollection.Add("Adeline Elena");
            nameCollection.Add("Emilia William");
            nameCollection.Add("Kinsley Elena");
            nameCollection.Add("Adeline Ruby");
            nameCollection.Add("Kinsley Ruby");

            var colorCollection = new List<Brush>();
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));

            for (int i = 0; i < 4; i++)
            {
                Employee employee = new Employee();
                employee.Name = nameCollection[i];
                employee.ForegroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                if (i == 0)
                    employee.BackgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9d65c9"));
                else if (i == 1)
                    employee.BackgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f08a5d"));
                else if (i == 2)
                    employee.BackgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#679b9b"));
                else
                    employee.BackgroundBrush = colorCollection[random.Next(3)];
                employee.Id = i.ToString();
                //employee.ImageSource = "/ResourceHeaderTemplateDemo;component/Assets/People/People_Circle" + i.ToString() + ".png";
                Resources.Add(employee);
            }
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
