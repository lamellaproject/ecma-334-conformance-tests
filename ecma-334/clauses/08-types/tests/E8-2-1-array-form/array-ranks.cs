/*
Rules: E8-2-1-array-form; E8-2-1-array-rank-form; E8-2-1-nonarray-form-value; E8-2-2-predefined-array-base
Authority: ECMA-334 7th ed 8.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int[,,] cube = new int[2, 3, 4];
Into: int[,,] cube = new int[2, 3, 5];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,,] cube = new int[2, 3, 4];
        int[][] jagged = new int[2][];
        System.Array asArray = cube;
        Check(cube.Length == 24 && jagged.Length == 2 && asArray.Length == 24, "rank-specifiers");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
