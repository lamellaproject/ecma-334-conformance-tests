/*
Rules: E10-2-3-no-char; E10-2-3-only-listed
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: reject
Mutate: char result = input;
Into: char result = (char)input;
Csc: CS0266
*/
class Program
{
    static void Main()
    {
        int input = 61;
        char result = input;
    }
}
