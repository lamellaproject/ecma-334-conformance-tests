/*
Rules: E23-8-4-default-initialized-array-element
Authority: ECMA-334 7th ed 23.8.4
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: Wrapper[] items = new Wrapper[2];
Into: Wrapper[] items = Filled();
*/
using System;
unsafe struct Data { public fixed ushort Values[3]; }
struct Wrapper { public Data Data; }

unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Wrapper[] Filled() { Wrapper[] values = new Wrapper[2]; values[1].Data.Values[2] = 1; return values; }
    static void Main()
    {
        Wrapper[] items = new Wrapper[2];
        for (int row = 0; row < 2; row++)
            for (int column = 0; column < 3; column++)
                Check(items[row].Data.Values[column] == 0, "nested-array-buffer-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
