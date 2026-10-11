/*
Rules: E9-2-7-output-parameter-return-assigned; E9-4-1-output-parameters-at-return; E9-4-4-13-return-void-output-assigned
Authority: ECMA-334 7th ed 9.2.7
Version: 7.3
Expected: reject
Mutate: else return;
Into: else { value = 12; return; }
Csc: CS0177
*/
class Program
{
    static void Fill(bool choose, out int value)
    {
        if (choose) value = 9;
        else return;
    }
    static void Main() { int cell; Fill(false, out cell); }
}
