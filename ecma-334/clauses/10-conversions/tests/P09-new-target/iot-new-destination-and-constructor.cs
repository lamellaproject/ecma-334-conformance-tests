/*
Rules: P09-new-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: Crate direct = new(31);
Into: Crate direct = new();
*/
using System;

// Target-typed new specification L48/L50; alpha-v13 expressions 12.8.17.2.1.
// Each destination supplies Crate, including a parameter and a return value.
class Crate
{
    public static int Calls;
    public int Marker;
    public Crate() { Calls++; Marker = -1; }
    public Crate(int marker) { Calls++; Marker = marker; }
}
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static Crate Receive(Crate value) { return value; }
    static Crate Make(int marker) { return new(marker); }
    static int Main()
    {
        Crate direct = new(31);
        Check(direct.Marker == 31, "local-destination-selects-argument-constructor");
        Check(Crate.Calls == 1, "local-construction-once");
        Crate parameter = Receive(new(47));
        Check(parameter.Marker == 47, "parameter-destination");
        Crate result = Make(53);
        Check(result.Marker == 53, "return-destination");
        Check(Crate.Calls == 3, "all-constructions-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
