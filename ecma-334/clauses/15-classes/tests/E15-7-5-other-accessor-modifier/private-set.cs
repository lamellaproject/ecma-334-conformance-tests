/*
Rules: E15-7-5-other-accessor-modifier
Authority: ECMA-334 7th ed 15.7.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private set
Into: public set
*/
using System;
interface IBox { int Item { get; } }
class Box : IBox
{
    int slot;
    public int Item { get { return slot; } private set { slot = value; } }
    public Box(int amount) { Item = amount; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { IBox box = new Box(46); Check(box.Item == 46, "interface-get-other-private-set"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
