/*
Rules: E10-3-5-array; E10-3-5-system-array; E10-3-5-array-list; E10-3-5-list-array; E10-3-5-identity-target
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: string[] narrow=(string[])wide;
Into: string[] narrow=default(string[]);
*/
using System;
using System.Collections.Generic;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] wide=new string[]{"seed"}; string[] narrow=(string[])wide;
        Array baseArray=narrow; ICloneable cloneable=narrow; string[] a=(string[])baseArray, b=(string[])cloneable;
        IList<string> list=(IList<string>)wide; IReadOnlyList<string> read=(IReadOnlyList<string>)wide;
        IList<object> wideList=narrow; IReadOnlyList<object> wideRead=narrow;
        string[] c=(string[])wideList, d=(string[])wideRead;
        object[,] matrix=new string[1,1]; string[,] thin=(string[,])matrix;
        IList<dynamic> identity=(IList<dynamic>)wide; IList<object> erased=identity;
        Check(narrow[0]=="seed" && list[0]=="seed" && read[0]=="seed", "E10-3-5-array-pilot-001-check-01");
        Check(ReferenceEquals(a,narrow) && ReferenceEquals(b,narrow) && ReferenceEquals(c,narrow) && ReferenceEquals(d,narrow), "E10-3-5-array-pilot-001-check-02");
        Check(ReferenceEquals(thin,matrix) && ReferenceEquals(erased,wide), "E10-3-5-array-pilot-001-check-03");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
