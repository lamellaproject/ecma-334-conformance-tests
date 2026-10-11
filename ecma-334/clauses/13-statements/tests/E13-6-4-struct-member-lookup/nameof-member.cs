/*
Rules: E13-6-4-struct-member-lookup
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(Value)
Into: nameof(Read)
*/
using System;
struct Token { int Value; public string Read() { string Local() => nameof(Value); return Local(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Token item = default(Token);
        Check(item.Read() == "Value", "lookup-without-access-to-struct-this");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
