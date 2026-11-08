/*
Rules: E12-12-13-ed4-nullable-as
Authority: ECMA-334 4th ed 14.9.11
Version: ISO-2
Expected: run
Stdout: OK 6
Version-Witness: version-witnesses/E12-12-13-ed4-nullable-as/nullable-conversion-paths.cs.part
Mutate: int? wrapped = value as int?;
Into: int? wrapped = (value + 1) as int?;
*/
// ECMA-334 4th ed 14.9.11, p. 212 (PDF p. 234).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int value = 23;
        int? present = 29;
        int? wrapped = value as int?;
        int? identity = present as int?;
        int? fromNull = null as int?;
        object boxed = 41;
        object wrong = "spruce";
        object absent = null;
        int? unboxed = boxed as int?;
        int? mismatch = wrong as int?;
        int? nullBox = absent as int?;
        Check(wrapped.HasValue && wrapped.Value == 23, "as-wrapping");
        Check(identity.HasValue && identity.Value == 29, "as-identity");
        Check(!fromNull.HasValue, "as-null-type");
        Check(unboxed.HasValue && unboxed.Value == 41, "as-underlying-box");
        Check(!mismatch.HasValue, "as-incompatible-box");
        Check(!nullBox.HasValue, "as-null-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
