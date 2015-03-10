namespace ClassesHomework
{
    public class Display
    {
        private const string EMPTY_STRING = "";

        private string displayManufacturer;
        private string displayModel;

        // 240x320 for example
        private readonly string displaySize;

        // 2^24 = 16M colors
        private readonly ulong displayColorsCount;

        // base constructor
        public Display(string manufacturer, string model)
        {
            this.DisplayManufacturer = manufacturer;
            this.DisplayModel = model;
            this.displaySize = "N/A";
            this.displayColorsCount = 0;
        }

        // additional constructor
        public Display(string manufacturer, string model, string size, ulong colorsCount)
            :this(manufacturer, model)
        {
            this.displaySize = size;
            this.displayColorsCount = colorsCount;
        }
        public string DisplayManufacturer

        {
            get
            {
                return this.displayManufacturer;
            }
            set
            {
                if (value != EMPTY_STRING)
                {
                    this.displayManufacturer = value;
                }
                else
                {
                    throw new System.ArgumentNullException("Display manufacturer name must not be null or empty!");
                }
            }
        }

        public string DisplayModel
        {
            get
            {
                return this.displayModel;
            }
            set
            {
                if (value != EMPTY_STRING)
                {
                    this.displayModel = value;
                }
                else
                {
                    throw new System.ArgumentNullException("Display model name must not be null or empty!");
                }
            }
        }
    }
}
