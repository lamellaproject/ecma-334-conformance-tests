/*
Rules: E15-6-2-6-array-parameter-last
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: reject
Mutate: params int[] values
Into: int[] values
Csc: CS0231
*/
class Program
{
    static int Read(params int[] values, int tail) { return tail; }
    static void Main() { }
}
