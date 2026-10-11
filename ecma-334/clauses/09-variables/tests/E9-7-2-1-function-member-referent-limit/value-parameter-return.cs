/*
Rules: E9-7-2-1-function-member-referent-limit
Authority: ECMA-334 7th ed 9.7.2.1
Version: 7.3
Expected: reject
Mutate: Select(int value)
Into: Select(ref int value)
Csc: CS8166
*/
class Program
{
    static ref int Select(int value) { return ref value; }
    static void Main() { }
}
