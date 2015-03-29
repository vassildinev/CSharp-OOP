namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;

    public abstract class Furniture : IFurniture
    {
        protected string model;
        protected MaterialType materialType;
        protected decimal price;
        protected decimal height;

        protected Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.model = model;
            this.materialType = materialType;
            this.price = price;
            this.height = height;
        }

        public string Model
        {
            get 
            { 
                return this.model; 
            }

            set
            {
                if (value == null || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Table model must not be null or less than 3 chacters in length");
                }
                this.model = value;
            }
        }

        public string Material
        {
            get 
            { 
                return this.materialType.ToString(); 
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0M)
                {
                    throw new ArgumentOutOfRangeException("Price of table must be a positive decimal number");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get 
            {
                return this.height; 
            }

            set
            {
                if (value <= 0M)
                {
                    throw new ArgumentOutOfRangeException("Height of table must be a positive decimal number");
                }
                this.height = value;
            }
        }
    }
}
