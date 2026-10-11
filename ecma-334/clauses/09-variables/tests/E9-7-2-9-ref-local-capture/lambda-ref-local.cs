/*
Rules: E9-7-2-9-ref-local-capture
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: ref int alias = ref cell;
Into: int alias = cell;
Csc: CS8175
*/
class Program
{
    static void Main()
    {
        int cell = 34;
        ref int alias = ref cell;
        System.Func<int> read = () => alias;
        read();
    }
}
