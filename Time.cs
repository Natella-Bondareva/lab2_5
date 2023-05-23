namespace лаба2_5
{
    public class Time
    {
        public struct MyTime
        {
            public int hour, minute, second;
            public MyTime(int h, int m, int s)
            {
                if (s % 60 != 0 || (s % 60 == 0 && (s / 60 >= 1 || s / 60 <= -1) ))
                {
                    m += s / 60;
                    s %= 60;
                }
                if (m % 60 != 0 || (m % 60 == 0 && (m / 60 >= 1 || m / 60 <= -1)))
                {
                    h += m / 60;
                    m %= 60;
                }
                if (h > 23 || h<-23)
                {
                    h %= 24;
                }
                hour = h;
                minute = m;
                second = s;
            }
            public override string ToString() => $"{hour:d2}:{minute:d2}:{second:d2}";
        };
        public static int TimeSinceMidnight(MyTime t)
        {
            int seconds = t.hour* 3600 + t.minute*60 + t.second;
            return seconds;
        }
        public static MyTime TimeSinceMidnight(int t)
        {
            int seconds = t % 60;
            int minutes = (t / 60) % 60;
            int hours = (t / 3600) % 24;
            return new MyTime(hours, minutes, seconds);
        }
        public static MyTime AddOneSecond(MyTime t)
        {
            return new MyTime(t.hour, t.minute, t.second + 1);
        }
        public static MyTime AddOneMinute(MyTime t)
        {
            return new MyTime(t.hour, t.minute + 1, t.second);
        }
        public static MyTime AddOneHour(MyTime t)
        {
            return new MyTime(t.hour + 1, t.minute, t.second);
        }
        public static MyTime AddSeconds(MyTime t, int s)
        {
            int res = TimeSinceMidnight(t) + s;
            Console.WriteLine("Проміжний результат: " + TimeSinceMidnight(res));
            if (res < 0)
            {
                while (res < 0)
                {
                    res = 86400 + res;
                }
            }
            return TimeSinceMidnight(res);
        }
        public static int Difference(MyTime mt1, MyTime mt2)
        {
            int res = TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);
            return res;
        }
        public static string WhatLesson(MyTime mt)
        {
            int timeInSec = TimeSinceMidnight(mt);
            if (timeInSec < TimeSinceMidnight(new MyTime(8, 0, 0)))
            {
                return "пари ще не почалися";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(8, 0, 0)) &&
               timeInSec < TimeSinceMidnight(new MyTime(9, 20, 0)))
            {
                return "1-а пара";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(9, 20, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(9, 40, 0)))
            {
                return "перерва між 1-ю та 2-ю парами";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(9, 40, 0)) &&
               timeInSec < TimeSinceMidnight(new MyTime(11, 0, 0)))
            {
                return "2-а пара";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(11, 0, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(11, 20, 0)))
            {
                return "перерва між 2-ю та 3-ю парою";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(11, 20, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(12, 40, 0)))
            {
                return "3-а пара";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(12, 40, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(13, 0, 0)))
            {
                return "перерва між 3-ю та 4-ю парою";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(13, 0, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(14, 20, 0)))
            {
                return "4-а пара";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(14, 20, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(14, 40, 0)))
            {
                return "перерва між 4-ю та 5-ю парою";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(14, 40, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(16, 00, 0)))
            {
                return "5-а пара";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(16, 0, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(16, 20, 0)))
            {
                return "перерва між 5-ю та 6-ю парою";
            }

            if (timeInSec >= TimeSinceMidnight(new MyTime(16, 20, 0)) &&
                timeInSec < TimeSinceMidnight(new MyTime(17, 40, 0)))
            {
                return "6-а пара";
            }

            return "пари вже скінчилися";
        }
        public static void Main(string[] args)
        {            
            Console.WriteLine("Введіть час у форматі hh:mm:ss :");
            MyTime mt1 = new MyTime(0,0,0);
            Input(ref mt1);
            Console.WriteLine("Нормалізований час:" + mt1);
            Console.WriteLine("Кількість секунд, що пройшли від початку доби: " + TimeSinceMidnight(mt1));
            Console.WriteLine("Кількість секунд, що пройшли від початку доби, у форматі часу: " + TimeSinceMidnight(TimeSinceMidnight(mt1)));
            Console.WriteLine("До вашого часу додана одна секунда: " + AddOneSecond(mt1));
            Console.WriteLine("До вашого часу додана одна хвилина: " + AddOneMinute(mt1));
            Console.WriteLine("До вашого часу додана одна година: " + AddOneHour(mt1));
            Console.WriteLine("Введіть кількість секунд яку ви хочете додати до вашого часу,\n " +
                "або відняти (тоді введіть від'ємне число):");
            int seconds =  int.Parse(Console.ReadLine());
            Console.WriteLine("До вашого часу додано зазначена кількість секунд: " + AddSeconds(mt1, seconds));
            Console.WriteLine("Введіть час, який буде віднято від початкового часу:");
            MyTime mt2 = new MyTime(0, 0, 0);
            Input(ref mt2);
            Console.WriteLine($"Різницю між двома моментами у секундах: {Difference(mt1, mt2)} і у вигляді часу: " +
                $"{TimeSinceMidnight(Difference(mt1, mt2))}");
            MyTime SystemTime = new MyTime(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            Console.WriteLine("Системний час: " + SystemTime);
            Console.WriteLine("Різниця з системним часом: " + TimeSinceMidnight(Difference(mt1, SystemTime)));
            Console.WriteLine("Тепер визначимо за розкладом, на яку пару потрапляє ваш початковий час:");
            Console.WriteLine(WhatLesson(mt1)); 
        }
        public static void Input(ref MyTime mt)
        {
            bool b = true;
            while(b) 
            { 
                string[] time = Console.ReadLine().Trim().Split(':');
                if (Convert.ToInt32(time[0]) < 0 || Convert.ToInt32(time[1]) < 0 || Convert.ToInt32(time[2]) < 0)
                {
                    Console.WriteLine("Ви ввели час в неправильному форматі, хіба час може бути від'ємним?!\n Спробуйте ще раз =)");
                }
                else
                {
                    mt = new MyTime(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2]));
                    b = false;
                }
            }
        }
    }
}