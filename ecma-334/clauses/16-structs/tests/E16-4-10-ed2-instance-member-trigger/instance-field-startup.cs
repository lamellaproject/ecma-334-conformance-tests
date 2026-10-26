/*
Rules: E16-4-10-ed2-instance-member-trigger
Authority: ECMA-334 2nd ed 18.3.10
Version: ISO-1
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/ed2-instance-field-startup.cs.part
Mutate: int observed = sample.Position;
Into: int observed = 0;
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
class FieldStartup
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
        int observed = sample.Position;
        Check(StartupMeter.Count == 1, "instance-field-startup");
        Check(observed == 0, "instance-field-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
