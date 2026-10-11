/*
Rules: E12-8-9-3-eligible-accessible
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: reject
Mutate: private static int Read
Into: public static int Read
*/
class Cell { }
static class Extensions { private static int Read(this Cell receiver) { return 5; } }
class Program { static void Main() { new Cell().Read(); } }
