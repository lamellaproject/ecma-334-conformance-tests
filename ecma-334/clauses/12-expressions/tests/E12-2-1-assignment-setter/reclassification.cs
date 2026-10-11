/*
Rules: E12-2-1-assignment-setter; E12-2-1-otherwise-getter; E12-2-1-access-reclassification; E12-2-2-value-substitution
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: box.Value = 11;
Into: box.raw = 11;
*/
using System;
class Box
{
    public int raw, gets, sets;
    public int Value { get { gets++; return raw; } set { sets++; raw = value; } }
    public int this[int index] { get { gets++; return raw + index; } set { sets++; raw = value - index; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        box.Value = 11;
        Check(box.sets == 1 && box.gets == 0, "assignment-selects-setter");
        int first = box.Value;
        box[3] = 21;
        int second = box[3];
        Check(first == 11 && second == 21, "access-values-substituted");
        Check(box.sets == 2 && box.gets == 2, "indexer-context-accessors");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
