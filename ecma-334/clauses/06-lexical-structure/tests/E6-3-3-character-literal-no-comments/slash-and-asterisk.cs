/*
Rules: E6-3-3-character-literal-no-comments
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: '/'
Into: '-'
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        char slash = '/'; char star = '*';
        Check((int)slash == 47, "slash-character");
        Check((int)star == 42, "asterisk-character");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
