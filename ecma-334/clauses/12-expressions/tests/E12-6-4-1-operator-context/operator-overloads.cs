/*
Rules: E12-6-4-1-operator-context
Authority: ECMA-334 7th ed 12.6.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: box + 7
Into: box + 7L
*/
using System;
struct Box
{
    public static int operator +(Box x, int y) { return 1; }
    public static int operator +(Box x, long y) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        Check((box + 7) == 1, "user-operator-better-target-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
