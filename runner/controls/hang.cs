/*
Control: hang
Purpose: A timeout must fail.
Version: 7.3
Expected: run
Stdout: OK 0
*/
class Program { static void Main() { while (true) { } } }
