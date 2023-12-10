
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation. All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly cnullable00
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- 다음 사용자 지정 특성이 자동으로 추가됩니다. 주석 처리를 제거하지 마십시오. -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module cnullable00.exe
// MVID: {640BAAD6-D438-485D-8386-D3D0001F1375}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x05670000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit CNullableExample
       extends [mscorlib]System.Object
{
  .field private valuetype [mscorlib]System.Nullable`1<int32> '<nullableint>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .field private int32 '<notnullableint>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Diagnostics.DebuggerBrowsableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggerBrowsableState) = ( 01 00 00 00 00 00 00 00 ) 
  .method public hidebysig specialname instance void 
          set_nullableint(valuetype [mscorlib]System.Nullable`1<int32> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // 코드 크기       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      valuetype [mscorlib]System.Nullable`1<int32> CNullableExample::'<nullableint>k__BackingField'
    IL_0007:  ret
  } // end of method CNullableExample::set_nullableint

  .method public hidebysig specialname instance valuetype [mscorlib]System.Nullable`1<int32> 
          get_nullableint() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // 코드 크기       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype [mscorlib]System.Nullable`1<int32> CNullableExample::'<nullableint>k__BackingField'
    IL_0006:  ret
  } // end of method CNullableExample::get_nullableint

  .method public hidebysig specialname instance void 
          set_notnullableint(int32 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // 코드 크기       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 CNullableExample::'<notnullableint>k__BackingField'
    IL_0007:  ret
  } // end of method CNullableExample::set_notnullableint

  .method public hidebysig specialname instance int32 
          get_notnullableint() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // 코드 크기       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 CNullableExample::'<notnullableint>k__BackingField'
    IL_0006:  ret
  } // end of method CNullableExample::get_notnullableint

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 코드 크기       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method CNullableExample::.ctor

  .property instance valuetype [mscorlib]System.Nullable`1<int32>
          nullableint()
  {
    .get instance valuetype [mscorlib]System.Nullable`1<int32> CNullableExample::get_nullableint()
    .set instance void CNullableExample::set_nullableint(valuetype [mscorlib]System.Nullable`1<int32>)
  } // end of property CNullableExample::nullableint
  .property instance int32 notnullableint()
  {
    .get instance int32 CNullableExample::get_notnullableint()
    .set instance void CNullableExample::set_notnullableint(int32)
  } // end of property CNullableExample::notnullableint
} // end of class CNullableExample

.class private auto ansi beforefieldinit CNullable00
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // 코드 크기       268 (0x10c)
    .maxstack  3
    .locals init (class CNullableExample V_0,
             int32 V_1,
             valuetype [mscorlib]System.Nullable`1<int32> V_2,
             int32 V_3,
             valuetype [mscorlib]System.Nullable`1<int32> V_4,
             bool V_5,
             valuetype [mscorlib]System.Nullable`1<int32> V_6)
    IL_0000:  nop
    IL_0001:  newobj     instance void CNullableExample::.ctor()
    IL_0006:  dup
    IL_0007:  ldloca.s   V_4
    IL_0009:  initobj    valuetype [mscorlib]System.Nullable`1<int32>
    IL_000f:  ldloc.s    V_4
    IL_0011:  callvirt   instance void CNullableExample::set_nullableint(valuetype [mscorlib]System.Nullable`1<int32>)
    IL_0016:  nop
    IL_0017:  dup
    IL_0018:  ldc.i4.1
    IL_0019:  callvirt   instance void CNullableExample::set_notnullableint(int32)
    IL_001e:  nop
    IL_001f:  stloc.0
    IL_0020:  ldloc.0
    IL_0021:  callvirt   instance valuetype [mscorlib]System.Nullable`1<int32> CNullableExample::get_nullableint()
    IL_0026:  stloc.s    V_4
    IL_0028:  ldloca.s   V_4
    IL_002a:  call       instance bool valuetype [mscorlib]System.Nullable`1<int32>::get_HasValue()
    IL_002f:  stloc.s    V_5
    IL_0031:  ldloc.s    V_5
    IL_0033:  brfalse.s  IL_005d

    IL_0035:  nop
    IL_0036:  ldstr      "Value: {0}"
    IL_003b:  ldloc.0
    IL_003c:  callvirt   instance valuetype [mscorlib]System.Nullable`1<int32> CNullableExample::get_nullableint()
    IL_0041:  stloc.s    V_4
    IL_0043:  ldloca.s   V_4
    IL_0045:  call       instance !0 valuetype [mscorlib]System.Nullable`1<int32>::get_Value()
    IL_004a:  box        [mscorlib]System.Int32
    IL_004f:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0054:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0059:  nop
    IL_005a:  nop
    IL_005b:  br.s       IL_006a

    IL_005d:  nop
    IL_005e:  ldstr      "The variable is null."
    IL_0063:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0068:  nop
    IL_0069:  nop
    IL_006a:  ldloc.0
    IL_006b:  callvirt   instance valuetype [mscorlib]System.Nullable`1<int32> CNullableExample::get_nullableint()
    IL_0070:  stloc.s    V_4
    IL_0072:  ldloca.s   V_4
    IL_0074:  call       instance bool valuetype [mscorlib]System.Nullable`1<int32>::get_HasValue()
    IL_0079:  brtrue.s   IL_0083

    IL_007b:  ldloc.0
    IL_007c:  callvirt   instance int32 CNullableExample::get_notnullableint()
    IL_0081:  br.s       IL_008a

    IL_0083:  ldloca.s   V_4
    IL_0085:  call       instance !0 valuetype [mscorlib]System.Nullable`1<int32>::GetValueOrDefault()
    IL_008a:  stloc.1
    IL_008b:  ldloca.s   V_2
    IL_008d:  initobj    valuetype [mscorlib]System.Nullable`1<int32>
    IL_0093:  ldloc.0
    IL_0094:  callvirt   instance valuetype [mscorlib]System.Nullable`1<int32> CNullableExample::get_nullableint()
    IL_0099:  stloc.s    V_4
    IL_009b:  ldloca.s   V_4
    IL_009d:  call       instance bool valuetype [mscorlib]System.Nullable`1<int32>::get_HasValue()
    IL_00a2:  brtrue.s   IL_00c1

    IL_00a4:  ldloc.2
    IL_00a5:  stloc.s    V_6
    IL_00a7:  ldloca.s   V_6
    IL_00a9:  call       instance bool valuetype [mscorlib]System.Nullable`1<int32>::get_HasValue()
    IL_00ae:  brtrue.s   IL_00b8

    IL_00b0:  ldloc.0
    IL_00b1:  callvirt   instance int32 CNullableExample::get_notnullableint()
    IL_00b6:  br.s       IL_00bf

    IL_00b8:  ldloca.s   V_6
    IL_00ba:  call       instance !0 valuetype [mscorlib]System.Nullable`1<int32>::GetValueOrDefault()
    IL_00bf:  br.s       IL_00c8

    IL_00c1:  ldloca.s   V_4
    IL_00c3:  call       instance !0 valuetype [mscorlib]System.Nullable`1<int32>::GetValueOrDefault()
    IL_00c8:  stloc.3
    IL_00c9:  ldstr      "Value: {0}"
    IL_00ce:  ldloc.1
    IL_00cf:  box        [mscorlib]System.Int32
    IL_00d4:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_00d9:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_00de:  nop
    IL_00df:  ldstr      "Value: {0}"
    IL_00e4:  ldloc.2
    IL_00e5:  box        valuetype [mscorlib]System.Nullable`1<int32>
    IL_00ea:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_00ef:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_00f4:  nop
    IL_00f5:  ldstr      "Value: {0}"
    IL_00fa:  ldloc.3
    IL_00fb:  box        [mscorlib]System.Int32
    IL_0100:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0105:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_010a:  nop
    IL_010b:  ret
  } // end of method CNullable00::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 코드 크기       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method CNullable00::.ctor

} // end of class CNullable00


// =============================================================

// *********** 디스어셈블리 완료 ***********************
// 경고: Win32 리소스 파일 cnullable00.res을(를) 만들었습니다.
