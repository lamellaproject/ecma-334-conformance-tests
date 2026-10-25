/*
Rules: P09-pattern-relational-constant
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: value is > edge
Into: value is > 4
*/
class Program
{
    static bool Match(int value, int edge) { return value is > edge; }
    static void Main() { }
}
