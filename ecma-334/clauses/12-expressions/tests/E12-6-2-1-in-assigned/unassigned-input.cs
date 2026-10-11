/*
Rules: E12-6-2-1-in-assigned; E12-6-2-3-input-reference-assigned
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: reject
Mutate: int number;
Into: int number = 17;
*/
class Program
{
    static void Observe(in int value) { }
    static void Main() { int number; Observe(in number); }
}
