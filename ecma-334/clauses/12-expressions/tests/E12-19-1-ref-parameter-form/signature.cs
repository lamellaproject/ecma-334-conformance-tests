/*
Rules: E12-19-1-ref-parameter-form; E12-19-1-explicit-parameter-form; E12-19-3-declared-parameter-access
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (ref int value) =>
Into: (int value) =>
*/
using System;
delegate int Update(ref int value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Update function = (ref int value) => { value += 7; return value; };
        int item = 11;
        Check(function(ref item) == 18, "ref-parameter-read-write-return");
        Check(item == 18, "ref-parameter-aliases-caller");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
