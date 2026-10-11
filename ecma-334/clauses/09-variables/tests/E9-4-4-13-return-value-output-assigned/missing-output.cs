/*
Rules: E9-4-4-13-return-value-output-assigned
Authority: ECMA-334 7th ed 9.4.4.13
Version: 7.3
Expected: reject
Mutate: return 15;
Into: return value = 15;
Csc: CS0177
*/
class Program
{
    static int Fill(out int value) { return 15; }
    static void Main() { int cell; Fill(out cell); }
}
