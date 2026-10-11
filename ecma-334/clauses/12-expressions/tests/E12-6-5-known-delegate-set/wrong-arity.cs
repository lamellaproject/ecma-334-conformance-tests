/*
Rules: E12-6-5-known-delegate-set; E12-6-5-limited-check; E12-6-5-no-candidate
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: reject
Mutate: action(value);
Into: action(value, 8);
Csc: CS7036
*/
delegate void Action(int first, int second);
class Program
{
    static void Main()
    {
        Action action = (first, second) => { };
        dynamic value = 3;
        action(value);
    }
}
