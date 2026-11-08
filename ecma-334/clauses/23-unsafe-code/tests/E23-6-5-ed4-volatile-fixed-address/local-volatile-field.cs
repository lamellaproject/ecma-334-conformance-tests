/*
Rules: E23-6-5-ed4-volatile-fixed-address
Authority: ECMA-334 4th ed 27.5.4
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E23-6-5-ed4-volatile-fixed-address/local-volatile-field.cs.part
Mutate: int* address = &value.Chosen;
Into: int* address = &value.Other;
*/
// ECMA-334 4th ed 27.5.4, p. 434 (PDF p. 456).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Cell
    {
        public volatile int Chosen;
        public int Other;
    }
    static unsafe int Read()
    {
        Cell value = new Cell();
        value.Chosen = 41;
        value.Other = 43;
        int* address = &value.Chosen;
        return *address;
    }
    static int Main()
    {
        Check(Read() == 41, "volatile-fixed-field-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
