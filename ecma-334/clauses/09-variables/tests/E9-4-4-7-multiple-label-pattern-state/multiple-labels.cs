/*
Rules: E9-4-4-7-multiple-label-pattern-state
Authority: ECMA-334 7th ed 9.4.4.7
Version: 7.3
Expected: reject
Mutate: System.Console.WriteLine(number);
Into: System.Console.WriteLine(0);
Csc: CS0165
*/
class Program
{
    static void Read(object source)
    {
        switch (source)
        {
            case int number:
            case string text:
                System.Console.WriteLine(number);
                break;
        }
    }
    static void Main() { Read("text"); }
}
