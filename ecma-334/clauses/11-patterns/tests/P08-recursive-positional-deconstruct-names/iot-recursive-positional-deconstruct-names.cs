/*
Rules: P08-recursive-positional-deconstruct-names
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: (right: 4, left: 7)
Into: (left: 4, right: 7)
*/
class Pair
{
    public void Deconstruct(out int left, out int right) { left = 4; right = 7; }
}
class Program
{
    static int Main() { return new Pair() is Pair(right: 4, left: 7) ? 0 : 1; }
}
