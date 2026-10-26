/*
Rules: E16-4-10-ed2-instance-member-trigger
Authority: ECMA-334 2nd ed 18.3.10
Version: ISO-1
Expected: run
Stdout: OK 2
Mutate: int observed = sample.Signal();
Into: int observed = 37;
*/
using System;
class StartupMeter { public static int Count; }
struct Rotor
{
    public int Position;
    static Rotor() { StartupMeter.Count++; }
    public Rotor(int position) { Position = position; }
    public int Signal() { return 37; }
}
class MethodStartup
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    static int Main()
    {
        Rotor sample = new Rotor();
        int observed = sample.Signal();
        Check(StartupMeter.Count == 1, "instance-method-startup");
        Check(observed == 37, "instance-method-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
