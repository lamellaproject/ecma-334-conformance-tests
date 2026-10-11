/*
Rules: P12-collection-array; P12-collection-span; P12-collection-constructor; P12-collection-interfaces; P12-collection-element; P12-collection-spread; P12-collection-empty
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 4
Mutate: int[] array=[11,..seed,19];
Into: int[] array=[11,19];
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte[] seed=new byte[]{13,17};
        int[] array=[11,..seed,19]; Span<int> span=[23,29]; ReadOnlySpan<int> ro=[31,37];
        List<int> list=[41,..seed]; HashSet<int> set=[43,47];
        IEnumerable<int> e=[53,59]; IReadOnlyCollection<int> c=[61,67]; IReadOnlyList<int> r=[71,73];
        ICollection<int> mutable=[79,83]; IList<int> indexed=[89,97];
        int[] nothing=[]; Span<int> noSpan=[];
        Check(array.Length==4 && array[0]==11 && array[1]==13 && array[2]==17 && array[3]==19, "P12-collection-array-pilot-200001-check-01");
        Check(span[1]==29 && ro[0]==31 && list.Count==3 && set.Contains(47), "P12-collection-array-pilot-200001-check-02");
        Check(new List<int>(e)[1]==59 && c.Count==2 && r[1]==73 && mutable.Count==2 && indexed[1]==97, "P12-collection-array-pilot-200001-check-03");
        mutable.Add(101); Check(mutable.Count==3 && nothing.Length==0 && noSpan.Length==0, "P12-collection-array-pilot-200001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
