/*
Control: unhandled-exception
Purpose: Unhandled exceptions must fail.
Version: 7.3
Expected: run
Stdout: OK 0
*/
using System;
class Program { static void Main() { throw new Exception(); } }
