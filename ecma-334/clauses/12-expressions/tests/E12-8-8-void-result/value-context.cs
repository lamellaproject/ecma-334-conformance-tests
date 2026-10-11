/*
Rules: E12-8-8-void-result
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: reject
Mutate: object result = receiver?.Touch();
Into: receiver?.Touch();
*/
class Cell { public void Touch() { } }
class Program
{
    static void Main()
    {
        Cell receiver = new Cell();
        object result = receiver?.Touch();
    }
}
