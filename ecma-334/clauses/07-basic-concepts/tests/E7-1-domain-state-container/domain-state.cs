/*
Rules: E7-1-domain-state-container; E7-1-domain-creation; E7-1-domain-type-boundary; E7-1-domain-statics; E7-1-domain-static-constructor-once; E7-1-domain-lifecycle-policy
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 5
Fixture: {"target_requires":["framework-runtime"]}
Mutate: AppDomain second = AppDomain.CreateDomain("branch-two");
Into: AppDomain second = first;
*/
using System;
public class DomainState : MarshalByRefObject
{
    static int value, initializations;
    static DomainState() { initializations++; }
    public void Set(int number) { value = number; }
    public int Read() { return value; }
    public int InitializationCount() { return initializations; }
    public string DomainName() { return AppDomain.CurrentDomain.FriendlyName; }
    public bool ContainsOwnAssembly()
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            if (assembly == typeof(DomainState).Assembly) return true;
        return false;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        AppDomain first = AppDomain.CreateDomain("branch-one");
        AppDomain second = AppDomain.CreateDomain("branch-two");
        try
        {
            string assembly = typeof(DomainState).Assembly.FullName;
            string type = typeof(DomainState).FullName;
            var left = (DomainState)first.CreateInstanceAndUnwrap(assembly, type);
            var right = (DomainState)second.CreateInstanceAndUnwrap(assembly, type);
            var local = new DomainState();
            left.Set(17);
            Check(left.Read() == 17 && right.Read() == 0 && local.Read() == 0, "domain-local-statics");
            right.Set(29);
            Check(left.Read() == 17 && right.Read() == 29, "application-state-containers");
            Check(left.DomainName() == "branch-one" && right.DomainName() == "branch-two", "execution-in-created-domains");
            var another = (DomainState)first.CreateInstanceAndUnwrap(assembly, type);
            Check(left.InitializationCount() == 1 && another.InitializationCount() == 1 && right.InitializationCount() == 1, "static-constructor-once-in-each-domain");
            Check(left.ContainsOwnAssembly() && right.ContainsOwnAssembly(), "domain-contains-application-types");
        }
        finally
        {
            if (second != first) AppDomain.Unload(second);
            AppDomain.Unload(first);
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
