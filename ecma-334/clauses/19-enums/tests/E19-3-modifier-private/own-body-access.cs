/*
Rules: E19-3-modifier-private
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private enum Code
Into: private private enum Code
*/
using System;
class Holder
{
    private enum Code { Mark = 10 }
    public static int Read() { return (int)Code.Mark; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Read() == 10, "private-enum-access-in-own-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
