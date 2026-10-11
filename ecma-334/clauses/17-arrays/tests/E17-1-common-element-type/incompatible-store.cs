/*
Rules: E17-1-common-element-type
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: reject
Mutate: values[1] = "different type"
Into: values[1] = 19
*/
class Program
{
    static void Main()
    {
        int[] values = new int[2];
        values[1] = "different type";
    }
}
