/*
Rules: E6-4-4-reserved-identifier; E6-4-3-available-identifier-not-keyword
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: reject
Generated: clauses/06-lexical-structure/generators/identifier-words.py
*/
class Program
{
    static void Main() { int abstract = 61; }
}
