/*
Rules: E9-4-4-22-simple-expression-transfer
Authority: ECMA-334 7th ed 9.4.4.22
Version: 7.3
Expected: reject
Mutate: int marker;
Into: int marker = 46;
*/
class Program
{
    static int Read()
    {
        int marker;
        System.Type kind = typeof(Program);
        return marker;
    }
    static void Main() { System.Console.WriteLine(Read()); }
}
