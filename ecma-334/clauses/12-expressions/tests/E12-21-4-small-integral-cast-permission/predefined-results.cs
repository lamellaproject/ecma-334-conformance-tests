/*
Rules: E12-21-4-small-integral-cast-permission; E12-21-4-explicit-result-assignment
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: unsignedByte += (byte)9
Into: unsignedByte += (byte)8
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unchecked
        {
            sbyte signedByte = -120; signedByte += (sbyte)(-10); Check(signedByte == 126, "sbyte-result-cast");
            byte unsignedByte = 250; unsignedByte += (byte)9; Check(unsignedByte == 3, "byte-result-cast");
            short signedShort = 32000; signedShort += (short)1000; Check(signedShort == -32536, "short-result-cast");
            ushort unsignedShort = 65530; unsignedShort += (ushort)11; Check(unsignedShort == 5, "ushort-result-cast");
            char character = (char)65535; character += (char)2; Check(character == (char)1, "char-result-cast");
            byte shifted = 200; int amount = 1; shifted >>= amount; Check(shifted == 100, "shift-exempts-right-conversion");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
