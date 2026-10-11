/*
Rules: E9-4-4-17-collection-expression-entry
Authority: ECMA-334 7th ed 9.4.4.17
Version: 7.3
Expected: reject
Mutate: int[] cells;
Into: int[] cells = new int[0];
Csc: CS0165
*/
class Program
{
    static void Main() { int[] cells; foreach (int cell in cells) { } }
}
