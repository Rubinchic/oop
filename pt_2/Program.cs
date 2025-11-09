using System;
using System.Collections.Generic;

abstract class Product
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }

    public Product(string name, string manufacturer, double price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Price = price;
    }

    public abstract void ShowInfo();

    public virtual void ApplyDiscount()
    {
        Console.WriteLine($"{Name}: стандартна знижка 5%");
        Price *= 0.95;
    }
}

class FoodProduct : Product
{
    public DateTime ExpirationDate { get; set; }

    public FoodProduct(string name, string manufacturer, double price, DateTime expiration)
        : base(name, manufacturer, price)
    {
        ExpirationDate = expiration;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Продукт харчування: {Name}, {Manufacturer}, ціна: {Price:F2} грн, до {ExpirationDate.ToShortDateString()}");
    }

    public override void ApplyDiscount()
    {
        Console.WriteLine($"{Name}: знижка 10% для харчових продуктів");
        Price *= 0.90;
    }
}

class Electronics : Product
{
    public int WarrantyMonths { get; set; }

    public Electronics(string name, string manufacturer, double price, int warranty)
        : base(name, manufacturer, price)
    {
        WarrantyMonths = warranty;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Електроніка: {Name}, {Manufacturer}, ціна: {Price:F2} грн, гарантія: {WarrantyMonths} міс");
    }

    public override void ApplyDiscount()
    {
        Console.WriteLine($"{Name}: знижка 7% для електроніки");
        Price *= 0.93;
    }
}

class Clothing : Product
{
    public string Size { get; set; }

    public Clothing(string name, string manufacturer, double price, string size)
        : base(name, manufacturer, price)
    {
        Size = size;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Одяг: {Name}, {Manufacturer}, розмір: {Size}, ціна: {Price:F2} грн");
    }

    public override void ApplyDiscount()
    {
        Console.WriteLine($"{Name}: знижка 15% для одягу");
        Price *= 0.85;
    }
}

// Головна програма
class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new FoodProduct("Хліб", "Хлібокомбінат №1", 25, DateTime.Now.AddDays(3)),
            new Electronics("Смартфон", "Samsung", 15000, 24),
            new Clothing("Футболка", "Nike", 1200, "L")
        };

        foreach (var item in products)
        {
            item.ShowInfo();
            item.ApplyDiscount();
            Console.WriteLine($"Ціна після знижки: {item.Price:F2} грн\n");
        }
    }
}