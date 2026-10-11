/*
Rules: E9-2-9-local-lifetime-minimum; E9-2-9-local-lifetime-storage; E9-2-9-scope-suspension
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: ref int alias = ref cell;
Into: int alias = cell;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Edit(ref int cell) { cell += 7; }
    static void Main()
    {
        int cell = 21;
        ref int alias = ref cell;
        { alias += 3; }
        Check(cell == 24, "outer-storage-survives-nested-block");
        Edit(ref alias);
        Check(cell == 31, "outer-storage-survives-function-call");
        alias += 2;
        Check(cell == 33, "storage-reserved-to-end-of-scope");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
