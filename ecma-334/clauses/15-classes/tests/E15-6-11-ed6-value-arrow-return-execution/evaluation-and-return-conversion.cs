/*
Rules: E15-6-11-ed6-value-arrow-return-execution
Authority: ECMA-334 6th ed 14.6.11
Version: 6
Expected: run
Stdout: OK 2
Mutate: => Supply();
Into: => 46;
*/
using System;
class Product
{
    public int Code;
    public static implicit operator Product(int input)
    {
        Program.Trace = Program.Trace * 10 + 3;
        return new Product { Code = input + 1 };
    }
}
class Program
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static int Trace;
    static int Supply() { Trace = Trace * 10 + 1; return 46; }
    static Product Build() => Supply();
    static int Main()
    {
        Product product = Build();
        Check(Trace == 13, "arrow-evaluation-before-return-conversion-once");
        Check(product.Code == 47, "arrow-returns-converted-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
