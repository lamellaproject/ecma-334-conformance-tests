/*
Rules: E12-19-5-no-dynamic-operand
Authority: ECMA-334 7th ed 12.19.5
Version: 7.3
Expected: reject
Mutate: ((int item) => item + 13)
Into: (Transform)((int item) => item + 13)
*/
public delegate int Transform(int value);
public class Number
{
    public int Value;
    public static int operator +(Number number, Transform function) { return function(number.Value); }
}
class Program
{
    static void Main()
    {
        dynamic number = new Number();
        var result = number + ((int item) => item + 13);
    }
}
