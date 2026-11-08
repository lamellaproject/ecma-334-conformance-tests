/*
Rules: E13-14-other-resource-disposal; E13-14-other-resource-disposal-conversion
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using (Lease? present = new Lease(17))
Into: if (true)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int disposed;
    struct Lease : IDisposable
    {
        int marker;
        public Lease(int value) { marker = value; }
        public void Dispose() { disposed += marker; }
    }
    static int Main()
    {
        Action visit = () =>
        {
            using (Lease? present = new Lease(17)) { }
            using (Lease? absent = null) { }
        };
        visit();
        Check(disposed == 17, "lambda-nullable-resource-disposes");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
