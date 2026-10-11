/*
Rules: E9-2-9-reentered-local-instance; E9-2-9-reentered-local-initializer
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: int cell = serial++;
Into: int cell = serial;
*/
using System;
class Program
{
    static int checks, failures, serial = 10;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Visit(int depth)
    {
        int cell = serial++;
        if (depth > 0)
        {
            int inner = Visit(depth - 1);
            Check(inner == cell + 1, "recursive-storage-distinct");
        }
        Check(cell == 12 - depth, "local-persists-across-recursive-call");
        return cell;
    }
    static void Main()
    {
        Check(Visit(2) == 10 && serial == 13, "initializer-per-recursive-entry");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
