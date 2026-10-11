/*
Rules: E15-7-5-modified-accessor-domain
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal get
Into: private get
*/
using System;
class Box { int slot; public int Item { internal get { return slot; } set { slot = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Box box = new Box(); box.Item = 39; Check(box.Item == 39, "internal-get-domain"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
