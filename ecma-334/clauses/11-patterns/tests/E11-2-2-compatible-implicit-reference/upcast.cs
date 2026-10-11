/*
Rules: E11-2-2-compatible-implicit-reference
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: source is Parent value
Into: source is Other value
*/
using System;
class Parent { }
class Child : Parent { }
sealed class Other { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child source = new Child();
        Parent answer = null;
        if (source is Parent value) answer = value;
        Check(object.ReferenceEquals(answer, source), "implicit-reference-compatible");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
