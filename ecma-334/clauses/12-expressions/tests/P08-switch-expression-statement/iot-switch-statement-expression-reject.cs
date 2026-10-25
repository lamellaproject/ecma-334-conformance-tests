/*
Rules: P08-switch-expression-statement
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: value switch { 1 => 2, _ => 3 };
Into: _ = value switch { 1 => 2, _ => 3 };
*/
// patterns.md L293; assigning the result repairs the expression-statement form.
class Program
{
    static void Main(string[] args)
    {
        int value = args.Length;
        value switch { 1 => 2, _ => 3 };
    }
}
