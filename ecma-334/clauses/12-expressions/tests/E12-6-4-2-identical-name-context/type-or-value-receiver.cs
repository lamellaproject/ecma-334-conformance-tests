/*
Rules: E12-6-4-2-identical-name-context
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Factory.Read("x")
Into: Factory.Read(3)
*/
using System;
class Factory
{
    public static int Read(int x) { return 1; }
    public int Read(string x) { return 2; }
}
class Program
{
    Factory Factory = new Factory();
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    void Run()
    {
        Check(Factory.Read(3) == 1, "same-name-receiver-permits-static-candidate");
        Check(Factory.Read("x") == 2, "same-name-receiver-permits-instance-candidate");
    }
    static void Main()
    {
        new Program().Run();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
