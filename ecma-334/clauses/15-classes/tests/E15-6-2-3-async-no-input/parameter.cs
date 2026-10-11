/*
Rules: E15-6-2-3-async-no-input
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: in int value
Into: int value
Csc: CS1988
*/
class Program
{
    static async System.Threading.Tasks.Task<int> Read(in int value) { return value; }
    static void Main() { }
}
