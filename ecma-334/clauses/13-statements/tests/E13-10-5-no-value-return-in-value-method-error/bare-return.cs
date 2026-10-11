/*
Rules: E13-10-5-no-value-return-in-value-method-error
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return;
Into: return 19;
*/

class Program
{
    static int Value() { return; }
    static void Main() { }
}
