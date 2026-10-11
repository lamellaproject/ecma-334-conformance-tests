/*
Rules: E9-4-4-12-throw-expression-entry
Authority: ECMA-334 7th ed 9.4.4.12
Version: 7.3
Expected: reject
Mutate: System.Exception error;
Into: System.Exception error = new System.Exception();
Csc: CS0165
*/
class Program
{
    static void Fail() { System.Exception error; throw error; }
    static void Main() { Fail(); }
}
