/*
Rules: E12-6-4-5-better-exact; E12-6-4-6-exact-inferred-return
Authority: ECMA-334 7th ed 12.6.4.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: () => Read()
Into: () => { Read(); }
*/
// ECMA-334 7th ed 12.6.4.5-12.6.4.6, pp. 178-179 (PDF pp. 206-207).
using System;
delegate int ValueReader();
delegate void EffectReader();
class Program
{
    static int calls, checks, failures;
    static int Read() { calls++; return 40 + calls; }
    static int Route(ValueReader reader) { return 100 + reader(); }
    static int Route(EffectReader reader) { reader(); return -1; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int result = Route(() => Read());
        Check(result == 141, "value-return-target");
        Check(calls == 1, "selected-delegate-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
