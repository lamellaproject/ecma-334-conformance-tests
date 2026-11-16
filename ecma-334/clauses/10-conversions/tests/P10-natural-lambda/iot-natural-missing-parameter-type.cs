/*
Rules: P10-natural-lambda; P10-natural-var
Authority: csc 5.12.0-1.26529.118 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: var modify = (item) =>
Into: var modify = (Parcel item) =>
*/
class Parcel { public int Value; }
class Program
{
    static void Main()
    {
        var modify = (item) => { item.Value = 5; };
        modify(new Parcel());
    }
}
