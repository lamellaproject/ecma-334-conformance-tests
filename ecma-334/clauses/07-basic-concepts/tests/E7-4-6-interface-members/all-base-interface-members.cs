/*
Rules: E7-4-6-interface-members
Authority: ECMA-334 7th ed 7.4.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: interface Combined : First, Second
Into: interface Combined : First
*/
using System;
interface First { int Left(); }
interface Second { int Right(); }
interface Combined : First, Second { int Own(); }
class Holder : Combined
{
    public int Left() { return 17; }
    public int Right() { return 23; }
    public int Own() { return 29; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Combined value = new Holder();
        Check(value.Left() == 17, "first-base-interface-member");
        Check(value.Right() == 23, "second-base-interface-member");
        Check(value.Own() == 29, "declared-interface-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
