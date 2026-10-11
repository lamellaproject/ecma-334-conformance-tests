/*
Rules: E12-19-1-no-type; E12-19-1-no-value; E12-19-7-conversion-required
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: reject
Mutate: (int item) => item + 59
Into: (Transform)((int item) => item + 59)
*/
delegate int Transform(int item);
class Program { static void Main() { object value = (int item) => item + 59; } }
