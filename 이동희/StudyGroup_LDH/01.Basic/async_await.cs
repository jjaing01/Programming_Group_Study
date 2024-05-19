using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LDH._01.Basic
{
    internal class Program
    {
        public static string BoilWater()
        {
            System.Console.WriteLine("물 끓이기 시작");
            System.Console.WriteLine("기다리는 중...");

            // 강제로 Delay
            Task.Delay(2000).GetAwaiter().GetResult();

            System.Console.WriteLine("물 끓이기 완료");

            string ret = "끓인 물";
            return ret;
        }

        public static string MakeCoffee()
        {
            // 물 끓이기
            var water = BoilWater();

            // 컵 꺼내기
            System.Console.WriteLine("컵을 꺼낸다.");
            // 원두를 컵에 넣기
            System.Console.WriteLine("원두를 컵에 넣는다.");

            string ret = "컵에 물을 부으면 된다.";
            return ret;
        }

        public static async Task<string> MakeCoffeeAsync()
        {
            // 물을 끓이자
            var boilingWater = BoilWaterAsync();

            System.Console.WriteLine("컵을 꺼낸다.");

            // 오버헤드를 직접 부여한다.
            int a = 0;
            for (int i = 0; i < 100_000_0000; ++i)
            {
                a += i;
            }

            System.Console.WriteLine("원두를 컵에 넣는다.");

            var water = await boilingWater;
            System.Console.WriteLine(boilingWater);

            return "끓인 물 붓기";
        }

        public static async Task<string> BoilWaterAsync()
        {
            System.Console.WriteLine("물 끓이기 시작");
            System.Console.WriteLine("기다리는 중...");

            // 강제로 Delay
            await Task.Delay(2000);

            System.Console.WriteLine("물 끓이기 완료");

            string ret = "끓인 물";
            return ret;
        }

        // 커피 만들기
        public static void Main(string[] args)
        {
            // 동기식 커피 만들기
            //var result = MakeCoffee();
            //Console.WriteLine(result);

            System.Console.WriteLine(MakeCoffeeAsync().Result);

            Console.WriteLine("커피 완성");
        }
    }
}
