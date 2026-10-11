/*
Rules: E12-8-16-7-base-projection-form; E12-8-16-7-projection-name; E12-8-16-7-projection-value
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new { base.Code }
Into: new { this.Code }
*/
using System;
class Base { public int Code = 7; }
class Derived : Base
{
    public new int Code = 19;
    public int ReadProjection() { var value = new { base.Code }; return value.Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived().ReadProjection() == 7, "base-projection-name-and-base-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
