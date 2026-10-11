/*
Rules: E12-19-1-in-parameter-form; E12-19-1-explicit-parameter-form; E12-19-3-declared-parameter-access
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (in int value) =>
Into: (ref int value) =>
*/
using System;
delegate int Read(in int value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Read function = (in int value) => value + 7;
        int item = 29;
        Check(function(in item) == 36, "in-parameter-is-available-in-body");
        Check(item == 29, "in-read-preserves-caller-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
