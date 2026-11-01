using System;

// Common Interface ensuring OCP compliance
public interface IDiscount
{
    double GetDiscountPercentage();
}

// Concrete Implementations for each customer type
public class RegularDiscount : IDiscount
{
    public double GetDiscountPercentage() => 0.10; // 10%
}

public class PremiumDiscount : IDiscount
{
    public double GetDiscountPercentage() => 0.20; // 20%
}

public class GoldDiscount : IDiscount
{
    public double GetDiscountPercentage() => 0.30; // 30%
}

// Closed for modification, open for extension via interface injection
public class DiscountCalculatorService
{
    public double CalculateFinalPrice(double originalPrice, IDiscount discountStrategy)
    {
        double discountRate = discountStrategy.GetDiscountPercentage();
        return originalPrice - (originalPrice * discountRate);
    }
}

// Execution Driver
class Program
{
    static void Main()
    {
        double baseAmount = 1000.00;
        DiscountCalculatorService service = new DiscountCalculatorService();
        
        IDiscount goldCustomer = new GoldDiscount();
        double finalPrice = service.CalculateFinalPrice(baseAmount, goldCustomer);
        
        Console.WriteLine($"Original: ${baseAmount} | Gold Final Price: ${finalPrice}");
    }
}
