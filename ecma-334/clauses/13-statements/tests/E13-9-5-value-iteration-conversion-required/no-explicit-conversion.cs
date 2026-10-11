/*
Rules: E13-9-5-value-iteration-conversion-required
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: reject
Mutate: foreach (string item in new int[0])
Into: foreach (int item in new int[0])
*/
class Program
{
    static void Main() { foreach (string item in new int[0]) { } }
}
