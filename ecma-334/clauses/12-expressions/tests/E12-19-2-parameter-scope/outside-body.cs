/*
Rules: E12-19-2-parameter-scope
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: int outside = value;
Into: int outside = 11;
*/
delegate int Transform(int item);
class Program
{
    static void Main()
    {
        Transform function = (int value) => value + 7;
        int outside = value;
    }
}
