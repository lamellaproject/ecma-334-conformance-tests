/*
Rules: E15-6-8-external-not-generic
Authority: ECMA-334 7th ed 15.6.8
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/type-parameter-649175cd10.cs.part
Mutate: public static extern void Signal<T>();
Into: public static extern void Signal();
*/
using System.Runtime.CompilerServices;
// 15.6.8, p. 412 requires a diagnostic (clause 5, p. 9).
// Reject is the suite's nearest kind; an error is a valid diagnostic.
// InternalCall removes the unrelated missing-implementation-attribute warning.
class External
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Signal<T>();
}
class Program { static void Main() { } }
