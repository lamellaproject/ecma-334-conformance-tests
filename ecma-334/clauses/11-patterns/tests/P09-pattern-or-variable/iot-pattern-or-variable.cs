/*
Rules: P09-pattern-or-variable
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: value is int number or string
Into: value is int number and var _
Csc: CS8780
*/
class Program
{
    static bool Match(object value) { return value is int number or string; }
    static void Main() { }
}
