/*
Rules: E9-7-2-5-conditional-reference-operands; E9-7-2-5-conditional-reference-result; E9-7-2-5-assignment-reference-operands; E9-7-2-5-assignment-reference-result
Authority: ECMA-334 7th ed 9.7.2.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: selectFirst ? ref first : ref second
Into: selectFirst ? ref second : ref first
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Probe(bool selectFirst)
    {
        int first = 3, second = 7;
        ref int choice = ref (selectFirst ? ref first : ref second);
        choice = 88;
        Check(selectFirst ? first == 88 && second == 7 : first == 3 && second == 88, "conditional-ref-result-aliases-selected-storage");
    }
    static void Main()
    {
        Probe(true);
        Probe(false);
        int first = 11, second = 15;
        ref int alias = ref first;
        ref int result = ref (alias = ref second);
        result = 92;
        Check(alias == 92 && second == 92 && first == 11, "ref-assignment-result-aliases-new-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
