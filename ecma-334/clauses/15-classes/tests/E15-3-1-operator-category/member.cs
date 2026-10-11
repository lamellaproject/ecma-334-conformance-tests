/*
Rules: E15-3-1-operator-category; E15-3-1-grammar-class-member-declaration-form-7
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static Amount operator +(Amount left, Amount right)
Into: public static Amount operator -(Amount left, Amount right)
*/
using System;
class Amount
{
    public int Number;
    public Amount(int number) { Number = number; }
    public static Amount operator +(Amount left, Amount right)
    {
        return new Amount(left.Number + right.Number);
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((new Amount(139) + new Amount(149)).Number == 288, "operator-applies-to-class-instances");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
