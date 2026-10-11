/*
Rules: E8-2-1-nonarray-form-parameter
Authority: ECMA-334 7th ed 8.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new T[3]
Into: new T[4]
*/
using System;
class ArrayMaker { public static int Length<T>() { T[] cells = new T[3]; return cells.Length; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(ArrayMaker.Length<int>() == 3 && ArrayMaker.Length<string>() == 3, "type-parameter-array-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
