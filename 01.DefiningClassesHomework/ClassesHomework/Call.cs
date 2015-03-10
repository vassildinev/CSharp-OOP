namespace ClassesHomework
{
    using System;
    public class Call
    {
        // contains both date and time
        private DateTime callStartDate;
        private DateTime callEndDate;

        private string dialedPhoneNumber;

        public Call(DateTime callStartDate, DateTime callEndDate, string dialedPhoneNumber)
        {
            this.CallStartDate = callStartDate;
            this.CallEndDate = callEndDate;
            this.dialedPhoneNumber = dialedPhoneNumber;
        }

        public DateTime CallStartDate
        {
            get
            {
                return this.callStartDate;
            }
            set
            {
                this.callStartDate = value;
            }
        }

        public DateTime CallEndDate
        {
            get
            {
                return this.callEndDate;
            }
            set
            {
                if (this.callStartDate < value)
                {
                    this.callEndDate = value;
                }
                else
                {
                    throw new ArgumentException("End date cannot be before start date!");
                }
            }
        }

        public ushort Duration
        {
            get
            {
                return (ushort)(this.callEndDate - this.callStartDate).TotalSeconds;
            }
        }

        public string StartTime
        {
            get
            {
                return string.Format("{0}:{1}:{2}", 
                    this.callStartDate.Hour,
                    this.callStartDate.Minute,
                    this.callStartDate.Second);
            }
        }

        public string EndTime
        {
            get
            {
                return string.Format("{0}:{1}:{2}",
                    this.callEndDate.Hour,
                    this.callEndDate.Minute,
                    this.callEndDate.Second);
            }
        }

        public string DialedPhoneNumber
        {
            get
            {
                return this.dialedPhoneNumber;
            }
        }

        public override string ToString()
        {
            return "Dialed number: " + this.DialedPhoneNumber
                + "\nStart date and time: " + this.CallStartDate
                + "\nEnd date and time: " + this.callEndDate
                + "\nCall duration: " + this.Duration + " seconds";
        }
    }
}
