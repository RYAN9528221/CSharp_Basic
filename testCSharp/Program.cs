using System;
using System.Collections.Generic;

namespace testCSharp
{
    //自定義的異常處理是件CH24
    public class RyanException:Exception
    {
        public RyanException(string message) :base(message)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("警告:Error");
            Console.WriteLine("============================================");
        }
    }

    class Program
    {
        #region 1.初始化:
        //------------------------------------------------------------------------------------
        //CH9
        //ARRAY
        int[] xp = new int[5];
        //------------------------------------------------------------------------------------
        //CH13 struct資料
        struct Student
        {
            public string name;
            public char gender;
            public int score;
            public Parrent parrent;//父母.....巢狀結構
        }
        struct Parrent
        {
            public double Salary;//薪水
        }
        //------------------------------------------------------------------------------------
        //CH14列舉 Enum
        enum MyScore 
        {
            Level_A=100,
            Level_B=80,
            Level_C=60,
            Level_D=40,
            Level_E=20
        }
        //----------------------------------------------
        //CH17物件建構方法
        public class TaipeiBank    
        {
            public int acc;
            public readonly int b=55688;//唯讀,不能改寫
            public TaipeiBank() 
            {
            
            }

            //17-2重載(多載)
            public TaipeiBank(int a)
            {
                acc = a;
            }

            //17-6
            public int getACC 
            {
                get { return acc; }
            }
            public int bValue
            {
                get { return b; }
            }
            //解構子
            ~TaipeiBank() 
            {
                Console.WriteLine("離開關閉");//CH26
            }
        } //----------------------------------------------
        //CH19抽象
        public class SmartCar 
        {
            public virtual void Type() 
            {
                Console.WriteLine("尚未定義車廠名稱");
            }
        }
        public class ModelY:SmartCar
        {
            public override void Type()
            {
                Console.WriteLine("tesla");  
            }
        }
        public class ModelS:SmartCar
        {
            //public override void Type()
            //{
            //    Console.WriteLine("tesla");
            //}
        }
        //----------------------------------------------
        //CH20介面interface


        interface InAnimal 
        {
            void Action();
        }

        class Dog : InAnimal 
        {
            public void Action() 
            {
            
            }
        }
        //----------------------------------------------
        //CH21重載OverLoad:
        static void testobj(ref object x,ref object y) 
        {
            object tmp;
            tmp = x;
            x = y;
            y = tmp;
        }
        //------------------------------------------------------------------------------------
        //CH26 委派
        public delegate int NumOperation(int x, int y);

        public static int Add(int a, int b)
        {

            return a + b;
        }

        public static int Sub(int a, int b)
        {

            return a - b;
        }
        //------------------------------------------------------------------------------------
        #endregion

        //主程式進入點:
        static void Main(string[] args)
        {
            #region 2.過程:
            //------------------------------------------------------------------------------------
            //CH6
            int[] xp2 = new int[5];
            //------------------------------------------------------------------------------------
            //CH13
            Student student1;
            Student student2;
            student1.name = "溫";
            student1.gender ='b';
            student1.score =70;
            
            student1.parrent.Salary = 9000;
            
            Parrent pt1 = new Parrent();
            pt1.Salary = 1100000;
            student1.parrent = pt1;//同上
            
            student2 = student1;//COPY
            //------------------------------------------------------------------------------------
            //CH15時間
            DateTime dataTime = new DateTime(2024,01,28,8,12,23,300);
            //------------------------------------------------------------------------------------
            //CH17 物件的建構屬性封裝
            TaipeiBank tpBank = new TaipeiBank();
            tpBank.acc = 1955;

            TaipeiBank tpBank2 = new TaipeiBank(44);
            //------------------------------------------------------------------------------------
            //CH19繼承
            ModelY MyCar = new ModelY();
            MyCar.Type();

            ModelS MyCar2 = new ModelS();
            MyCar2.Type();
            //------------------------------------------------------------------------------------
            //CH21
            object x1 = 5;
            object y1 = 5;
            object ch1 = 'a';
            object ch2 = 'b';

            testobj(ref x1, ref y1);
            //------------------------------------------------------------------------------------
            //CH22 泛型(資料堆疊) using System.Collections.Generic;
            //List
            //Stack
            //Queue
            //LinkedList
            //SortedSet
            //Dictionary
            //SortedList
            //SortedDictionary
            List<int> vec1 = new List<int>();
            vec1.Add(1);
            vec1.Add(3);
            vec1.Add(5);
            vec1.Add(7);
            vec1.Add(9);
            //------------------------------------------------------------------------------------
            //CH24 Try Catch:
            try
            {
                int div = 0;
                double a = 10.0 / div;
            }catch(DivideByZeroException)
            {
                Console.WriteLine("除數不可以為0");//.............新版c#好像已經防呆好了
            }
            //------------------------------------------------------------------------------------
            //CH24-7異常處理
            int BeautifulGirl = 25;
            try
            {
                //直接告訴你不良
                if (BeautifulGirl < 18) 
                {
                    //ok
                }
                else
                {
                    throw new RyanException("超齡");
                }

            }catch(RyanException e) 
            {
                Console.Write(e);
            }
            //------------------------------------------------------------------------------------
            //CH26 委派
            NumOperation operationA = Add;
            NumOperation operationS = Sub;
            var X = operationA.Invoke(3, 4);
            //------------------------------------------------------------------------------------
            #endregion

            #region 3.結果輸出:
            Console.WriteLine(xp2[0]);//CH6
            Console.WriteLine(student2.name);//CH13
            Console.WriteLine(student2.gender);//CH13
            Console.WriteLine(student2.score);//CH13
            Console.WriteLine(student2.parrent);//CH13
            Console.WriteLine("學生父母的薪水:"+student2.parrent.Salary);//CH13
            Console.WriteLine(tpBank.acc);//CH17
            Console.WriteLine(tpBank2.acc);//CH17-2
            Console.WriteLine(tpBank2.getACC);//CH17-6
            Console.WriteLine(tpBank2.b);//CH17-6

            foreach (var c in vec1)     
                Console.WriteLine(c);//CH22(list)

            Console.WriteLine(X);//CH26
            #endregion
        }
    }
}

