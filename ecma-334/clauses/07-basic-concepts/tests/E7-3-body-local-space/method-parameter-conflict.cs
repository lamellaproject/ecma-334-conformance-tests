/*
Rules: E7-3-body-local-space; E7-3-nested-local-name-conflict
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: int value = 17;
Into: int local = 17;
*/
class Program
{
    static void Method(int value) { int value = 17; }
    static void Main() { Method(23); }
}
