/*
Rules: E9-7-1-reference-return-definition; E9-7-1-reference-return-referent
Authority: ECMA-334 7th ed 9.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return ref cells[1];
Into: return ref cells[0];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Select(int[] cells) { return ref cells[1]; }
    static void Main()
    {
        int[] cells = { 29, 31 };
        ref int alias = ref Select(cells);
        cells[1] = 37;
        Check(alias == 37, "return-denotes-element-location");
        alias = 41;
        Check(cells[0] == 29 && cells[1] == 41, "returned-referent-can-be-written");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
