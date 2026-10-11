/*
Rules: E12-3-1-dynamic-in-parameter
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: reject
Mutate: Read(receiver, in number)
Into: Read((object)receiver, in number)
*/
class Program
{
    public static void Read(object receiver, in int number) { }
    static void Main() { dynamic receiver = new object(); int number = 7; Read(receiver, in number); }
}
