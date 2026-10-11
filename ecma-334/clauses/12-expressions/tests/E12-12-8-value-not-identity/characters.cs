/*
Rules: E12-12-8-value-not-identity; E12-12-8-predefined-equality; E12-12-8-predefined-inequality; E12-12-8-both-null; E12-12-8-identical-characters
Authority: ECMA-334 7th ed 12.12.8
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: first == equal
Into: (object)first == equal
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string first = new string(new char[] { 'a', '\0', 'z' }), equal = new string(new char[] { 'a', '\0', 'z' });
        string shorter = new string(new char[] { 'a', '\0' }), other = new string(new char[] { 'a', '\0', 'y' });
        string none = null;
        Check((object)first != (object)equal, "independent-string-instances");
        Check(first == equal && !(first != equal), "equal-characters-including-null-character");
        Check(first != shorter, "length-must-match"); Check(first != other, "every-position-must-match");
        Check(none == null && !(none != null), "both-null");
        Check(first != none && none != first, "one-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
