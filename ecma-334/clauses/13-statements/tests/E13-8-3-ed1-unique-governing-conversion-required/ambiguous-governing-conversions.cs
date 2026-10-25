/*
Rules: E13-8-3-ed1-unique-governing-conversion-required
Authority: ECMA-334 1st ed 15.7.2
Version: ISO-1
Expected: reject
Mutate: switch (input)
Into: switch ((int)input)
*/
// ECMA-334 1st ed 15.7.2, p. 186 (PDF p. 200), lines 5-8 rejects two listed implicit
// conversions.
struct Token
{
    public static implicit operator int(Token value) { return 7; }
    public static implicit operator long(Token value) { return 7; }
}
class Entry
{
    public static int Main()
    {
        Token input = new Token();
        switch (input) { default: return 0; }
    }
}
