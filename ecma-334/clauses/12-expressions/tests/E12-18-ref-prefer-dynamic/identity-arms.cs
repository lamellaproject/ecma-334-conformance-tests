/*
Rules: E12-18-ref-prefer-dynamic; E12-18-ref-result-type; E12-18-ref-result-reference; E12-18-ref-result-writeability
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: takeLeft ? ref left : ref right
Into: takeLeft ? ref left : ref left
*/
using System;
public class Receiver { public int Read() { return 43; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool takeLeft = true;
        object left = new Receiver();
        dynamic right = new Receiver();
        ref var result = ref (takeLeft ? ref left : ref right);
        Check(result.Read() == 43, "ref-inference-prefers-runtime-binding");
        object replacement = new Receiver();
        result = replacement;
        Check(object.ReferenceEquals(left, replacement), "dynamic-reference-writes-object-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
