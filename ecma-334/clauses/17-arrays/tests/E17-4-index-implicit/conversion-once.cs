/*
Rules: E17-4-index-implicit
Authority: ECMA-334 7th ed 17.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static implicit operator int(Index item)
Into: public static explicit operator int(Index item)
*/
using System;
struct Index
{
    public static int Calls;
    public static implicit operator int(Index item) { Calls++; return 1; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[2]; Index index = new Index();
        values[index] = 61;
        Check(Index.Calls == 1, "implicit-index-converted-once");
        Check(values[1] == 61, "converted-selected-element");
        Check(values[0] == 0, "converted-other-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
