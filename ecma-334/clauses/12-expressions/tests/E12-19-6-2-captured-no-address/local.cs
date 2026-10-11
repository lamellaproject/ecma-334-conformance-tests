/*
Rules: E12-19-6-2-captured-no-address; E12-19-6-2-captured-moveable
Authority: ECMA-334 7th ed 12.19.6.2
Version: 7.3
Expected: reject
Mutate: &cell
Into: (int*)0
*/
delegate int Result();
class Program
{
    unsafe static void Main()
    {
        int cell = 17;
        Result function = () => cell;
        int* pointer = &cell;
    }
}
