/*
Rules: E12-23-casts; E12-23-constant-conversion; E12-23-identity; E12-23-numeric; E12-23-enum; E12-23-constant; E12-23-const-member; E12-23-enum-member; E12-23-local-constant; E12-23-constant-parentheses; E12-23-checked; E12-23-unchecked; E12-23-constant-sizeof; E12-23-default-value; E12-23-implicit-int-range-conversion
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: checked((byte)((Seed.First + Offset.Second) * 3))
Into: checked((byte)((Seed.First + Offset.Second) * 4))
*/
// ECMA-334 5th ed 12.20, p. 216 (PDF p. 238).
using System;
class Seed { public const int First = 7; }
struct Offset { public const int Second = 4; }
enum Signal : short { Anchor = 6 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        const byte combined = checked((byte)((Seed.First + Offset.Second) * 3));
        const int identical = (int)7;
        const long expanded = identical;
        const Signal advanced = (Signal)((int)Signal.Anchor + 2);
        const ushort bounded = 61001;
        const int width = sizeof(long) + sizeof(short) + sizeof(byte);
        const int wrapped = unchecked(int.MaxValue + 2);
        const int empty = default(int);
        const Signal zero = default(Signal);
        sbyte small = 31;
        byte positive = 220;
        short negative = -27000;
        uint unsigned = 400000001;
        ulong wide = 2000000001;
        Check(combined == 33, "constant-members-cast-parentheses");
        Check(identical == 7 && expanded == 7L, "local-identity-and-numeric-conversions");
        Check((short)advanced == 8, "enumeration-conversion");
        Check(bounded == 61001, "ushort-constant-range");
        Check(width == 11, "predefined-sizeof-values");
        Check(wrapped == -2147483647, "unchecked-constant-overflow");
        Check(empty == 0 && zero == (Signal)0, "constant-default-values");
        Check(small == 31 && positive == 220 && negative == -27000 && unsigned == 400000001U && wide == 2000000001UL, "remaining-int-range-destinations");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
