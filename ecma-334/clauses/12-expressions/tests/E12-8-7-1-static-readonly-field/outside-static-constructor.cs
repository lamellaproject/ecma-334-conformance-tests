/*
Rules: E12-8-7-1-static-readonly-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: reject
Mutate: public static readonly int value = 3;
Into: public static int value = 3;
Csc: CS0199
*/
class Worker { public static readonly int value = 3; }
class Program
{
    static void Touch(ref int value) { value++; }
    static void Main() { Touch(ref Worker.value); }
}
