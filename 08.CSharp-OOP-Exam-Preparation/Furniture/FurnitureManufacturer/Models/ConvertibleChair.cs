namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair, IChair, IFurniture
    {
        private const decimal DEFAULT_CONVERTED_HEIGHT = 0.10M;

        private bool isConverted;
        private decimal initialHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            :base(model, materialType, price, height, numberOfLegs)
        {
            this.isConverted = false;
            this.initialHeight = this.Height;
        }

        public bool IsConverted
        {
            get { return this.isConverted; }
        }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.Height = DEFAULT_CONVERTED_HEIGHT;
                this.isConverted = true;
            }
            else
            {
                this.Height = this.initialHeight;
                this.isConverted = false;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", 
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, 
                this.IsConverted ? "Converted" : "Normal");
        }
    }
}
