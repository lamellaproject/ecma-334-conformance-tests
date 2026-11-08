/*
Rules: E10-5-4-operator-ambiguous
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run-or-reject
Stdout: OK 1
Version-Witness: version-witnesses/E10-5-4-operator-ambiguous/mixed-lifted-endpoints.cs.part
Mutate: Crop? converted = source;
Into: Crop? converted = new Crop(0);
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
        Crop? converted = source;
        Check(converted.HasValue && converted.Value.Number == 31 && Seed.Calls == 1, "selected-endpoints-implicit");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
