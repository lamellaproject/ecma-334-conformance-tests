/*
Rules: E9-4-4-34-operand-entry
Authority: ECMA-334 7th ed 9.4.4.34
Version: 7.3
Expected: reject
Mutate: object source;
Into: object source = 81;
Csc: CS0165
*/
class Program
{
    static void Main() { object source; bool matches = source is int number; }
}
