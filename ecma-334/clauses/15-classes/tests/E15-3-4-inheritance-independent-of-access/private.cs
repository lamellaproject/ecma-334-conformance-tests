/*
Rules: E15-3-4-inheritance-independent-of-access
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class Child : Parent
Into: public class Child
*/
using System;
class Parent
{
    private int Secret = 337;
    private int ReadSecret() { return Secret + 2; }
    public class Child : Parent
    {
        public int Field() { return this.Secret; }
        public int Method() { return this.ReadSecret(); }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent.Child value = new Parent.Child();
        Check(value.Field() == 337, "private-base-field-inherited-in-accessible-nested-context");
        Check(value.Method() == 339, "private-base-method-inherited-in-accessible-nested-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
