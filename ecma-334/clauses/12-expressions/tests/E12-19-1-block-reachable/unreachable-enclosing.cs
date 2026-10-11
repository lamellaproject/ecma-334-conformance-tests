/*
Rules: E12-19-1-block-reachable
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: reject
Mutate: int item;
Into: int item = 71;
*/
delegate int Result();
class Program
{
    static void Main()
    {
        if (false)
        {
            Result function = () => { int item; return item; };
        }
    }
}
