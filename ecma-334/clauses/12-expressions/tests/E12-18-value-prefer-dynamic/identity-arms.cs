/*
Rules: E12-18-value-prefer-dynamic; E12-18-value-identity-common-type
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: takeLeft ? left : right
Into: takeLeft ? left : left
*/
using System;
public class Receiver { public int Read() { return 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool takeLeft = true;
        object left = new Receiver();
        dynamic right = new Receiver();
        var result = takeLeft ? left : right;
        Check(result.Read() == 31, "dynamic-result-allows-runtime-member-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
