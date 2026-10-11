/*
Rules: E15-6-2-1-default-value-type-default
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int? value = default(int)
Into: int? value = default(int?)
*/
using System;
class Program
{
    static int? Present(int? value = default(int)) { return value; }
    static int? Absent(int? value = default(int?)) { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? first = Present();
        Check(first.HasValue && first.Value == 0, "default-int-uses-implicit-nullable-conversion");
        Check(!Absent().HasValue, "default-nullable-uses-identity-conversion");
        Check(Present(53) == 53, "supplied-nullable-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
