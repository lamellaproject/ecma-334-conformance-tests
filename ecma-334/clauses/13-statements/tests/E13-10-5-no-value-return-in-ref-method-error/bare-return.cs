/*
Rules: E13-10-5-no-value-return-in-ref-method-error
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return;
Into: return ref storage;
*/

class Program
{
    static int storage;
    static ref int Alias() { return; }
    static void Main() { }
}
