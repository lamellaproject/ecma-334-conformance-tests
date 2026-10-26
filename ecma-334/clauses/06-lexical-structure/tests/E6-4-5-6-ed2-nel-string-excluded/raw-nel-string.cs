/*
Rules: E6-4-5-6-ed2-nel-string-excluded
Authority: ECMA-334 2nd ed 9.4.4.5
Version: ISO-1
Expected: reject
Mutate: \xC2\x85
Into: \u0085
*/
class StringCell
{
    static void Main()
    {
        string cell = "eastwest";
        System.Console.WriteLine(cell.Length);
    }
}
