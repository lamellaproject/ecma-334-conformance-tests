/*
Rules: E12-12-12-1-null-value-false
Authority: ECMA-334 7th ed 12.12.12.1
Version: 7.3
Expected: run
Stdout: OK 4
Fixture: {"arguments":["empty"]}
Mutate: bool references = source is object[];
Into: bool references = true;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Match(object source)
    {
        bool references = source is object[];
        Check(!references, "null-is-reference-vector-false");
        Check(!(source is int[]), "null-is-value-vector-false");
        Check(!(source is int[][]), "null-is-jagged-array-false");
        Check(!(source is int[,]), "null-is-rectangular-array-false");
    }
    static void Main(string[] arguments)
    {
        object source = arguments.Length == 1 ? null : new object[1];
        Match(source);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
