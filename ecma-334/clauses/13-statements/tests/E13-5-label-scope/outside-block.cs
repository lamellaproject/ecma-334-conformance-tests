/*
Rules: E13-5-label-scope
Authority: ECMA-334 7th ed 13.5
Version: 7.3
Expected: reject
Mutate: goto nested;
Into: ;
Csc: CS0159
*/
class Program
{
    static void Main() { { nested: ; } goto nested; }
}
