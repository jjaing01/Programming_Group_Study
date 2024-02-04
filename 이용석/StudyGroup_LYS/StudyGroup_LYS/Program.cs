
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    internal class Program
    {
        struct structNullable { }
        class classNullable { }
        static void Main(string[] args)
        {
            Nullable<int> a;

            //속성과 메서드
            //1. HasValue
            //속성값이 있는 경우 : true
            //값이 없는 경우(Null) : false
            //
            //2.Value
            //속성값이 있는 경우 : 할당된 값
            //값이 없는 경우(null) : 예외(Exception) 발생
            //
            //3.GetValueOrDefault()
            //메서드값이 있는 경우: 할당된 값
            //반환값이 없는 경우(Null) : 기존 타입의 default 값 반환

            //-Value를 접근할때는 HasValue로 체크 한 후에 접근하기.

            // GetValueOrDefault는 아래 두가지 형태가 존재함
            //public T GetValueOrDefault()
            //{
            //    return value;
            //}

            //public T GetValueOrDefault(T defaultValue)
            //{
            //    if (!hasValue)
            //    {
            //        return defaultValue;
            //    }

            //    return value;
            //}

            //#region Test Code
            //Nullable<int> a; 
            //a = null; 
            //Console.WriteLine("Nullable<int> a : Null 일 때"); 
            //Console.WriteLine("a : {0}", a); 
            //Console.WriteLine("a.HasValue : {0} ", a.HasValue);    
            ////Console.WriteLine("a.Value : {0} ", a.Value);     // 할당된 값이 없으므로 예외   
            //Console.WriteLine("a.GetValueOrDefault() : {0} ", a.GetValueOrDefault());    

            //a = 10;    
            //Console.WriteLine("Nullable<int> a : 10 일 때");    
            //Console.WriteLine("a : {0}", a);   
            //Console.WriteLine("a.HasValue : {0} ", a.HasValue);   
            //Console.WriteLine("a.Value : {0} ", a.Value);   
            //Console.WriteLine("a.GetValueOrDefault() : {0} ", a.GetValueOrDefault());
            //#endregion Test Code

            // 1. Nullable은 값타입에만 적용할 수있다.
            // -> 참조타입은 이미 null이 허용됨
            // 타입 선언 시 ? 를 사용해서 Nullable<T> 타입으로 변수 선언이 가능

            //// 허용
            //Nullable<int> intNullable = null;
            //Nullable<structNullable> aStructNullable = null;

            //// 비허용
            //Nullable<string> aStringNullable = null;
            //Nullable<int[]> aStringNullable = null; // 배열은 요소가 값이여도 참조타입이다.
            //Nullable<Enum> aStringNullable = null; // Enum값은 타입이 아니다.
            //Nullable<classNullable> aClassNullable = null;
            #region Array
            int?[] arr = new int?[10];
            arr[0] = 10;
            arr[2] = 12;
            arr[5] = 15;
            arr[7] = 17;
            foreach (var num in arr) //var 대신 int? 사용가능.                         
            {
                if (true == num.HasValue)
                {
                    Console.WriteLine($"num = {num.Value}");
                }
                else if (false == num.HasValue && num == null)
                {
                    Console.WriteLine("Null 입니다.");
                }
            }
            #endregion Array

            // 선언 방법
            // 아래 두개는 동일한 동작
            //Nullable<T> 변수명
            //T? 변수명

            //Nullable<int> a;
            //int? b;


            // 2. Nullable Boxing
            // Null을 참조하게됨-> HasValue가 false
            //Nullable<int> nullableNoValue = new Nullable<int>();
            //object noVlaueObj = nullableNoValue;
            //Console.WriteLine(noVlaueObj == null);
            //Console.WriteLine(noVlaueObj.GetType()); // NullException


            //// Null을 참조하게됨-> HasValue가 true
            //Nullable<int> nullableValue = new Nullable<int>(5);
            //object VlaueObj = nullableValue;
            //Console.WriteLine(VlaueObj == null);
            //Console.WriteLine(VlaueObj.GetType());


            //// 3. ?? 연산(병합) 
            /// Null 이 아닐때만 해당값을 사용하고 Null이면 새로운 값을 사용하겠다.
            //string NullValue = null;
            //string message = string.Empty;

            //if (NullValue == null)
            //{
            //  message = "1. Null값입니다.";
            //  System.Console.WriteLine(message);
            //}

            //message = NullValue ?? "2. Null이므로 새로운 값으로 초기화 합니다.";
            //System.Console.WriteLine(message);


            //NullValue = "3. Null이 아닌 값으로 세팅되었습니다.";
            //message = NullValue ?? "4. Null이므로 새로운 값으로 초기화 합니다.";
            //System.Console.WriteLine(message);

            // 4. Nullable 가능논리
            // 조건부 논리 연산자(&&, ||)에 대해서는 정의되어 있지 않음

            //Nullable<bool> a = true;
            //Nullable<bool> b = false;
            //bool c = true, d = false;

            //// a && b 와 같은 형태로 사용할 수 없음
            //if (//a&& b ||
            //    // a.Value && b.Value
            //    //|| a.GetValueOrDefault() && b.GetValueOrDefault()
            //    )
            //{

            //}
            //if (c && d)
            //{

            //}




        }
    }
}