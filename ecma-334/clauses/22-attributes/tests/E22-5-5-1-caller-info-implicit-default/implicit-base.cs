/*
Rules: E22-5-5-1-caller-info-implicit-default
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Child : Parent { }
Into: class Child : Parent { public Child() : base("explicit") { } }
*/
using System;
class Parent { public string Name; public Parent([System.Runtime.CompilerServices.CallerMemberName] string name = "default") { Name = name; } }
class Child : Parent { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Child().Name == "default", "implicit-base-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
