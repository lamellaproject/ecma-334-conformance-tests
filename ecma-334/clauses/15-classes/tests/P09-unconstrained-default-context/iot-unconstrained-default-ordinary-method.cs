/*
Rules: P09-unconstrained-default-context
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate:  where T : default
Into: 
*/
#nullable enable
class Program
{
    static T? Echo<T>(T? input) where T : default { return input; }
    static void Main() { }
}
