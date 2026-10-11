/*
Rules: E12-12-13-listed-conversions; E12-12-13-conversion-purpose; E12-12-13-failed-conversion-null
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: value as int?
Into: null as int?
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 3; int? wrapped = value as int?;
        Check(wrapped.HasValue && wrapped.Value == 3, "wrapping-conversion");
        int? nullable = 4; int? same = nullable as int?; Check(same == 4, "nullable-identity");
        int? wider = nullable as long? as int?;
        Check(!wider.HasValue, "explicit-nullable-conversion-still-requires-runtime-type-match");
        object boxed = 5; int? unboxed = boxed as int?; Check(unboxed == 5, "compatible-boxed-value");
        boxed = 5L; unboxed = boxed as int?; Check(!unboxed.HasValue, "unrelated-boxed-numeric-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
