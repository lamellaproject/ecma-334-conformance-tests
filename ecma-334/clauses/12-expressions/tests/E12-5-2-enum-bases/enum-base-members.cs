/*
Rules: E12-5-2-enum-bases
Authority: ECMA-334 7th ed 12.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Flag value = Flag.Second;
Into: Flag value = Flag.First;
*/
using System;
enum Flag { First = 3, Second = 7 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Flag value = Flag.Second; Enum enumeration = value; ValueType storage = enumeration; object boxed = storage;
        Check(value.CompareTo(Flag.First) > 0, "enum-base-compare-member");
        Check(boxed.Equals(Flag.Second), "enum-value-type-object-chain");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
