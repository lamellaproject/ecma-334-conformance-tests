/*
Rules: E15-6-9-partial-invocation-expression-statement
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: object captured = Record();
Into: Record(); object captured = null;
Csc: CS0029
*/
partial class Program
{
    static partial void Record();
    static partial void Record() { }
    static void Main() { object captured = Record(); }
}
