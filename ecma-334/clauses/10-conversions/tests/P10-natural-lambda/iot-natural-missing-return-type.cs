/*
Rules: P10-natural-lambda; P10-natural-var
Authority: csc 5.12.0-1.26529.118 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: return "quay";
Into: return 23;
*/
class Program
{
    static void Main()
    {
        var select = (bool first) => { if (first) return 17; return "quay"; };
        System.Console.WriteLine(select(true));
    }
}
