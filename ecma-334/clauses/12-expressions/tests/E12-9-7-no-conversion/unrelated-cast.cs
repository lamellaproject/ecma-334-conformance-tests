/*
Rules: E12-9-7-no-conversion
Authority: ECMA-334 7th ed 12.9.7
Version: 7.3
Expected: reject
Mutate: (int)new Token()
Into: (int)4L
*/
class Token { }
class Program
{
    static void Main() { int value = (int)new Token(); }
}
