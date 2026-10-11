/*
Rules: E15-4-acyclic-constant-dependency; E15-4-constant-evaluation-order
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public const int Right = Seed.Bit << 2;
Into: public const int Right = Flags.Both << 2;
*/
using System;
class Flags { public const int Both = Branch.Left | Branch.Right; }
class Branch
{
    public const int Left = Seed.Bit << 1;
    public const int Right = Seed.Bit << 2;
}
class Seed { public const int Bit = 1 << 4; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Flags.Both == 96, "diamond-combined-value");
        Check(Branch.Left == 32, "diamond-left-value");
        Check(Branch.Right == 64, "diamond-right-value");
        Check(Seed.Bit == 16, "diamond-origin-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
