/*
Rules: E15-6-2-3-input-no-modification
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: static void Forward(in int value)
Into: static void Forward(ref int value)
Csc: CS8329
*/
class Program
{
    static void Edit(ref int value) { value = 59; }
    static void Forward(in int value) { Edit(ref value); }
    static void Main() { }
}
