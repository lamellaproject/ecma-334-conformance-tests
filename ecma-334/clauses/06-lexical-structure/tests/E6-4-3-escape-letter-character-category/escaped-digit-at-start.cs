/*
Rules: E6-4-3-escape-letter-character-category
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: reject
Mutate: \u0665item
Into: \u0061item
*/
class Program
{
    static void Main() { int \u0665item = 37; }
}
