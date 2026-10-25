/*
Rules: P09-pattern-relational-nan
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: value is < double.NaN
Into: value is < double.MaxValue
*/
class Program
{
    static bool Match(double value) { return value is < double.NaN; }
    static void Main() { }
}
