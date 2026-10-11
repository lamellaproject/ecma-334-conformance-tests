/*
Rules: E15-7-3-grammar-accessor-declarations-form-2
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: set { slot = value; }
Into: set { slot = value + 1; }
*/
using System;
class Box { int slot; public int Item { set { slot = value; } get { return slot; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Box box = new Box(); box.Item = 25; Check(box.Item == 25, "set-before-get-declaration"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
