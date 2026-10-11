/*
Rules: E12-23-casts; E12-23-constant-conversion; E12-23-identity; E12-23-numeric; E12-23-enum; E12-23-constant; E12-23-const-member; E12-23-enum-member; E12-23-local-constant; E12-23-constant-parentheses; E12-23-checked; E12-23-unchecked; E12-23-nameof; E12-23-constant-sizeof; E12-23-default-value; E12-23-implicit-int-range-conversion
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: run
Stdout: OK 9
Mutate: checked((byte)((Seed.Digit + Step.Value) * 2))
Into: checked((byte)((Seed.Digit + Step.Value) * 3))
*/
using System;
class Seed { public const int Digit = 6; }
struct Step { public const int Value = 3; }
enum Tone : short { Middle = 4 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const byte combined = checked((byte)((Seed.Digit + Step.Value) * 2));
        const int identity = (int)6;
        const long widened = identity;
        const Tone tone = (Tone)((int)Tone.Middle + 1);
        const ushort narrow = 60000;
        const string name = nameof(Seed.Digit);
        const int size = sizeof(int) + sizeof(char) + sizeof(byte);
        const int wrapped = unchecked(int.MaxValue + 1);
        const int zero = default(int);
        const Tone none = default(Tone);
        sbyte small = 12; byte positive = 219; short negative = -28000;
        uint unsigned = 400000000; ulong wideUnsigned = 2000000000;
        Check(combined == 18, "checked-cast-parentheses-const-members");
        Check(identity == 6 && widened == 6L, "identity-and-numeric-constant-conversions");
        Check((short)tone == 5, "enumeration-constant-conversion");
        Check(narrow == 60000, "implicit-constant-ushort-conversion");
        Check(name == "Digit", "constant-nameof");
        Check(size == 7, "constant-sizeof");
        Check(wrapped == int.MinValue, "explicit-unchecked-constant-wrap");
        Check(zero == 0 && none == (Tone)0, "constant-default-values");
        Check(small == 12 && positive == 219 && negative == -28000 && unsigned == 400000000U && wideUnsigned == 2000000000UL, "all-other-int-range-destinations");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
