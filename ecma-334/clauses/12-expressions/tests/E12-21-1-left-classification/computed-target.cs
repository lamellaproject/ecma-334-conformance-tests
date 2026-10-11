/*
Rules: E12-21-1-left-classification
Authority: ECMA-334 7th ed 12.21.1
Version: 7.3
Expected: reject
Mutate: Compute() = 4
Into: storage = 4
Csc: CS0131
*/
class Program
{
    static int storage;
    static int Compute() { return 3; }
    static void Main() { Compute() = 4; }
}
