/*
Rules: E6-4-6-grammar-operator-or-punctuator-27; E6-4-6-grammar-operator-or-punctuator-28
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int postUp = value++;
Into: int postUp = ++value;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 7;
        int preUp = ++value;
        Check(preUp == 8 && value == 8, "prefix-plus-plus");
        int postUp = value++;
        Check(postUp == 8 && value == 9, "postfix-plus-plus");
        int preDown = --value;
        Check(preDown == 8 && value == 8, "prefix-minus-minus");
        int postDown = value--;
        Check(postDown == 8 && value == 7, "postfix-minus-minus");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
