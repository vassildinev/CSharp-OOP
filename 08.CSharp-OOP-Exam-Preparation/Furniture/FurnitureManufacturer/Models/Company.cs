namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private List<IFurniture> furnitures;
        public Company(string name, string registrationNumber)
        {
            this.name = name;
            this.registrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null || value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Company name must not be null or less than 5 chacters in length");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            set
            {
                if (value.Select(x => char.IsLetter(x)).ToList().Count != 0
                    || value.Length != 10)
                {
                    throw new ArgumentException("Company registration number must only contain digits and be exactly 10 characters in length");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return this.furnitures; }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
            this.furnitures = this.furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList(); // keeping the order
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            for (int i = 0; i < this.furnitures.Count; i++)
            {
                if (this.furnitures[i].Model.ToLower() == model.ToLower()) // case insensitive search
                {
                    return this.furnitures[i];
                }
            }
            return null;
        }

        public string Catalog()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name, this.RegistrationNumber, this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));
            foreach (var item in this.furnitures)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
