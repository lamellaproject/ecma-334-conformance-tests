/*
Rules: E13-10-5-ref-return-identity-required
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: static ref long Alias()
Into: static ref int Alias()
*/

class Program
{
    static int storage;
    static ref long Alias() { return ref storage; }
    static void Main() { }
}
