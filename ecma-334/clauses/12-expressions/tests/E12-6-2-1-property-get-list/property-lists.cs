/*
Rules: E12-6-2-1-property-get-list; E12-6-2-1-property-set-list; E12-6-2-2-property-get-no-arguments; E12-6-2-2-property-value-correspondence
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: box.Value = 23;
Into: box.Value = 29;
*/
using System;
class Box
{
    public int stored, gets, sets;
    public int Value { get { gets++; return stored; } set { sets++; stored = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); box.Value = 23; int value = box.Value;
        Check(value == 23, "property-implicit-value-parameter");
        Check(box.gets == 1 && box.sets == 1, "empty-getter-single-setter-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
