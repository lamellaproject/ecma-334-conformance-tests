/*
Rules: E12-12-10-nullable-null-equality; E12-12-10-nullable-null-inequality; E12-12-10-null-equality-fallback; E12-12-10-null-inequality-fallback
Authority: ECMA-334 7th ed 12.12.10
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: empty == null
Into: value == null
*/
using System;
struct Token { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token? empty = null, value = new Token { Value = 0 };
        Check(empty == null && null == empty, "empty-equality-either-side");
        Check(!(empty != null) && !(null != empty), "empty-inequality-either-side");
        Check(!(value == null) && !(null == value), "zero-valued-struct-has-value");
        Check(value != null && null != value, "value-inequality-either-side");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
