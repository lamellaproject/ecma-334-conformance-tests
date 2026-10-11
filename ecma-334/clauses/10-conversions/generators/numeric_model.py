"""Independent ECMA numeric table and value model used by the generators.

IEEE values are modeled from exact binary values, not copied compiler results.
Decimal rounding models the supplied 96-bit significand, maximum scale 28 target.
The model deliberately returns an unrestricted oracle for unspecified conversions.
"""
from __future__ import annotations
import math
import struct
from decimal import Decimal, localcontext, ROUND_HALF_EVEN

TYPES = ["sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong", "char", "float", "double", "decimal"]
WIDTH = {"sbyte":8,"byte":8,"short":16,"ushort":16,"int":32,"uint":32,"long":64,"ulong":64,"char":16}
SIGNED = {"sbyte","short","int","long"}
RANGES = {t:(-(1<<(b-1)),(1<<(b-1))-1) if t in SIGNED else (0,(1<<b)-1) for t,b in WIDTH.items()}
IMPLICIT = {
    "sbyte":set("short int long float double decimal".split()),
    "byte":set("short ushort int uint long ulong float double decimal".split()),
    "short":set("int long float double decimal".split()),
    "ushort":set("int uint long ulong float double decimal".split()),
    "int":set("long float double decimal".split()),
    "uint":set("long ulong float double decimal".split()),
    "long":set("float double decimal".split()),
    "ulong":set("float double decimal".split()),
    "char":set("ushort int uint long ulong float double decimal".split()),
    "float":{"double"}, "double":set(), "decimal":set()
}
DECIMAL_MAX = (1<<96)-1


def implicit(source, target, value=None, constant=False):
    if source==target or target in IMPLICIT[source]:
        return True
    if constant and source=="int" and target in {"sbyte","byte","short","ushort","uint","ulong"}:
        return RANGES[target][0]<=value<=RANGES[target][1]
    return bool(constant and source=="long" and target=="ulong" and value>=0)


def single(value):
    try:
        return struct.unpack("!f", struct.pack("!f", float(value)))[0]
    except OverflowError:
        return math.copysign(math.inf, float(value))


def as_source(source, value):
    if source in WIDTH:
        return int(value)
    if source=="float":
        return single(value)
    if source=="double":
        return float(value)
    return value if isinstance(value, Decimal) else Decimal(str(value))


def float_literal(value, source):
    if math.isnan(value): return source+".NaN"
    if math.isinf(value): return source+(".NegativeInfinity" if value<0 else ".PositiveInfinity")
    text=format(value, ".9g" if source=="float" else ".17g")
    if "." not in text and "e" not in text: text+=".0"
    return text+("f" if source=="float" else "d")


def literal(source, value):
    if source in {"float","double"}: return float_literal(value, source)
    if source=="decimal": return str(value)+"m"
    if source=="long" and value==RANGES["long"][0]: return "long.MinValue"
    if source in {"sbyte","byte","short","ushort","char"}: return f"({source})({value})"
    return str(value)+{"int":"","uint":"U","long":"L","ulong":"UL"}[source]


def value_key(value):
    if isinstance(value,float):
        return "f:"+struct.pack("!d",value).hex()
    return type(value).__name__+":"+str(value)


def boundaries(source, target):
    if source in WIDTH:
        lower,upper=RANGES[source]
        candidates=[lower,upper,0,1,-1]
    elif source=="decimal":
        lower,upper=-DECIMAL_MAX,DECIMAL_MAX
        candidates=[Decimal(lower),Decimal(upper),Decimal(0),Decimal(1),Decimal(-1),Decimal("0.1"),Decimal("-0.1"),Decimal("1e-28"),Decimal("-1e-28")]
    else:
        lower,upper=(-single(3.4028234663852886e38),single(3.4028234663852886e38)) if source=="float" else (-1.7976931348623157e308,1.7976931348623157e308)
        candidates=[lower,upper,0.0,-0.0,1.0,-1.0,0.75,-0.75,math.nan,math.inf,-math.inf]
    if target in WIDTH:
        low,high=RANGES[target]
        candidates.extend([low-1,low,low+1,high-1,high,high+1])
        if source not in WIDTH:
            candidates.extend([Decimal(low)-Decimal("0.75"),Decimal(high)+Decimal("0.75")])
    elif target in {"float","double"}:
        precision=24 if target=="float" else 53
        pivot=1<<precision
        candidates.extend([pivot-1,pivot,pivot+1,-pivot-1,-pivot,-pivot+1])
        if source=="double" and target=="float":
            candidates.extend([1.000000059604644775390625,3.4028236e38,-3.4028236e38,1e-300,-1e-300,7.006492321624085e-46])
    elif source in {"float","double"}:
        candidates.extend([1e-30,-1e-30,0.1,-0.1,float(DECIMAL_MAX),-float(DECIMAL_MAX)])
    values=[];seen=set()
    for candidate in candidates:
        if isinstance(candidate,float) and not math.isfinite(candidate):
            if source not in {"float","double"}: continue
        elif not (lower<=candidate<=upper):
            continue
        value=as_source(source,candidate)
        key=value_key(value)
        if key not in seen:
            seen.add(key);values.append(value)
    return values


def decimal_round(value):
    # The CLR target accepts the nearest value with this 96-bit representation.
    exact=Decimal.from_float(value)
    with localcontext() as context:
        context.prec=1200
        if abs(exact)>Decimal(DECIMAL_MAX): return "overflow",None
        for scale in range(28,-1,-1):
            multiplier=Decimal(10)**scale
            significand=(exact*multiplier).to_integral_value(rounding=ROUND_HALF_EVEN)
            if abs(significand)<=DECIMAL_MAX:
                return "value",significand/multiplier
    return "overflow",None


def convert(source, target, value, checked):
    if target in WIDTH:
        if source in {"float","double"} and not math.isfinite(value):
            return ("overflow",None) if checked else ("unspecified",None)
        n=int(value)
        low,high=RANGES[target]
        if low<=n<=high: return "value",n
        if checked or source=="decimal": return "overflow",None
        if source in {"float","double"}: return "unspecified",None
        unsigned=n%(1<<WIDTH[target])
        return "value",unsigned-(1<<WIDTH[target]) if target in SIGNED and unsigned>(1<<(WIDTH[target]-1))-1 else unsigned
    if target in {"float","double"}:
        number=single(value) if target=="float" else float(value)
        return "value",number
    if source in {"float","double"}:
        if not math.isfinite(value): return "overflow",None
        return decimal_round(value)
    return "value",Decimal(value)


def assertion(target, expected, variable="result"):
    if target in {"float","double"}:
        if math.isnan(expected): return f"Check({target}.IsNaN({variable}));"
        if math.isinf(expected): return f"Check({target}.Is{'Negative' if expected<0 else 'Positive'}Infinity({variable}));"
        bits=struct.unpack("!I" if target=="float" else "!Q",struct.pack("!f" if target=="float" else "!d",expected))[0]
        expression=f"unchecked(({'uint' if target=='float' else 'ulong'})BitConverter.{'SingleToInt32Bits' if target=='float' else 'DoubleToInt64Bits'}({variable}))"
        return f"Check({expression}=={bits}{'U' if target=='float' else 'UL'});"
    return f"Check({variable}=={literal(target,expected)});"
