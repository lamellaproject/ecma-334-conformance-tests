/*
Rules: E10-2-9-ed4-nullable-underlying-targets
Authority: ECMA-334 4th ed 11.3.1
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-2-9-ed4-nullable-underlying-targets/plain-payload-own-interface.cs.part
Mutate: IComparable converted = source;
Into: object converted = source;
*/
// ECMA-334 4th ed 11.3.1, p. 114 (PDF p. 136).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Payload
    {
        public int Value;
        public Payload(int value) { Value = value; }
    }
    static int Main()
    {
        Payload? source = new Payload(23);
        IComparable converted = source;
        Check(converted != null && ((Payload)(object)converted).Value == 23, "underlying-box-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
