/*
Rules: E8-3-9-bool-values; E8-3-9-bool-true-representation; E8-3-9-bool-distinct-representation
Authority: ECMA-334 7th ed 8.3.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: bool value = true;
Into: bool value = false;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe bool HasNonzeroBits(bool input) { byte* bytes = (byte*)&input; for (int i = 0; i < sizeof(bool); i++) if (bytes[i] != 0) return true; return false; }
    static void Main()
    {
        bool value = true; bool empty = false;
        Check(value && !empty && HasNonzeroBits(value) && !HasNonzeroBits(empty), "true-bits-differ-from-zero-false");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
