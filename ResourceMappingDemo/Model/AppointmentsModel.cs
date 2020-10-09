using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ResourceViewDemo
{
    public class AppointmentsModel : NotificationObject
    {
        DateTime from, to;
        string eventName;
        bool isAllDay;
        string startTimeZone, endTimeZone;
        Brush color;
        private ObservableCollection<DateTime> recurrenceExceptionDates;
        private ObservableCollection<object> resourceIdCollection;
        private string rRUle;
        private object recurrenceId;
        private ObservableCollection<object> resources;
        private string notes;

        public AppointmentsModel() { }

        public DateTime From
        {
            get { return from; }
            set
            {
                from = value;
                RaisePropertyChanged("From");
            }
        }

        public DateTime To
        {
            get { return to; }
            set
            {
                to = value;
                RaisePropertyChanged("To");
            }
        }

        public bool IsAllDay
        {
            get { return isAllDay; }
            set
            {
                isAllDay = value;
                RaisePropertyChanged("IsAllDay");
            }
        }
        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                RaisePropertyChanged("EventName");
            }
        }

        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                RaisePropertyChanged("Notes");
            }
        }
        public string StartTimeZone
        {
            get { return startTimeZone; }
            set
            {
                startTimeZone = value;
                RaisePropertyChanged("StartTimeZone");
            }
        }
        public string EndTimeZone
        {
            get { return endTimeZone; }
            set
            {
                endTimeZone = value;
                RaisePropertyChanged("EndTimeZone");
            }
        }

        public Brush Background
        {
            get { return color; }
            set
            {
                color = value;
                RaisePropertyChanged("Background");
            }
        }

        public Object RecurrenceId
        {
            get { return recurrenceId; }
            set
            {
                recurrenceId = value;
                RaisePropertyChanged("RecurrenceId");
            }
        }

        public string RecurrenceRule
        {
            get { return rRUle; }
            set
            {
                rRUle = value;
                RaisePropertyChanged("RecurrenceRule");
            }
        }

        public ObservableCollection<DateTime> RecurrenceExceptions
        {
            get { return recurrenceExceptionDates; }
            set
            {
                recurrenceExceptionDates = value;
                RaisePropertyChanged("RecurrenceExceptions");
            }
        }

        public ObservableCollection<object> ResourceIdCollection
        {
            get { return resourceIdCollection; }
            set
            {
                resourceIdCollection = value;
                RaisePropertyChanged("ResourceIdCollection");
            }
        }

        /// <summary>
        /// Gets or sets Resource
        /// </summary>
        public ObservableCollection<object> Resources
        {
            get { return resources; }
            set
            {
                resources = value;
                this.RaisePropertyChanged("Resources");
            }
        }
    }
}
