/*
Rules: E12-6-3-ed3-no-anonymous-method-inference
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-no-anonymous-method-inference/anonymous-parameter.cs.part
Mutate: Receive(delegate
Into: Receive<short>(delegate
*/
// ECMA-334 3rd ed 25.6.4, p. 398 (PDF p. 418).
using System;
delegate void Sink<T>(T value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Receive<T>(Sink<T> sink) { sink(default(T)); return 1; }
    static int Main()
    {
        int value = Receive(delegate(short amount) {});
        Check(value == 1, "anonymous-parameter-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
