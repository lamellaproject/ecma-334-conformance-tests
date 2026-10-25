/*
Rules: P09-pattern-impossible-and
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: value is < 4 and > 6
Into: value is < 4 and > 1
*/
class Program
{
    static bool Match(int value) { return value is < 4 and > 6; }
    static void Main() { }
}
