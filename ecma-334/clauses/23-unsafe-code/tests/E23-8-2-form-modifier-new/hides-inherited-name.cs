/*
Rules: E23-8-2-form-modifier-new
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public new fixed int ToString[2];
Into: public new fixed int Other[2];
*/
using System;
unsafe struct Item { public new fixed int ToString[2]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        value.ToString[1] = 61;
        Check(value.ToString[1] == 61, "new-buffer-hides-inherited-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
