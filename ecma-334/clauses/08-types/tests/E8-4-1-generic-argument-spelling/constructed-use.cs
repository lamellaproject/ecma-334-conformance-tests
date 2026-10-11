/*
Rules: E8-4-1-generic-argument-spelling; E8-4-1-constructed-type-definition; E8-4-1-constructed-type-use; E8-4-1-constructed-simple-name; E8-4-1-constructed-member-access; E8-4-2-type-argument-is-type; E8-4-2-type-argument-list-form; E8-4-2-type-arguments-form; E8-4-2-type-argument-form
Authority: ECMA-334 7th ed 8.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pair<int, string>.Marker = 21;
Into: Pair<int, string>.Marker = 22;
*/
using System;
class Pair<T, U> { public static int Marker; public T First; public U Second; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair<int, string>.Marker = 21;
        Pair<int, string> pair = new Pair<int, string>(); pair.First = 9; pair.Second = "tag";
        Check(Pair<int, string>.Marker == 21 && pair.First == 9 && pair.Second == "tag", "constructed-type-name-and-members");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
