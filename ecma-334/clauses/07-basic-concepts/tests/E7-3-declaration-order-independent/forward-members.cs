/*
Rules: E7-3-declaration-order-independent; E7-7-1-member-forward-reference
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Last = 43;
Into: public const int Renamed = 43;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Later.Holder.Read() == 43, "forward-namespace-type-method-property-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
namespace Later
{
    class Holder
    {
        public static int Read() { return Value; }
        public static int Value { get { return Last; } }
        public const int Last = 43;
    }
}
