/*
Rules: E9-7-2-4-reference-receiver-field-context
Authority: ECMA-334 7th ed 9.7.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return ref holder.Value;
Into: return ref backup;
*/
using System;
class Holder { public int Value = 84; }
class Program
{
    static int checks, failures, backup = 5;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Select()
    {
        Holder holder = new Holder();
        return ref holder.Value;
    }
    static void Main()
    {
        ref int alias = ref Select();
        Check(alias == 84, "local-reference-receiver-field-has-caller-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
