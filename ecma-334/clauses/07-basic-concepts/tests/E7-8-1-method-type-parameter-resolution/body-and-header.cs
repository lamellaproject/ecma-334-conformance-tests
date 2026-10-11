/*
Rules: E7-8-1-method-type-parameter-resolution
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Echo<Token>(Token value)
Into: Echo<Other>(Token value)
*/
using System;
class Token { }
class NoteAttribute : Attribute { public NoteAttribute(Type type) { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    [Note(typeof(Token))]
    static Token Echo<Token>(Token value) { Token copy = value; return copy; }
    static void Main()
    {
        Check(Echo<int>(47) == 47, "method-type-parameter-body-header-attribute-excluded");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
