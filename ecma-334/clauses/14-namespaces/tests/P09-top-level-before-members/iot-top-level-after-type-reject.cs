/*
Rules: P09-top-level-before-members
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: class Holder { } System.Console.WriteLine(3);
Into: System.Console.WriteLine(3); class Holder { }
*/
// top-level-statements.md L41; alpha-v13 namespaces 14.2 compilation grammar.
class Holder { } System.Console.WriteLine(3);
