/*
Rules: E23-8-ed2-struct-field-declarations
Authority: ECMA-334 2nd ed 17.4
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E23-8-ed2-struct-field-declarations/fixed-buffer-field.cs.part
Mutate: public fixed int Samples[3];
Into: public int Samples;
*/
// ECMA-334 2nd ed 17.4, p. 221 (PDF p. 237).
using System;
unsafe struct Reading
{
    public fixed int Samples[3];
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static unsafe int Main()
    {
        Check(sizeof(Reading) >= sizeof(int), "field-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
