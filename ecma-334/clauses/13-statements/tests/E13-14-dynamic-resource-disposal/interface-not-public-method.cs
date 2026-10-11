/*
Rules: E13-14-dynamic-resource-disposal; E13-14-dynamic-declaration-acquisition-permitted
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using (dynamic resource = value)
Into: if (value != null)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int interfaceCalls, publicCalls;
    class Resource : IDisposable
    {
        void IDisposable.Dispose() { interfaceCalls++; }
        public void Dispose() { publicCalls++; }
    }
    static void Main()
    {
        dynamic value = new Resource();
        using (dynamic resource = value) { }
        Check(interfaceCalls == 1 && publicCalls == 0, "dynamic-acquires-disposable-interface-for-disposal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
