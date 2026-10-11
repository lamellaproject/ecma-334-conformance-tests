/*
Rules: E7-1-entry-parameter-list
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: Main(string[] first, string[] second)
Into: Main(string[] first)
*/
class Program
{
    static void Main(string[] first, string[] second) { }
}
