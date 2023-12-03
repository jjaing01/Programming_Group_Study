
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation. All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly cgeneric00
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- 다음 사용자 지정 특성이 자동으로 추가됩니다. 주석 처리를 제거하지 마십시오. -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module cgeneric00.exe
// MVID: {F9A68938-D732-4946-88F2-4C0EC488CBD7}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x06B10000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit myGenericList`1<T>
       extends class [mscorlib]System.Collections.Generic.List`1<!T>
{
  .method public hidebysig instance void 
          Method<TFirst>() cil managed
  {
    // 코드 크기       28 (0x1c)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "Method<{0}>"
    IL_0006:  ldtoken    !!TFirst
    IL_000b:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0010:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0015:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_001a:  nop
    IL_001b:  ret
  } // end of method myGenericList`1::Method

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 코드 크기       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void class [mscorlib]System.Collections.Generic.List`1<!T>::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method myGenericList`1::.ctor

} // end of class myGenericList`1

.class private auto ansi beforefieldinit cgeneric00
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // 코드 크기       115 (0x73)
    .maxstack  2
    .locals init (class myGenericList`1<string> V_0,
             class myGenericList`1<string> V_1,
             class myGenericList`1<int32> V_2,
             valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<string> V_3,
             string V_4)
    IL_0000:  nop
    IL_0001:  newobj     instance void class myGenericList`1<string>::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  stloc.1
    IL_0009:  ldloc.0
    IL_000a:  ldstr      "PYH"
    IL_000f:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<string>::Add(!0)
    IL_0014:  nop
    IL_0015:  ldloc.0
    IL_0016:  callvirt   instance void class myGenericList`1<string>::Method<string>()
    IL_001b:  nop
    IL_001c:  nop
    IL_001d:  ldloc.1
    IL_001e:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<string>::GetEnumerator()
    IL_0023:  stloc.3
    .try
    {
      IL_0024:  br.s       IL_0043

      IL_0026:  ldloca.s   V_3
      IL_0028:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<string>::get_Current()
      IL_002d:  stloc.s    V_4
      IL_002f:  nop
      IL_0030:  ldstr      "item : "
      IL_0035:  ldloc.s    V_4
      IL_0037:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_003c:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0041:  nop
      IL_0042:  nop
      IL_0043:  ldloca.s   V_3
      IL_0045:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<string>::MoveNext()
      IL_004a:  brtrue.s   IL_0026

      IL_004c:  leave.s    IL_005d

    }  // end .try
    finally
    {
      IL_004e:  ldloca.s   V_3
      IL_0050:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<string>
      IL_0056:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_005b:  nop
      IL_005c:  endfinally
    }  // end handler
    IL_005d:  newobj     instance void class myGenericList`1<int32>::.ctor()
    IL_0062:  stloc.2
    IL_0063:  ldloc.2
    IL_0064:  ldc.i4.1
    IL_0065:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Add(!0)
    IL_006a:  nop
    IL_006b:  ldloc.2
    IL_006c:  callvirt   instance void class myGenericList`1<int32>::Method<int32>()
    IL_0071:  nop
    IL_0072:  ret
  } // end of method cgeneric00::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 코드 크기       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method cgeneric00::.ctor

} // end of class cgeneric00


// =============================================================

// *********** 디스어셈블리 완료 ***********************
// 경고: Win32 리소스 파일 cgeneric00.res을(를) 만들었습니다.
