/*
Rules: P09-unconstrained-default-context
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate:  where T : default
Into: 
*/
class Container<T> where T : default { }
class Program { static void Main() { } }
