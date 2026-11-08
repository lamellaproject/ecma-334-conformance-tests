/*
Rules: E12-6-3-ed3-constructed-parameter-inference-failure
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-constructed-parameter-inference-failure/multiple-interfaces-with-hint.cs.part
Mutate: Read(source, hint)
Into: Read<int>(source, hint)
*/
// ECMA-334 3rd ed 25.6.4, p. 398 (PDF p. 418).
using System;
interface Stamp<T> {}
class DoubleStamp : Stamp<int>, Stamp<long> {}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static T Read<T>(Stamp<T> source, T hint) { return hint; }
    static int Main()
    {
        DoubleStamp source = new DoubleStamp();
        int hint = 47;
        int value = Read(source, hint);
        Check(value == 47, "multiple-constructed-interfaces");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
