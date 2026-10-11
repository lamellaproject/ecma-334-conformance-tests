/*
Rules: E15-6-2-5-output-assigned-before-return
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: if (choose) return;
Into: if (choose) { value = 61; return; }
Csc: CS0177
*/
class Program
{
    static void Write(out int value, bool choose) { if (choose) return; value = 59; }
    static void Main() { }
}
