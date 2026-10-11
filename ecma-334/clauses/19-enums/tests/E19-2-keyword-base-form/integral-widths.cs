/*
Rules: E19-2-keyword-base-form; E19-2-underlying-type; E19-2-explicit-underlying-type
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: enum UnsignedByte : byte
Into: enum UnsignedByte : sbyte
*/
using System;
enum SignedByte : sbyte { Low = -128, High = 127 }
enum UnsignedByte : byte { Low = 0, High = 255 }
enum SignedShort : short { Low = -32768, High = 32767 }
enum UnsignedShort : ushort { Low = 0, High = 65535 }
enum SignedInt : int { Low = -2147483648, High = 2147483647 }
enum UnsignedInt : uint { Low = 0, High = 4294967295U }
enum SignedLong : long { Low = -9223372036854775808L, High = 9223372036854775807L }
enum UnsignedLong : ulong { Low = 0, High = 18446744073709551615UL }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((sbyte)SignedByte.Low == -128 && (sbyte)SignedByte.High == 127, "sbyte-base");
        Check((byte)UnsignedByte.Low == 0 && (byte)UnsignedByte.High == 255, "byte-base");
        Check((short)SignedShort.Low == -32768 && (short)SignedShort.High == 32767, "short-base");
        Check((ushort)UnsignedShort.Low == 0 && (ushort)UnsignedShort.High == 65535, "ushort-base");
        Check((int)SignedInt.Low == -2147483648 && (int)SignedInt.High == 2147483647, "int-base");
        Check((uint)UnsignedInt.Low == 0 && (uint)UnsignedInt.High == 4294967295U, "uint-base");
        Check((long)SignedLong.Low == -9223372036854775808L && (long)SignedLong.High == 9223372036854775807L, "long-base");
        Check((ulong)UnsignedLong.Low == 0 && (ulong)UnsignedLong.High == 18446744073709551615UL, "ulong-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
