namespace лаба2_5
{
    internal class Program
    {
        struct MyTime
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
        static int TimeSinceMidnight(MyTime t)
        {
            int seconds = t.hour* 3600 + t.minute*60 + t.second;
            return seconds;
        }
        static MyTime TimeSinceMidnight(int t)
        {
            int seconds = t % 60;
            int minutes = (t / 60) % 60;
            int hours = (t / 3600) % 24;
            return new MyTime(hours, minutes, seconds);
        }
        static MyTime AddOneSecond(MyTime t)
        {
            return new MyTime(t.hour, t.minute, t.second + 1);
        }
        static MyTime AddOneMinute(MyTime t)
        {
            return new MyTime(t.hour, t.minute + 1, t.second);
        }
        static MyTime AddOneHour(MyTime t)
        {
            return new MyTime(t.hour + 1, t.minute, t.second);
        }
        static MyTime AddSeconds(MyTime t, int s)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + s);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введіть час у форматі hh:mm:ss :");
            string[] time = Console.ReadLine().Trim().Split(':');
            if(Convert.ToInt32(time[0])<0 || Convert.ToInt32(time[1])<0 || Convert.ToInt32(time[2])<0)
            {
                Console.WriteLine("Ви ввели час в неправильному форматі, хіба час може бути від'ємним?!");
            }
            else
            {
                MyTime mt = new MyTime(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2]));
                Console.WriteLine("Нормалізований час:" + mt);
                Console.WriteLine("Кількість секунд, що пройшли від початку доби: " + TimeSinceMidnight(mt));
                Console.WriteLine("Кількість секунд, що пройшли від початку доби, у форматі часу: " + TimeSinceMidnight(TimeSinceMidnight(mt)));
                Console.WriteLine("До вашого часу додана одна секунда: " + AddOneSecond(mt));
                Console.WriteLine("До вашого часу додана одна хвилина: " + AddOneMinute(mt));
                Console.WriteLine("До вашого часу додана одна година: " + AddOneHour(mt));
                Console.WriteLine("Введіть кількість секунд яку ви хочете додати до вашого часу,\n або відняти (тоді введіть від'ємне число):");
                int seconds =  int.Parse(Console.ReadLine());
                Console.WriteLine("До вашого часу додано зазначена кількість секунд: " + AddSeconds(mt, seconds));

            }


        }
    }
}