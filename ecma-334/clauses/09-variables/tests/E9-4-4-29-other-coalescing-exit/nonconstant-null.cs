/*
Rules: E9-4-4-29-other-coalescing-exit
Authority: ECMA-334 7th ed 9.4.4.29
Version: 7.3
Expected: reject
Mutate: left ?? Right(out cell)
Into: (string)null ?? Right(out cell)
Csc: CS0165
*/
class Program
{
    static string Right(out int value) { value = 24; return "right"; }
    static void Main()
    {
        string left = null;
        int cell;
        string result = left ?? Right(out cell);
        System.Console.WriteLine(cell);
    }
}
