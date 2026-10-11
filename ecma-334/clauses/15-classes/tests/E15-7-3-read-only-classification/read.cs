/*
Rules: E15-7-3-read-only-classification
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: get { return slot; }
Into: get { return slot + 1; }
*/
using System;
class Box { int slot = 38; public int Item { get { return slot; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(new Box().Item == 38, "getter-only-read"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
