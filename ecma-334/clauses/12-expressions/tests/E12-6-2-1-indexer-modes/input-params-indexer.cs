/*
Rules: E12-6-2-1-indexer-modes
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: box[in number]
Into: box[in other]
*/
using System;
class Box
{
    public int this[in int number] { get { return number + 10; } }
    public int this[int first, params int[] rest] { get { return first * 100 + rest[0] * 10 + rest[1]; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); int number = 3, other = 7; int result = box[in number];
        Check(result == 13, "input-indexer-parameter");
        Check(box[3, 5, 7] == 357, "value-and-parameter-array-indexer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
