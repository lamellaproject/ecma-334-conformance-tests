/*
Rules: P09-new-no-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: var result = new(197);
Into: Widget result = new(197);
Csc: CS8754
*/
class Widget
{
    public int Code;
    public Widget(int value) { Code = value; }
}
class Program
{
    static void Main()
    {
        var result = new(197);
    }
}
