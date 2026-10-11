/*
Rules: E12-23-initialized-array-dimension-context
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: new int[length]
Into: new int[2]
Csc: CS0150
*/
class Program
{
    static void Main() { int length = 2; var array = new int[length] { 13, 17 }; }
}
