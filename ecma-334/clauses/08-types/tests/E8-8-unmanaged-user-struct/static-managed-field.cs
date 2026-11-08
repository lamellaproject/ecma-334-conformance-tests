/*
Rules: E8-8-unmanaged-user-struct
Authority: ECMA-334 7th ed 8.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: pointer->Value == 29
Into: pointer->Value == 30
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Cell { public int Value; public static object Tag; }
    static unsafe int Main()
    {
        Cell.Tag = new object();
        Cell value = new Cell();
        value.Value = 29;
        Cell* pointer = &value;
        Check(pointer->Value == 29, "static-reference-field-excluded");
        Check(Cell.Tag != null, "static-field-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
