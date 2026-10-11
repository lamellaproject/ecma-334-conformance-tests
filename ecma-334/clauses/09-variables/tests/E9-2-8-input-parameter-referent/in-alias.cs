/*
Rules: E9-2-8-input-parameter-referent; E9-2-8-input-parameter-category; E9-2-8-input-parameter-reference-variable; E9-2-8-input-parameter-lifetime-start; E9-2-8-input-parameter-initially-assigned; E9-4-2-input-parameter-assigned
Authority: ECMA-334 7th ed 9.2.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Read(in cell, ref cell);
Into: Read(cell + 0, ref cell);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Read(in int view, ref int writable)
    {
        Check(view == 13, "input-initially-readable");
        writable = 47;
        Check(view == 47, "input-refers-to-original-storage");
    }
    static void Main()
    {
        int cell = 13;
        Read(in cell, ref cell);
        Check(cell == 47, "original-storage-written");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
