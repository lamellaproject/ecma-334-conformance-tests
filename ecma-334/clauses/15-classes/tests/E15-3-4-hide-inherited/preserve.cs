/*
Rules: E15-3-4-hide-inherited; E15-3-4-hiding-preserves-member; E15-3-4-cannot-remove-inherited
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public new string Token = "child";
Into: 
*/
using System;
class Parent { public int Token = 311; }
class Child : Parent { public new string Token = "child"; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child value = new Child();
        Parent parent = value;
        Check(value.Token == "child", "derived-name-hides-different-typed-base-field");
        Check(parent.Token == 311, "hiding-does-not-remove-base-definition");
        parent.Token = 313;
        Check(parent.Token == 313 && value.Token == "child", "hidden-base-field-remains-independent-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
