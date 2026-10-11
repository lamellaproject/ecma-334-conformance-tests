/*
Rules: E13-6-2-1-ref-local-safe-context
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ref int alias = ref field;
Into: int value = field; ref int alias = ref value;
*/
using System;
class Program
{
    static int checks, failures, field = 3;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Get() { ref int alias = ref field; return ref alias; }
    static void Main()
    {
        Get() = 8;
        Check(field == 8, "ref-local-preserves-field-escape-scope");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
