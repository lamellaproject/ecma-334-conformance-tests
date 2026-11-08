/*
Rules: E10-5-4-ed3-both-nullable-lifted-candidates
Authority: ECMA-334 3rd ed 13.4.3
Version: ISO-2
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/E10-5-4-ed3-both-nullable-lifted-candidates/mixed-and-nullable-endpoints.cs.part
Mutate: return new Crop(source.Number + 4);
Into: return new Crop(source.Number);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Seed
    {
        public int Number;
        public static int Calls;
        public Seed(int number) { Number = number; }
        public static implicit operator Crop(Seed source) { Calls++; return new Crop(source.Number + 4); }
    }
    struct Crop
    {
        public int Number;
        public Crop(int number) { Number = number; }
    }
    static int Main()
    {
        Seed source = new Seed(27);
        Crop? first = source;
        Check(first.HasValue && first.Value.Number == 31 && Seed.Calls == 1, "nonnullable-to-nullable-implicit");
        Seed? filled = source, empty = null;
        Crop? second = filled;
        Check(second.HasValue && second.Value.Number == 31 && Seed.Calls == 2, "lifted-value-implicit");
        Crop? absent = empty;
        Check(!absent.HasValue && Seed.Calls == 2, "lifted-null-implicit");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
