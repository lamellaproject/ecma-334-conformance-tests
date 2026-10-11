/*
Rules: E6-4-2-character-bmp-only; E6-4-5-5-character-value-range; E6-4-5-5-unicode-escape-range
Authority: ECMA-334 7th ed 6.4.2
Version: 7.3
Expected: reject
Mutate: '\U00010007'
Into: '\U00000007'
Csc: CS1012
*/
class Program
{
    static void Main() { char outside = '\U00010007'; }
}
