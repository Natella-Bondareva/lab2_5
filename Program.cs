namespace лаба2_5
{
    internal class Program
    {
        struct MyTime
        {
            public int hour, minute, second;
            public MyTime(int h, int m, int s)
            {
                hour = h;
                minute = m;
                second = s;
                if (hour<0)
                {
                    hour *= -1;

                }
                if (second % 60 != 0 || (second % 60 == 0 && (second / 60 >= 1 || second / 60 <= -1) ))
                {
                    minute += second / 60;
                    second %= 60;
                }
                if (minute % 60 != 0 || (minute % 60 == 0 && (minute / 60 >= 1 || minute / 60 <= -1)))
                {
                    
                    hour += minute / 60;
                    minute %= 60;
                }
                if (hour > 23 || hour<-23)
                {
                    hour %= 24;
                }
                if(h<0)
                {
                    hour *= -1;
                }
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