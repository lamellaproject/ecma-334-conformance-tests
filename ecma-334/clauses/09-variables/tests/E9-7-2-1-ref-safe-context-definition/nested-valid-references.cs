/*
Rules: E9-7-2-1-ref-safe-context-definition; E9-7-2-1-ref-safe-context-categories; E9-7-2-1-declaration-block-context; E9-7-2-1-value-parameter-context; E9-7-2-1-context-nesting-order; E9-7-2-1-nested-block-distinct-context
Authority: ECMA-334 7th ed 9.7.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ref int alias = ref local;
Into: int alias = local;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Probe(int parameter)
    {
        ref int memberAlias = ref parameter;
        int local = 16;
        {
            ref int alias = ref local;
            alias = 20;
            memberAlias = 24;
        }
        Check(local == 20, "local-reference-valid-through-nested-block");
        Check(parameter == 24, "function-member-reference-valid-in-local-block");
    }
    static void Main()
    {
        Probe(7);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
