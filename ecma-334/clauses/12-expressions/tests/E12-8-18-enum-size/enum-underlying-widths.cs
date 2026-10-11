/*
Rules: E12-8-18-enum-size; E12-8-18-enum-constant
Authority: ECMA-334 7th ed 12.8.18
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: enum I8 : sbyte
Into: enum I8 : short
*/
using System;
enum I8 : sbyte { Zero }
enum U8 : byte { Zero }
enum I16 : short { Zero }
enum U16 : ushort { Zero }
enum I32 : int { Zero }
enum U32 : uint { Zero }
enum I64 : long { Zero }
enum U64 : ulong { Zero }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        const int i8 = sizeof(I8), u8 = sizeof(U8), i16 = sizeof(I16), u16 = sizeof(U16);
        const int i32 = sizeof(I32), u32 = sizeof(U32), i64 = sizeof(I64), u64 = sizeof(U64);
        Check(i8 == 1, "sizeof-sbyte-enum-constant");
        Check(u8 == 1, "sizeof-byte-enum-constant");
        Check(i16 == 2, "sizeof-short-enum-constant");
        Check(u16 == 2, "sizeof-ushort-enum-constant");
        Check(i32 == 4, "sizeof-int-enum-constant");
        Check(u32 == 4, "sizeof-uint-enum-constant");
        Check(i64 == 8, "sizeof-long-enum-constant");
        Check(u64 == 8, "sizeof-ulong-enum-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
