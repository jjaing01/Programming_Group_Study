
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation. All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly cboxing
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- 다음 사용자 지정 특성이 자동으로 추가됩니다. 주석 처리를 제거하지 마십시오. -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module cboxing.exe
// MVID: {59738BC2-342F-4BDB-AC42-8052AF3D0625}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x071D0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit cBoxing
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // 코드 크기       183 (0xb7)
    .maxstack  3
    .locals init (valuetype [mscorlib]System.Nullable`1<int32> V_0,
             valuetype [mscorlib]System.Nullable`1<int32> V_1,
             object V_2,
             object V_3,
             valuetype [mscorlib]System.Nullable`1<int32> V_4)
    IL_0000:  nop
    IL_0001:  ldloca.s   V_0
    IL_0003:  initobj    valuetype [mscorlib]System.Nullable`1<int32>
    IL_0009:  ldloca.s   V_1
    IL_000b:  ldc.i4.1
    IL_000c:  call       instance void valuetype [mscorlib]System.Nullable`1<int32>::.ctor(!0)
    IL_0011:  ldloc.1
    IL_0012:  box        valuetype [mscorlib]System.Nullable`1<int32>
    IL_0017:  stloc.2
    IL_0018:  ldnull
    IL_0019:  stloc.3
    IL_001a:  ldloc.2
    IL_001b:  unbox.any  valuetype [mscorlib]System.Nullable`1<int32>
    IL_0020:  stloc.s    V_4
    IL_0022:  ldstr      "Original simplenullableInt: {0}"
    IL_0027:  ldloc.0
    IL_0028:  box        valuetype [mscorlib]System.Nullable`1<int32>
    IL_002d:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0032:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0037:  nop
    IL_0038:  ldstr      "Original nullableInt: {0}"
    IL_003d:  ldloc.1
    IL_003e:  box        valuetype [mscorlib]System.Nullable`1<int32>
    IL_0043:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0048:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_004d:  nop
    IL_004e:  ldstr      "Boxed Value: {0}"
    IL_0053:  ldloc.0
    IL_0054:  box        valuetype [mscorlib]System.Nullable`1<int32>
    IL_0059:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_005e:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0063:  nop
    IL_0064:  ldstr      "Boxed Value: {0}"
    IL_0069:  ldloc.2
    IL_006a:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_006f:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0074:  nop
    IL_0075:  ldstr      "Boxed Null: {0}"
    IL_007a:  ldloc.3
    IL_007b:  ldnull
    IL_007c:  ceq
    IL_007e:  box        [mscorlib]System.Boolean
    IL_0083:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0088:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_008d:  nop
    IL_008e:  ldstr      "Boxed Null: {0}"
    IL_0093:  ldloc.3
    IL_0094:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0099:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_009e:  nop
    IL_009f:  ldstr      "Unboxed Value: {0}"
    IL_00a4:  ldloc.s    V_4
    IL_00a6:  box        valuetype [mscorlib]System.Nullable`1<int32>
    IL_00ab:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_00b0:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_00b5:  nop
    IL_00b6:  ret
  } // end of method cBoxing::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 코드 크기       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method cBoxing::.ctor

} // end of class cBoxing


// =============================================================

// *********** 디스어셈블리 완료 ***********************
// 경고: Win32 리소스 파일 cboxing.res을(를) 만들었습니다.
