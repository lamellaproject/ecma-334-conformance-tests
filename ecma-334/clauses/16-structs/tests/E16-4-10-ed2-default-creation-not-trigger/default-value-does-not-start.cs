/*
Rules: E16-4-10-ed2-default-creation-not-trigger
Authority: ECMA-334 2nd ed 18.3.10
Version: ISO-1
Expected: run
Stdout: OK 2
Mutate: Rotor sample = new Rotor();
Into: Rotor sample = new Rotor(0);
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
class DefaultStartup
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
        Check(StartupMeter.Count == 0, "default-value-no-startup");
        object packed = sample;
        Check(StartupMeter.Count == 0, "default-value-box");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
