/*
Rules: E18-6-5-multiple-match-choice
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Read(T value) { return 11; } public int Read(int value) { return 13; }
Into: public int Read(T value) { return 17; } public int Read(int value) { return 17; }
*/
using System;
interface IRead<T> { int Read(T value); }
class Reader<T> : IRead<T>
{
    public int Read(T value) { return 11; } public int Read(int value) { return 13; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IRead<int> reader = new Reader<int>();
        int value = reader.Read(7);
        // Both substituted declarations match; accept either member's specified result.
        Check(value == 11 || value == 13, "any-matching-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
