/*
Rules: E20-2-generic-class-nesting
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public delegate T Read(T value);
Into: public delegate long Read(long value);
*/
using System;
class Shelf<T> { public delegate T Read(T value); }
class Program
{
    static int checks, failures;
    static int ReadValue(int value) { return value + 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Shelf<int>.Read reader = ReadValue;
        Check(reader(47) == 49, "containing-class-type-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
