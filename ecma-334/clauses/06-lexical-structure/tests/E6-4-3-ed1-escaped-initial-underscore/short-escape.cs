/*
Rules: E6-4-3-ed1-escaped-initial-underscore
Authority: ECMA-334 1st ed 9.4.2
Version: ISO-1
Expected: reject
Version-Witness: tests/E6-4-3-ed1-escaped-initial-underscore/short-escape.witness.cs.part
Mutate: \u005flever
Into: _lever
*/
// ECMA-334 1st ed 9.4.2, p. 55 (PDF p. 69), lines 22-24. An identifier cannot start with a
// Unicode escape for underscore.
class Entry
{
    static int Main()
    {
        int \u005flever = 14;
        System.Console.WriteLine("OK 0");
        return _lever - 14;
    }
}
