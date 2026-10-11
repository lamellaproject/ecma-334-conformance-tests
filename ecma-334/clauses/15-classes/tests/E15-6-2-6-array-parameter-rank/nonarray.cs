/*
Rules: E15-6-2-6-array-parameter-rank
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: reject
Mutate: params int values
Into: params int[] values
Csc: CS0225
*/
class Program
{
    static void Read(params int values) { }
    static void Main() { }
}
