/*
Control: run-does-not-compile
Purpose: A run program with a compile error must fail.
Version: 7.3
Expected: run
Stdout: OK 0
*/
class Program { static void Main() { int value = "not-an-int"; } }
