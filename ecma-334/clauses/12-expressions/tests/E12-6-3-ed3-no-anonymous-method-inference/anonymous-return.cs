/*
Rules: E12-6-3-ed3-no-anonymous-method-inference
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-no-anonymous-method-inference/anonymous-return.cs.part
Mutate: Read(delegate
Into: Read<short>(delegate
*/
// ECMA-334 3rd ed 25.6.4, p. 398 (PDF p. 418).
using System;
delegate T Readout<T>();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static T Read<T>(Readout<T> source) { return source(); }
    static int Main()
    {
        short value = Read(delegate { return (short)41; });
        Check(value == 41, "anonymous-return-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
