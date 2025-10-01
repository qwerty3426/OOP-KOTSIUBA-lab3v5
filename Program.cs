using System;
using System.Collections.Generic;

/// <summary>
/// Базовий клас "Прилад"
/// </summary>
abstract class Device
{
    protected double power;  // Потужність приладу

    // Конструктор базового класу
    public Device(double power)
    {
        this.power = power;
        Console.WriteLine($"{GetType().Name} created with {power} W");
    }

    // Абстрактний метод – обов'язково реалізується в похідних класах
    public abstract double PowerUsage();

    // Віртуальний метод – можна перевизначити в похідних
    public virtual void ShowInfo()
    {
        Console.WriteLine($"{GetType().Name} power: {power} W");
    }

    // Деструктор
    ~Device()
    {
        Console.WriteLine($"{GetType().Name} destroyed");
    }
}

/// <summary>
/// Ноутбук
/// </summary>
class Laptop : Device
{
    public Laptop(double power) : base(power) { }

    // Реалізація абстрактного методу
    public override double PowerUsage()
    {
        return power;
    }

    // Перевизначення віртуального методу (опціонально)
    public override void ShowInfo()
    {
        Console.WriteLine($"Laptop consumes {power} W");
    }

    ~Laptop()
    {
        Console.WriteLine("Laptop destructor called");
    }
}

/// <summary>
/// Холодильник
/// </summary>
class Fridge : Device
{
    public Fridge(double power) : base(power) { }

    public override double PowerUsage()
    {
        return power;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Fridge consumes {power} W");
    }

    ~Fridge()
    {
        Console.WriteLine("Fridge destructor called");
    }
}

class Program
{
    static void Main()
    {
        List<Device> devices = new List<Device>
        {
            new Laptop(60),
            new Fridge(150)
        };

        double totalEnergy = 0;

        foreach (var d in devices)
        {
            d.ShowInfo();
            double daily = d.PowerUsage() * 24 / 1000.0;
            Console.WriteLine($"{d.GetType().Name} uses {daily:F2} kWh per day\n");
            totalEnergy += daily;
        }

        Console.WriteLine($"Total energy usage: {totalEnergy:F2} kWh/day");
    }
}
