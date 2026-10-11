/*
Rules: E13-10-5-ref-return-in-value-method-error
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: return ref storage;
Into: return storage;
*/

class Program
{
    static int storage;
    static int Value() { return ref storage; }
    static void Main() { }
}
