/*
Rules: E6-4-5-5-ed2-nel-character-excluded
Authority: ECMA-334 2nd ed 9.4.4.4
Version: ISO-1
Expected: reject
Mutate: \xC2\x85
Into: \u0085
*/
class CharacterCell
{
    static void Main()
    {
        char cell = '';
        System.Console.WriteLine((int)cell);
    }
}
