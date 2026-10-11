/*
Rules: E20-4-ref-return-identity
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate ref object Edit();
Into: delegate ref string Edit();
Csc: CS0407
*/
delegate ref object Edit();
class Program
{
    static string stored = "alder";
    static ref string Read() { return ref stored; }
    static void Main() { Edit edit = Read; }
}
