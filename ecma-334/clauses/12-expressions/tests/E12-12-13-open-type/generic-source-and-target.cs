/*
Rules: E12-12-13-open-type
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: return value as T;
Into: return null as T;
*/
using System;
class Target { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Target FromSource<T>(T value) { return value as Target; }
    static T ToTarget<T>(int value) where T : class { return value as T; }
    static void Main()
    {
        Target original = new Target();
        Check((object)FromSource(original) == original, "open-source-compatible-runtime-type");
        Check(FromSource(3) == null, "open-source-incompatible-runtime-type");
        Check((int)ToTarget<object>(7) == 7, "open-reference-target-boxes-value");
        Check(ToTarget<string>(7) == null, "open-reference-target-no-runtime-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
