using System;

// 1. Strategy Interface
public interface IPaymentMethod
{
    void Pay(decimal amount);
}

// 2. Concrete Strategy Implementations
public class CardPayment : IPaymentMethod
{
    public void Pay(decimal amount) => Console.WriteLine($"Processed ${amount} via Credit/Debit Card Gateway.");
}

public class UpiPayment : IPaymentMethod
{
    public void Pay(decimal amount) => Console.WriteLine($"Processed ${amount} via Instant UPI Transfer.");
}

public class WalletPayment : IPaymentMethod
{
    public void Pay(decimal amount) => Console.WriteLine($"Processed ${amount} via Digital Wallet Balance.");
}

// 3. Context Class depending on Abstraction (DIP)
public class PaymentService
{
    private readonly IPaymentMethod _paymentMethod;

    // Injected via constructor
    public PaymentService(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod ?? throw new ArgumentNullException(nameof(paymentMethod));
    }

    public void Checkout(decimal amount)
    {
        Console.WriteLine("Initiating secure checkout workflow...");
        _paymentMethod.Pay(amount);
        Console.WriteLine("Checkout transaction completed successfully.\n");
    }
}

// 4. Execution Driver
class Program
{
    static void Main()
    {
        // Runtime selection of payment algorithm
        IPaymentMethod chosenMethod = new UpiPayment(); 
        PaymentService checkoutService = new PaymentService(chosenMethod);
        
        checkoutService.Checkout(4500.00m);
    }
}