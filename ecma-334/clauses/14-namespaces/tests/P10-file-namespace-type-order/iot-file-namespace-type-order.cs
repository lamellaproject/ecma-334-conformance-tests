/*
Rules: P10-file-namespace-type-order
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: class First { } namespace Harbor;
Into: namespace Harbor; class First { }
Csc: CS8956
*/
class First { } namespace Harbor;
class Program { static void Main() { } }
