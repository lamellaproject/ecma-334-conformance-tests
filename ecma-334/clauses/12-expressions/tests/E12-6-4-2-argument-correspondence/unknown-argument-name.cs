/*
Rules: E12-6-4-2-argument-correspondence
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: missing: 7
Into: last: 7
*/
class Program
{
    static void Pick(int first, int last) { }
    static void Main() { Pick(first: 2, missing: 7); }
}
