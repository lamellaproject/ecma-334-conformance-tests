/*
Rules: P08-recursive-positional-required
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: public void Deconstruct(out int left, ref int right)
Into: public void Deconstruct(out int left, out int right)
*/
class Pair
{
    public void Deconstruct(out int left, ref int right)
    {
        left = 4; right = 7;
    }
}
class Program
{
    static int Main() { return new Pair() is Pair(4, 7) ? 0 : 1; }
}
