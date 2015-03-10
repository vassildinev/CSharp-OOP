namespace ClassesHomework
{
    public enum BatteryType
    {
        Alkaline, Li_Ion, Li_Po, NiCd, NiMH, Pesho, Unknown
    }
    public class Battery
    {
        private const string EMPTY_STRING = "";

        private string batteryManufacturer;
        private string batteryModel;
        private readonly BatteryType batType;

        private readonly ushort? hoursIdle;
        private readonly ushort? hoursTalk;

        // base constructor
        public Battery(string manufacturer, string model)
        {
            this.BatteryManufacturer = manufacturer;
            this.BatteryModel = model;
            this.hoursIdle = 0;
            this.hoursTalk = 0;
            this.batType = BatteryType.Unknown;
        }

        // additional constructor
        public Battery(string manufacturer, string model, ushort hoursIdle, ushort hoursTalk, BatteryType batType)
            : this(manufacturer, model)
        {
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batType = batType;
        }

        // properties
        public string BatteryManufacturer
        {
            get
            {
                return this.batteryManufacturer;
            }
            set
            {
                if (value != EMPTY_STRING)
                {
                    this.batteryManufacturer = value;
                }
                else
                {
                    throw new System.ArgumentNullException("Battery manufacturer name must not be null or empty!");
                }
            }
        }

        public string BatteryModel
        {
            get
            {
                return this.batteryModel;
            }
            set
            {
                if (value != EMPTY_STRING)
                {
                    this.batteryModel = value;
                }
                else
                {
                    throw new System.ArgumentNullException("Battery model name must not be null or empty!");
                }
            }
        }

        public BatteryType BatType 
        { 
            get
            {
                return this.batType;
            }
        }
    }
}
