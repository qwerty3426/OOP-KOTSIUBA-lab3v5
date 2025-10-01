using System;
using System.Collections.Generic;

/// <summary>
/// Базовий клас "Прилад"
/// </summary>
abstract class Device
{
    protected double power;  // Потужність приладу в Вт

    public Device(double power)
    {
        this.power = power;
        Console.WriteLine($"{GetType().Name} created with {power} W");
    }

    // Віртуальний метод: розрахунок добового споживання у кВт·год
    public virtual double DailyEnergyUsage()
    {
        return power * 24 / 1000.0;
    }

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

    public override double DailyEnergyUsage()
    {
        // Специфічний розрахунок для ноутбука, якщо потрібно
        return base.DailyEnergyUsage();
    }

    ~Laptop() { Console.WriteLine("Laptop destructor called"); }
}

/// <summary>
/// Холодильник
/// </summary>
class Fridge : Device
{
    public Fridge(double power) : base(power) { }

    public override double DailyEnergyUsage()
    {
        // Специфічний розрахунок для холодильника, якщо потрібно
        return base.DailyEnergyUsage();
    }

    ~Fridge() { Console.WriteLine("Fridge destructor called"); }
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
        foreach (var device in devices)
        {
            double daily = device.DailyEnergyUsage(); // Розрахунок всередині класу
            Console.WriteLine($"{device.GetType().Name} uses {daily:F2} kWh per day");
            totalEnergy += daily;
        }

        Console.WriteLine($"Total energy usage: {totalEnergy:F2} kWh/day");
    }
}
