/*
Rules: E15-5-4-volatile-char
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile char Code;
Into: public volatile char Other;
*/
using System;
class Holder { public volatile char Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = '\u01A7';
        Check(value.Code == '\u01A7', "volatile-char-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
