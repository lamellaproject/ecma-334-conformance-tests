/*
Rules: E15-2-5-unmanaged-name-precedence; E15-2-5-unmanaged-contextual
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class unmanaged
Into: class Renamed
*/
using System;
class unmanaged { public int Number = 113; }
class Program
{
    static int Read<T>(T value) where T : unmanaged { return value.Number; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(new unmanaged()) == 113, "unmanaged-name-lookup-takes-precedence");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
