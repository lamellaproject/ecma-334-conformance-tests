/*
Rules: E12-15-right-associative
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Left() ?? Middle() ?? Right()
Into: (Left() ?? Middle()) ?? Right()
*/
using System;
class C { public int N; public C(int n) { N = n; } }
class B
{
    public int N; public B(int n) { N = n; }
    public static implicit operator C(B b) { Program.Trace += "BC"; return new C(b.N + 200); }
}
class A
{
    public static implicit operator B(A a) { Program.Trace += "AB"; return new B(201); }
    public static implicit operator C(A a) { Program.Trace += "AC"; return new C(101); }
}
class Program
{
    public static string Trace = "";
    static A Left() { Trace += "L"; return new A(); }
    static B Middle() { Trace += "M"; return new B(3); }
    static C Right() { Trace += "R"; return new C(5); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = Left() ?? Middle() ?? Right(); Check(value.N == 101 && Trace == "LAC", "right-grouping-selects-direct-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
