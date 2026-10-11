/*
Rules: E9-2-6-reference-argument-assigned; E9-4-1-reference-argument-assigned
Authority: ECMA-334 7th ed 9.2.6
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 4;
Csc: CS0165
*/
class Program
{
    static void Edit(ref int value) { value = 8; }
    static void Main() { int cell; Edit(ref cell); }
}
