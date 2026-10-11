/*
Rules: E15-9-1-external-indexer-classification; E15-9-1-grammar-indexer-modifier-form-10
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: get;
Into: get { return index; }
*/
using System;
class Grid { public extern int this[int index] { get; set; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
