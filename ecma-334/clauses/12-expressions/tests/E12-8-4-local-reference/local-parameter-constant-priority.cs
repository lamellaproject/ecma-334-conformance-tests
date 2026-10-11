/*
Rules: E12-8-4-local-reference; E12-8-4-absent-type-arity; E12-8-1-simple-name-form
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static int Local() { int Value = 3; return Value; }
Into: static int Local() { int Value = 3; return Program.Value; }
*/
using System;
class Program
{
    static int checks, failures;
    static int Value = 8;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Local() { int Value = 3; return Value; }
    static int Parameter(int Value) { return Value; }
    static int Constant() { const int Value = 5; return Value; }
    static void Main()
    {
        Check(Local() == 3, "local-name-precedes-member");
        Check(Parameter(4) == 4, "parameter-name-precedes-member");
        Check(Constant() == 5, "local-constant-name-precedes-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
