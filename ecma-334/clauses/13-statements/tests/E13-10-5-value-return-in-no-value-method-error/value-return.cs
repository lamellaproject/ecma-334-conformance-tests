/*
Rules: E13-10-5-value-return-in-no-value-method-error
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return 19;
Into: return;
*/

class Program
{
    static void Finish() { return 19; }
    static void Main() { }
}
