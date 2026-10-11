/*
Rules: E15-3-9-6-containing-protected; E15-3-9-6-containing-accessibility
Authority: ECMA-334 7th ed 15.3.9.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: owner.code
Into: 0
*/
using System;
class Host
{
    protected int code;
    public Host(int value) { code = value; }
    public class Node { public int Read(Host owner) { return owner.code; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Host.Node().Read(new Host(359)) == 359, "nested-type-accesses-containing-protected-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
