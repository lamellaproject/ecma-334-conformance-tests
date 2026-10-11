/*
Rules: E12-8-11-3-ambiguous-indexer
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: reject
Mutate: receiver[3, 5]
Into: receiver[3, 5L]
*/
class Cell
{
    public int this[int first, long second] { get { return 1; } }
    public int this[long first, int second] { get { return 2; } }
}
class Program { static void Main() { Cell receiver = new Cell(); int result = receiver[3, 5]; } }
