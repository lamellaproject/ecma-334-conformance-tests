/*
Rules: E12-6-2-1-ref-assigned; E12-6-2-3-input-reference-assigned
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: reject
Mutate: int number;
Into: int number = 17;
*/
class Program
{
    static void Update(ref int value) { value = 31; }
    static void Main() { int number; Update(ref number); }
}
