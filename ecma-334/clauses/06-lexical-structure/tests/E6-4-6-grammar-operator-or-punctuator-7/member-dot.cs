/*
Rules: E6-4-6-grammar-operator-or-punctuator-7
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Tile.Value
Into: TileValue
*/
using System;
class Tile { public static int Value = 37; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int TileValue = 41;
        int actual = Tile.Value;
        Check(actual == 37, "member-dot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
