/*
Rules: E15-10-2-increment-return-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E15-10-2-increment-return-type/nullable-parameter-nonnullable-result.cs.part
Mutate: Rotor operator ++
Into: Rotor? operator ++
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
    struct Rotor
    {
        public static Rotor operator ++(Rotor? item) { return new Rotor(); }
    }
    static int Main()
    {
        Rotor? value = new Rotor();
        Check(value.HasValue, "nullable-return-repair");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
