/*
Rules: E6-2-5-generic-relational
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Read<int> <
Into: Read<int> >
*/
using System;
delegate int Getter();
class Threshold
{
    public int Number = 25;
    public static bool operator <(Getter getter, Threshold limit) { return getter() < limit.Number; }
    public static bool operator >(Getter getter, Threshold limit) { return getter() > limit.Number; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read<T>() { return 18; }
    static void Main()
    {
        bool result = Read<int> < new Threshold();
        Check(result, "relational-token-retains-generic-method-group");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
