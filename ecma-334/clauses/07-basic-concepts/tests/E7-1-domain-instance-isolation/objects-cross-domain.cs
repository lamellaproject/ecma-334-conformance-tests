/*
Rules: E7-1-domain-instance-isolation
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"target_requires":["framework-runtime"]}
Mutate: remote.Change(original)
Into: new Remote().Change(original)
*/
using System;
[Serializable]
public class Box { public int Number; }
public class Remote : MarshalByRefObject
{
    public Box Change(Box box) { box.Number++; return box; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        AppDomain domain = AppDomain.CreateDomain("object-container");
        try
        {
            var remote = (Remote)domain.CreateInstanceAndUnwrap(typeof(Remote).Assembly.FullName, typeof(Remote).FullName);
            var original = new Box { Number = 7 };
            Box returned = remote.Change(original);
            Check(original.Number == 7 && returned.Number == 8 && !ReferenceEquals(original, returned), "domain-transfer-did-not-share-instance");
        }
        finally { AppDomain.Unload(domain); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
