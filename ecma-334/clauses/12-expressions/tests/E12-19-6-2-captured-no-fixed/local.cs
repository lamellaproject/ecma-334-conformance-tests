/*
Rules: E12-19-6-2-captured-no-fixed; E12-19-6-2-captured-moveable
Authority: ECMA-334 7th ed 12.19.6.2
Version: 7.3
Expected: reject
Mutate: &cell
Into: &items[0]
*/
delegate int Result();
class Program
{
    unsafe static void Main()
    {
        int cell = 19;
        int[] items = new int[1];
        Result function = () => cell;
        fixed (int* pointer = &cell) { }
    }
}
