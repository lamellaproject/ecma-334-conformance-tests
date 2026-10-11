/*
Rules: E12-23-operation-exception
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: 20 / (3 - 3)
Into: 20 / (3 - 2)
Csc: CS0020
*/
class Program
{
    static void Main() { int value = 20 / (3 - 3); }
}
