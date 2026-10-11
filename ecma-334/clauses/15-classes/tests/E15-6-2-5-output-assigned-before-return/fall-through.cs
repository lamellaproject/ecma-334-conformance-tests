/*
Rules: E15-6-2-5-output-assigned-before-return
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: if (choose) value = 47;
Into: if (choose) value = 47; else value = 53;
Csc: CS0177
*/
class Program
{
    static void Write(out int value, bool choose) { if (choose) value = 47; }
    static void Main() { }
}
