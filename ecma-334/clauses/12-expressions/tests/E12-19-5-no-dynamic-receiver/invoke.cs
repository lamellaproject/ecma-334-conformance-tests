/*
Rules: E12-19-5-no-dynamic-receiver
Authority: ECMA-334 7th ed 12.19.5
Version: 7.3
Expected: reject
Mutate: ((int item) => item).Invoke(argument)
Into: ((Transform)((int item) => item)).Invoke(argument)
*/
delegate int Transform(int value);
class Program
{
    static void Main()
    {
        dynamic argument = 7;
        var result = ((int item) => item).Invoke(argument);
    }
}
