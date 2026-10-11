/*
Rules: E9-4-4-33-captured-conversion-entry; E9-4-4-33-conversion-body-path
Authority: ECMA-334 7th ed 9.4.4.33
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 0;
Csc: CS0165
*/
class Program
{
    static void Main()
    {
        int cell;
        int Read() { return cell; }
        System.Func<int> reader = Read;
        cell = 43;
        reader();
    }
}
