/*
Rules: E18-4-1-partial-member-union
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial interface IReading { int Second(int input); }
Into: interface IExtra { int Second(int input); }
*/
using System;
partial interface IReading { int First(int input); }
partial interface IReading { int Second(int input); }
class Reading : IReading
{
    int seed;
    public Reading(int seed) { this.seed = seed; }
    public int First(int input) { return seed + input; }
    public int Second(int input) { return seed - input; }
}
class Program
{
    static int checks, failures;
    static int seed = 17, input = 6;
    static void Check(bool good, string name)
    {
        checks++;
        if (!good) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        IReading value = new Reading(seed);
        Check(value.First(input) == 23, "member-from-first-part");
        Check(value.Second(input) == 11, "member-from-second-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
