/*
Rules: E20-4-parameter-variance
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static int Read(object value)
Into: static int Read(int value)
*/
using System;
delegate int ReadText(string value);
class Program
{
    static int checks, failures;
    static object saved;
    static int Read(object value) { saved = value; return 71; }
    static int Identity(string value) { saved = value; return 73; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ReadText reference = Read;
        ReadText identity = Identity;
        string word = "spruce";
        Check(reference(word) == 71, "delegate-to-method-reference-parameter");
        Check(saved == (object)word, "reference-parameter-instance");
        Check(identity(word) == 73, "identity-parameter-conversion");
        Check(saved == (object)word, "identity-parameter-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
