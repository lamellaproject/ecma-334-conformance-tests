/*
Rules: E7-1-entry-parameter-list
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: Main(int argument)
Into: Main(string[] argument)
*/
class Program
{
    static void Main(int argument) { }
}
