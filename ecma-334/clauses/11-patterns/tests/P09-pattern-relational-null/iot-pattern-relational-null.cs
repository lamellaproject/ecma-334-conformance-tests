/*
Rules: P09-pattern-relational-null
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: value is < null
Into: value is < 0
*/
class Program
{
    static bool Match(object value) { return value is < null; }
    static void Main() { }
}
