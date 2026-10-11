/*
Rules: E9-2-9-reentered-local-instance; E9-2-9-reentered-local-initializer
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: delegates[index] = () => ++cell;
Into: delegates[index] = () => ++serial;
*/
using System;
class Program
{
    static int checks, failures, serial;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next() { return ++serial * 10; }
    static void Main()
    {
        Func<int>[] delegates = new Func<int>[2];
        for (int index = 0; index < 2; index++)
        {
            int cell = Next();
            delegates[index] = () => ++cell;
        }
        Check(serial == 2, "initializer-evaluated-on-every-entry");
        Check(delegates[0]() == 11, "first-iteration-local");
        Check(delegates[1]() == 21, "second-iteration-local");
        Check(delegates[0]() == 12, "first-instance-retains-own-state");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
