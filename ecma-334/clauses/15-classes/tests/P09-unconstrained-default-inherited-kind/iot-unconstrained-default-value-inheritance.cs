/*
Rules: P09-unconstrained-default-inherited-kind
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: where T : default
Into: where T : struct
*/
#nullable enable
interface ISource
{
    T? Read<T>(T? input) where T : struct;
}
class Source : ISource
{
    T? ISource.Read<T>(T? input) where T : default { return input; }
}
class Program { static void Main() { } }
