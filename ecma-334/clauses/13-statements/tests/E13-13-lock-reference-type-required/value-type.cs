/*
Rules: E13-13-lock-reference-type-required; E13-13-lock-no-implicit-boxing
Authority: ECMA-334 7th ed 13.13
Version: 7.3
Expected: reject
Mutate: lock (gate)
Into: lock ((object)gate)
*/
class Program
{
    static void Main()
    {
        int gate = 4;
        lock (gate) { }
    }
}
