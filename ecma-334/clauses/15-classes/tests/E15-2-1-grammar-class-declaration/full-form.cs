/*
Rules: E15-2-1-grammar-class-declaration
Authority: ECMA-334 7th ed 15.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public partial class Packet<T, U>
Into: public partial Packet<T, U>
*/
using System;
class StampAttribute : Attribute { }
public class Root { }
[Stamp]
public partial class Packet<T, U> : Root where T : class where U : struct
{
    public int Read() { return 47; }
};
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Packet<object, int>().Read() == 47, "complete-class-production");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
