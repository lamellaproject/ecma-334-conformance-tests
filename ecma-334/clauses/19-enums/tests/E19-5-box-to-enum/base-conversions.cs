/*
Rules: E19-5-box-to-enum; E19-5-base-enum; E19-5-unbox-from-enum; E19-5-system-enum-valuetype; E19-5-valuetype-object; E19-5-system-enum-boxed-value
Authority: ECMA-334 7th ed 19.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: (Code)boxed
Into: boxed
*/
using System;
enum Code : short { Mark = 31 }
enum Other : byte { Mark = 7 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Enum boxed = Code.Mark;
        ValueType value = boxed;
        object root = value;
        Code restored = (Code)boxed;
        Check(boxed is Code, "enum-boxed-to-base");
        Check(root == (object)boxed, "reference-conversions-through-valuetype-and-object");
        Check(restored == Code.Mark, "enum-unboxed-from-base");
        boxed = Other.Mark;
        Check(boxed is Other, "base-holds-other-enum-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
