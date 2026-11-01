using System;

// Base Bird class containing shared generic behaviors
public class Bird
{
    public virtual void MakeSound() => Console.WriteLine("Generic bird sound.");
}

// Segregated interface for flying creatures
public interface IFlyable
{
    void Fly();
}

// Sparrow implements both Bird base traits and flying capability
public class Sparrow : Bird, IFlyable
{
    public override void MakeSound() => Console.WriteLine("Sparrow chirps: Chrip, chirp!");
    public void Fly() => Console.WriteLine("Sparrow is soaring through the sky.");
}

// Penguin is a bird, but it does NOT implement IFlyable (LSP & ISP respected)
public class Penguin : Bird
{
    public override void MakeSound() => Console.WriteLine("Penguin honks softly.");
    // No Fly() method forced here!
}

// Execution Driver
class Program
{
    static void Main()
    {
        Bird sparrow = new Sparrow();
        sparrow.MakeSound();
        ((IFlyable)sparrow).Fly();

        Bird penguin = new Penguin();
        penguin.MakeSound();
        // Compile-time safety prevents calling penguin.Fly() because Penguin doesn't implement IFlyable.
        Console.WriteLine("Penguin successfully instantiated without forced exception-throwing methods.");
    }
}