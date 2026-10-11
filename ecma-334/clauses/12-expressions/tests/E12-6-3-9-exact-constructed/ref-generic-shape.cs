/*
Rules: E12-6-3-9-exact-constructed
Authority: ECMA-334 7th ed 12.6.3.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Read(ref box)
Into: Read(ref scalar)
*/
using System;
class Box<T> { public T value; }
class Program
{
    static int checks, failures;
    static T Read<T>(ref Box<T> box) { return box.value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box<long> box = new Box<long> { value = 23L };
        long scalar = 23L;
        long result = Read(ref box);
        Check(result == 23L, "exact-constructed-inference-matches-generic-definition");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
