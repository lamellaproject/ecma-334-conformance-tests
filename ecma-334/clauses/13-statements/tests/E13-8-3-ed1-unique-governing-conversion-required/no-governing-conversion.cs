/*
Rules: E13-8-3-ed1-unique-governing-conversion-required
Authority: ECMA-334 1st ed 15.7.2
Version: ISO-1
Expected: reject
Mutate: class Token { }
Into: class Token { public static implicit operator int(Token value) { return 7; } }
*/
// ECMA-334 1st ed 15.7.2, p. 186 (PDF p. 200), lines 5-8 requires one listed conversion.
class Token { }
class Entry
{
    public static int Main()
    {
        Token input = new Token();
        switch (input) { default: return 0; }
    }
}
