/*
Rules: E13-14-using-acquisition-before-usage; E13-14-form-using; E13-14-form-using-declaration-acquisition; E13-14-resource-contract; E13-14-resource-dispose-method; E13-14-resource-dispose-call-permitted; E13-14-other-resource-disposal; E13-14-alternative-using-implementation
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (Resource resource = new Resource())
Into: if (new Resource() != null)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace, disposed;
    class Resource : IDisposable
    {
        public Resource() { trace = trace * 10 + 1; }
        public void Dispose() { disposed++; trace = trace * 10 + 3; }
    }
    static void Main()
    {
        using (Resource resource = new Resource()) { trace = trace * 10 + 2; }
        Check(trace == 123 && disposed == 1, "acquire-use-interface-dispose");
        Resource direct = new Resource();
        direct.Dispose();
        Check(disposed == 2, "resource-dispose-can-be-called-directly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
