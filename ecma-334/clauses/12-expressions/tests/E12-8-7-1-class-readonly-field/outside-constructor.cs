/*
Rules: E12-8-7-1-class-readonly-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: reject
Mutate: public readonly int value = 3;
Into: public int value = 3;
Csc: CS0192
*/
class Worker { public readonly int value = 3; }
class Program
{
    static void Touch(ref int value) { value++; }
    static void Main() { Worker receiver = new Worker(); Touch(ref receiver.value); }
}
