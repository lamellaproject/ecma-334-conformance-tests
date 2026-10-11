/*
Rules: E7-3-delegate-space; E7-3-delegate-formal-parameter-names; E7-3-delegate-type-parameter-names; E7-3-type-declaration-categories
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: delegate T Project<T>(T value);
Into: delegate T Project<U>(T value);
*/
using System;
delegate T Project<T>(T value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Identity(int value) { return value; }
    static void Main()
    {
        Project<int> project = Identity;
        Check(project(23) == 23, "delegate-parameter-names-and-type-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
