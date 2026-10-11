/*
Rules: E12-9-7-result-value
Authority: ECMA-334 7th ed 12.9.7
Version: 7.3
Expected: reject
Mutate: (int)value = 3
Into: value = 3
*/
class Program
{
    static void Main() { int value = 1; (int)value = 3; }
}
