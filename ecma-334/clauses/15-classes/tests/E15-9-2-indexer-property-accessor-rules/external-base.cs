/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: protected internal virtual int this[int index]
Into: protected internal int this[int index]
*/
using System;
namespace ClassesIndexerFixture
{
    public class ExternalBase
    {
        int stored;
        protected internal virtual int this[int index] { get { return stored + index; } set { stored = value - index; } }
    }
    class SameAssemblyOverride : ExternalBase
    {
        protected internal override int this[int index] { get { return base[index] + 4; } set { base[index] = value + 6; } }
    }
    class Program
    {
        static int checks, failures;
        static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
        static void Main()
        {
            ExternalBase item = new SameAssemblyOverride();
            item[3] = 20;
            Check(item[3] == 30, "same-assembly-protected-internal-indexer");
            Check(item[1] == 28, "overriding-indexer-parameter");
            if (failures == 0) Console.WriteLine("OK " + checks);
        }
    }
}
