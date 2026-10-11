/*
Rules: E12-9-6-variable-evaluation; E12-9-6-variable-operand-conversion; E12-9-6-variable-invocation; E12-9-6-variable-result-conversion; E12-9-6-variable-store; E12-9-6-variable-result; E12-9-6-prefix-updated-value
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: ++Array()[Index()]
Into: Array()[Index()]++
*/
using System;
struct Counter
{
    public int Value;
    public static Counter operator ++(Counter c) { Program.Trace += "O"; c.Value += 4; return c; }
}
class Program
{
    public static string Trace = "";
    static Counter[] values = new Counter[2];
    static Counter[] Array() { Trace += "A"; return values; }
    static int Index() { Trace += "I"; return 1; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        values[0].Value = 80; values[1].Value = 6; Counter result = ++Array()[Index()];
        Check(Trace == "AIO", "locate-before-operator-once");
        Check(values[0].Value == 80 && values[1].Value == 10, "store-same-location");
        Check(result.Value == 10, "stored-value-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
