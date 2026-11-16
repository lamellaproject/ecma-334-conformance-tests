/*
Rules: E10-2-4-wrap; E10-2-4-zero
Authority: ECMA-334 7th ed 10.2.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Marker? wrapped = 0UL;
Into: Marker? wrapped = null;
*/
using System;

enum Marker : byte { Mark = 7 }

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static void Main()
    {
        Marker plain = 0L;
        Marker? wrapped = 0UL;
        Marker? other = 0;
        Check((byte)plain == 0, "decimal-zero-literal");
        bool zeros = other.HasValue && (byte)other.Value == 0;
        Check(wrapped.HasValue && (byte)wrapped.Value == 0 && zeros, "zero-literal-nullable-wrap");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
