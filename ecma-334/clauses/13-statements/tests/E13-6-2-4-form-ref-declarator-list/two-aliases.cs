/*
Rules: E13-6-2-4-form-ref-declarator-list; E13-6-2-4-form-ref-declaration; E13-6-2-4-form-ref-declarator; E13-6-2-1-form-ref-local
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ref int left = ref a, right = ref b;
Into: int left = a, right = b;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int a = 1, b = 2;
        ref int left = ref a, right = ref b;
        left = 8;
        right = 9;
        Check(a == 8 && b == 9, "ref-declarators-alias-corresponding-variables");
        a = 12;
        Check(left == 12 && right == 9, "ref-declarators-retain-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
