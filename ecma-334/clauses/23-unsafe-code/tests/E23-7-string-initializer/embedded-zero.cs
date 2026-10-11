/*
Rules: E23-7-string-initializer; E23-7-string-initializer-result; E23-7-string-null-terminated; E23-7-string-pointer-characters; E23-7-string-pointer-terminator
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: fixed (char* pointer = text)
Into: fixed (char* pointer = other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        string text = new string(new char[] { 's', '\0', 't', '!' });
        string other = new string(new char[] { 'x', '\0', 't', '!' });
        fixed (char* pointer = text)
        {
            Check(pointer[0] == 's', "string-first-character");
            Check(pointer[1] == '\0', "string-embedded-zero");
            Check(pointer[2] == 't', "string-after-embedded-zero");
            Check(pointer[3] == '!', "string-final-character");
            Check(*(pointer + text.Length) == '\0', "string-terminator");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
