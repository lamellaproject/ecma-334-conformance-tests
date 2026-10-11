/*
Rules: E12-19-6-3-shared-capture; E12-19-6-2-capture-definition
Authority: ECMA-334 7th ed 12.19.6.3
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: pair.Read = () => state;
Into: int copy = state; pair.Read = () => copy;
*/
using System;
delegate int Result();
class Pair { public Result Update; public Result Read; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Pair Make(int state)
    {
        Pair pair = new Pair();
        pair.Update = () => ++state;
        pair.Read = () => state;
        return pair;
    }
    static void Main()
    {
        Pair pair = Make(5);
        Check(pair.Read() == 5, "shared-instance-starts-at-parameter-value");
        Check(pair.Update() == 6, "first-function-updates-captured-instance");
        Check(pair.Read() == 6, "second-function-observes-same-instance");
        Check(pair.Update() == 7, "shared-instance-retains-state");
        Check(pair.Read() == 7, "second-function-observes-next-update");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
