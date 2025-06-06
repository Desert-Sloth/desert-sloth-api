using System;

namespace desert.sloth.Domain.Catalog
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public decimal Price { get; set; }
        public List<Rating>? Ratings { get; set; } = new List<Rating>();

        public void AddRating(Rating rating){
            this.Ratings.Add(rating);
        }

        public Item(string name, string description, string brand, decimal price) {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name");
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("description");
            }
            if (string.IsNullOrEmpty(brand))
            {
                throw new ArgumentException("brand");
            }
            if (price < 0.00m)
            {
                throw new ArgumentException("Price must be greater than zero.");
            }

            this.Name = name;
            this.Description = description;
            this.Brand = brand;
            this.Price = price;
            this.Ratings = new List<Rating>();
        }
    }
}