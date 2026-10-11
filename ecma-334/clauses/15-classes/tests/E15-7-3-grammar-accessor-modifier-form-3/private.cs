/*
Rules: E15-7-3-grammar-accessor-modifier-form-3; E15-7-3-public-accessor-private
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private set
Into: public set
*/
using System;
class Box
{
    int slot;
    public int Item { get { return slot; } private set { slot = value; } }
    public void Write() { Item = 41; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Box box = new Box(); box.Write(); Check(box.Item == 41, "public-private-set"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
