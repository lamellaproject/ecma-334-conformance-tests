/*
Rules: E12-8-11-2-index-conversion-type
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static implicit operator uint(Unsigned value) { Program.trace += "U"; return 1; }
Into: public static implicit operator uint(Unsigned value) { Program.trace += "U"; return 0; }
*/
using System;
struct Unsigned
{
    public static implicit operator uint(Unsigned value) { Program.trace += "U"; return 1; }
    public static implicit operator long(Unsigned value) { Program.trace += "L"; return 0; }
    public static implicit operator ulong(Unsigned value) { Program.trace += "V"; return 0; }
}
struct Long
{
    public static implicit operator long(Long value) { Program.trace += "L"; return 1; }
    public static implicit operator ulong(Long value) { Program.trace += "V"; return 0; }
}
struct ULong { public static implicit operator ulong(ULong value) { Program.trace += "V"; return 1; } }
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[] { 3, 37 };
        Check(values[new Unsigned()] == 37 && trace == "U", "uint-precedes-long-and-ulong");
        trace = "";
        Check(values[new Long()] == 37 && trace == "L", "long-precedes-ulong");
        trace = "";
        Check(values[new ULong()] == 37 && trace == "V", "ulong-only-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
