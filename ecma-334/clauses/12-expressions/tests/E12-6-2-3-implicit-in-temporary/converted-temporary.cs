/*
Rules: E12-6-2-3-implicit-in-temporary; E12-6-2-3-implicit-in-initialization
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Observe(field + 3, Change())
Into: Observe(field, Change())
*/
using System;
class Program
{
    static int checks, failures, field = 11;
    static short narrow = 7;
    static int Change() { field = 29; return 0; }
    static int ChangeNarrow() { narrow = 31; return 0; }
    static int Observe(in int value, int unused) { return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = Observe(field + 3, Change()); int second = Observe(narrow, ChangeNarrow());
        Check(first == 14, "expression-input-temporary");
        Check(second == 7, "conversion-input-temporary");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
