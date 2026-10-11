/*
Rules: E15-7-3-protected-accessor-private
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private set
Into: protected set
*/
using System;
class Box { int slot; protected int Item { get { return slot; } private set { slot = value; } } public int Write() { Item = 34; return Item; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(new Box().Write() == 34, "protected-private-set"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
