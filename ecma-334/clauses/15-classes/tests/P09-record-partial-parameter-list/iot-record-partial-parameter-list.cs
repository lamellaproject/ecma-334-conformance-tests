/*
Rules: P09-record-partial-parameter-list
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: partial record Canvas(int Height);
Into: partial record Canvas;
Csc: CS8863
*/
partial record Canvas(int Width);
partial record Canvas(int Height);
class Program { static void Main() { } }
