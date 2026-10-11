/*
Rules: E12-8-7-1-struct-value-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: reject
Mutate: Touch(ref Receiver().value);
Into: Touch(ref cell.value);
Csc: CS1612
*/
struct Cell { public int value; }
class Program
{
    static Cell cell = new Cell { value = 3 };
    static Cell Receiver() { return cell; }
    static void Touch(ref int value) { value++; }
    static void Main() { Touch(ref Receiver().value); }
}
