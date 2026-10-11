/*
Rules: E16-1-simple-types
Authority: ECMA-334 7th ed 16.1
Version: 7.3
Expected: run
Stdout: OK 13
Mutate: where T : struct
Into: where T : class
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsValue<T>(T value) where T : struct { return value is ValueType; }
    static void Main()
    {
        Check(IsValue((sbyte)1), "sbyte");
        Check(IsValue((byte)1), "byte");
        Check(IsValue((short)1), "short");
        Check(IsValue((ushort)1), "ushort");
        Check(IsValue(1), "int");
        Check(IsValue(1u), "uint");
        Check(IsValue(1L), "long");
        Check(IsValue(1UL), "ulong");
        Check(IsValue('x'), "char");
        Check(IsValue(1f), "float");
        Check(IsValue(1d), "double");
        Check(IsValue(1m), "decimal");
        Check(IsValue(true), "bool");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
