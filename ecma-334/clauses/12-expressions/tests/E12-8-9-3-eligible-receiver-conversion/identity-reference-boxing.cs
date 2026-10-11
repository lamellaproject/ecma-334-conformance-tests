/*
Rules: E12-8-9-3-eligible-receiver-conversion; E12-8-9-3-best-extension; E12-8-9-3-selected-class
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: receiver.Identity()
Into: receiver.Reference()
*/
using System;
class Base { }
class Derived : Base { }
static class Extensions
{
    public static int Identity(this Derived receiver) { return 1; }
    public static int Identity(this object receiver) { return 9; }
    public static int Reference(this Base receiver) { return 2; }
    public static int Boxing(this object receiver) { return (int)receiver + 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived();
        Check(receiver.Identity() == 1, "identity-receiver-conversion-is-best");
        Check(receiver.Reference() == 2, "implicit-reference-receiver-conversion");
        Check(5.Boxing() == 8, "boxing-receiver-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
