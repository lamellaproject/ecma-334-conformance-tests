/*
Rules: E6-4-3-escape-combining-character-category; E6-4-3-escape-decimal-digit-character-category; E6-4-3-escape-connecting-character-category; E6-4-3-escape-formatting-character-category; E6-4-3-escape-letter-character-category
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: reject
Mutate: \u0024
Into: \u0042
*/
class Program
{
    static void Main() { int mark\u0024 = 37; }
}
