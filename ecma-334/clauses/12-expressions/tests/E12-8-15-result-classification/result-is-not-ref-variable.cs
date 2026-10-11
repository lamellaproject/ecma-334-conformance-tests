/*
Rules: E12-8-15-result-classification
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: reject
Mutate: Take(ref value++)
Into: Take(ref value)
*/
class Program
{
    static void Take(ref int value) { }
    static void Main() { int value = 3; Take(ref value++); }
}
