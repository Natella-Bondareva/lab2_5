namespace лаба2_5
{
    internal class Program
    {
        struct MyTime
        {
            public int hour, minute, second;
            public MyTime(int h, int m, int s)
            {
                if (s % 60 != 0 || (s % 60 == 0 && s / 60 >= 1))
                {
                    m += s / 60;
                    s %= 60;
                }
                if (m % 60 != 0 || (m % 60 == 0 && m / 60 >= 1))
                {
                    h += m / 60;
                    m %= 60;
                }
                if (h > 23)
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
        //static MyTime TimeSinceMidnight(int t)
        //{

        //}
        static MyTime AddOneSecond(MyTime t)
        {
            return new MyTime(t.hour, t.minute, t.second + 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть час у форматі hh:mm:ss :");
            string[] time = Console.ReadLine().Trim().Split(':');
            MyTime mt = new MyTime(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2]));
            Console.WriteLine(TimeSinceMidnight(mt));
            Console.WriteLine(AddOneSecond(mt));

        }
    }
}