/*
Rules: E15-7-6-virtual-nonprivate-accessors; E15-7-6-virtual-get-method-correspondence; E15-7-6-virtual-set-method-correspondence; E15-7-6-accessors-follow-method-rules
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: protected internal virtual int State
Into: protected internal int State
*/
using System;
namespace ClassesFixture
{
    public class ExternalBase
    {
        int stored;
        protected internal virtual int State { get { return stored; } set { stored = value; } }
    }
    class SameAssemblyOverride : ExternalBase
    {
        protected internal override int State { get { return base.State + 3; } set { base.State = value + 2; } }
    }
    class Program
    {
        static int checks, failures;
        static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
        static void Main()
        {
            ExternalBase item = new SameAssemblyOverride();
            item.State = 14;
            Check(item.State == 19, "virtual-get-and-set-dispatch");
            item.State = 27;
            Check(item.State == 32, "virtual-value-parameter-and-return");
            if (failures == 0) Console.WriteLine("OK " + checks);
        }
    }
}
