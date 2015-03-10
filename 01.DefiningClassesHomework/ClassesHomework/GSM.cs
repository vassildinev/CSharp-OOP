namespace ClassesHomework
{
    using System.Collections.Generic;
    public class GSM
    {
        private const string EMPTY_STRING = "";

        // unique fields for every GSM
        private string gsmManufacturer;
        private string gsmModel;

        // fields that can change values
        private decimal price;
        private string owner;
        private Battery gsmBattery;
        private Display gsmDisplay;

        // List<Call> field
        private List<Call> callHistory;

        // iPhone 4S static field
        private static GSM iPhone4S =
            new GSM("Apple", "iPhone4S", 300M, "N/A",
                new Battery("Apple", "MaxBattery", 200, 14, BatteryType.Li_Po),
                new Display("Apple", "LED-backlit IPS LCD", "640x960", 1 << 24));

        // base constructor
        public GSM(string manufacturer, string model)
        {
            this.GsmManufacturer = manufacturer;
            this.GsmModel = model;
            this.gsmBattery = new Battery("N/A", "N/A");
            this.gsmDisplay = new Display("N/A", "N/A");
        }

        // additional constructor
        public GSM(string manufacturer, string model, decimal price, string owner, Battery bat, Display displ)
            : this(manufacturer, model)
        {
            this.Price = price;
            this.Owner = owner;
            this.gsmBattery = bat;
            this.gsmDisplay = displ;
            this.callHistory = new List<Call>();
        }

        // sample methods
        public void ChangeBattery(Battery newBattery)
        {
            this.gsmBattery = newBattery;
        }

        public void ChangeDisplay(Display newDisplay)
        {
            this.gsmDisplay = newDisplay;
        }

        public void AddCall(Call newIncomingCall)
        {
            this.callHistory.Add(newIncomingCall);
        }

        public void DeleteCall(Call desiredCall)
        {
            this.callHistory.Remove(desiredCall);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal TotalPriceOfOutgoingCalls(decimal pricePerCall)
        {
            decimal total = 0;
            foreach (var call in this.callHistory)
            {
                total += call.Duration / 60 * pricePerCall;
            }
            return total;
        }

        // properties
        public string GsmManufacturer
        {
            get
            {
                return this.gsmManufacturer;
            }
            set
            {
                if (value != EMPTY_STRING)
                {
                    this.gsmManufacturer = value;
                }
                else
                {
                    throw new System.ArgumentNullException("GSM manufacturer name must not be null or empty!");
                }
            }
        }

        public string GsmModel
        {
            get
            {
                return this.gsmModel;
            }
            set
            {
                if (value != EMPTY_STRING)
                {
                    this.gsmModel = value;
                }
                else
                {
                    throw new System.ArgumentNullException("Display model name must not be null or empty!");
                }
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value > 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Price must be larger than zero.");
                }
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (value != "")
                {
                    this.owner = value;
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("Owner must be different than null.");
                }
            }
        }

        public Battery Bat { get { return this.gsmBattery; } }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        public override string ToString()
        {
            return "Manufacturer: " + this.gsmManufacturer + "\nModel: " + this.gsmModel + "\nPrice: " + this.price + "\nOwner: " + this.owner + "\nBattery type: " + this.gsmBattery.BatType + "\nDisplay: " + this.gsmDisplay.DisplayManufacturer + " " + this.gsmDisplay.DisplayModel;
        }
    }
}
