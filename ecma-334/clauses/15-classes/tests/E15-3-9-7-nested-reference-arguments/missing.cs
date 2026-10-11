/*
Rules: E15-3-9-7-nested-reference-arguments
Authority: ECMA-334 7th ed 15.3.9.7
Version: 7.3
Expected: reject
Mutate: Box.Cell cell
Into: Box<int>.Cell cell
*/
class Box<T> { public class Cell { } }
class Program { static void Main() { Box.Cell cell = null; } }
