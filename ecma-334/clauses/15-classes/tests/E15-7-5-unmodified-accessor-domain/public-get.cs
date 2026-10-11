/*
Rules: E15-7-5-unmodified-accessor-domain
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Item
Into: private int Item
*/
using System;
class Box { int slot = 27; public int Item { get { return slot; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(new Box().Item == 27, "unmodified-public-get-domain"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
