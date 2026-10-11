/*
Rules: E8-3-8-mixed-decimal-floating-operands
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: reject
Mutate: left + right
Into: left + (decimal)right
*/
class Program { static void Main() { decimal left = 2m; double right = 3d; var result = left + right; } }
