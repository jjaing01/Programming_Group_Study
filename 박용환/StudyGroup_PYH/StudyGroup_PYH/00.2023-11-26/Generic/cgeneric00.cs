using System;
using System.Collections.Generic;
using System.Linq;

/* 
    * 제네릭이란?

        제네릭은 C# 프로그래밍 언어에서 사용되는 강력하고 유연한 프로그래밍 개념이다
        제네릭을 사용하면 타입을 동적으로 지정할 수 있고 다양한 형식의 데이터와 작업을 수행할 수 있다.
        이는 코드의 재사용성을 높이고 형식 안정성을 강화하는 데 도움이 된다.

*/

// List를 상속 받으면서 동시에 제네릭 타입 매개변수 TFirst를 사용
public class myGenericList<T> : List<T> // <T> : 타입 매개변수
{
    public void Method<TFirst>() { Console.WriteLine($"Method<{typeof(TFirst)}>"); }
    //public void Method<TSecond>() { } 

    //public void Method<T, T>() { }
}

class cgeneric00
{
    static void Main()
    {
        myGenericList<string> myGenericString = new myGenericList<string>(); // <string> : 타입 인수
        var GenericList = myGenericString; // 명시적으로 지정하지 않아도 타입 추론이 가능

        myGenericString.Add("PYH");
        myGenericString.Method<string>();

        foreach(var item in GenericList)
        {
            Console.WriteLine($"item : {item}");
        }

        myGenericList<int> myGenericInt = new myGenericList<int>(); 
        myGenericInt.Add(1);
        myGenericInt.Method<int>();


        //List<int> lists = new List<int>(5); // IEnumerable<T> 를 상속받는다. 이거 말고도 상속 받는게 많은데 이건 타고 들어가서 확인
        //lists.Add(3);
        //lists.Add(4);
        //lists.Add(6);

        //var result = lists.Where(n => n > 5); // Linq 기능
        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}

        //string s = "yonghwan";
        //string asura = string.IsNullOrEmpty(s)
        //    ? "empty"
        //    : "not empty";

        //Console.WriteLine(asura);
    }
}

// 제네릭이 될 수 있는 것 아닌것? 잘 이해 x