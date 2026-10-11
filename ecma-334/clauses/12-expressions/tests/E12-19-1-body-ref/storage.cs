/*
Rules: E12-19-1-body-ref
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: () => ref storage
Into: () => ref other
*/
using System;
delegate ref int Cell();
class Program
{
    static int storage = 31, other = 37;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell function = () => ref storage;
        ref int result = ref function();
        Check(result == 31, "ref-body-returns-reference");
        result = 41;
        Check(storage == 41 && other == 37, "returned-reference-writes-body-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
