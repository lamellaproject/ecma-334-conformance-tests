/*
Rules: E8-4-5-new-constraint-value-type; E8-4-5-new-constraint-struct-parameter
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : struct
Into: where T : class
*/
using System;
enum Mode { Ready = 8 }
class Gate<U> where U : new() { public static U Build() { return new U(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T Build<T>() where T : struct { return Gate<T>.Build(); }
    static void Main()
    {
        Check(Build<int>() == 0 && Build<Mode>() == (Mode)0, "value-constraint-provides-default-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
