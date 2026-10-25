/*
Rules: P09-unconstrained-default-inherited-kind
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: where T : default
Into: where T : class
*/
#nullable enable
class Source
{
    public virtual T? Read<T>(T? input) where T : class { return input; }
}
class Derived : Source
{
    public override T? Read<T>(T? input) where T : default { return input; }
}
class Program { static void Main() { } }
