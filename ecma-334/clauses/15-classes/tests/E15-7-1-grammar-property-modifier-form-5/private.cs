/*
Rules: E15-7-1-grammar-property-modifier-form-5; E15-7-1-property-accessibility
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private Secret Token
Into: public Secret Token
*/
using System;
public class Box
{
    private class Secret { public int Code = 28; }
    private Secret Token => new Secret();
    public int Read() { return Token.Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(new Box().Read() == 28, "private-property"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
