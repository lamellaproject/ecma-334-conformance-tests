/*
Rules: E12-6-2-2-corresponding-required
Authority: ECMA-334 7th ed 12.6.2.2
Version: 7.3
Expected: reject
Mutate: Read(3, 5)
Into: Read(3)
*/
class Program { static void Read(int number) { } static void Main() { Read(3, 5); } }
