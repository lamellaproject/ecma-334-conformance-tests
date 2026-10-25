/*
Rules: P10-file-namespace-statements-exclusive
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: System.Console.WriteLine("mark"); namespace Berth;
Into: namespace Berth;
Csc: CS8956
*/
System.Console.WriteLine("mark"); namespace Berth;
class Program { static void Main() { } }
