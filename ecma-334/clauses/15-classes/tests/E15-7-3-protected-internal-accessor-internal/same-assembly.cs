/*
Rules: E15-7-3-protected-internal-accessor-internal
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal set
Into: protected set
*/
using System;
class Box { int slot; protected internal int Item { get { return slot; } internal set { slot = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Box box = new Box(); box.Item = 27; Check(box.Item == 27, "protected-internal-internal-set"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
