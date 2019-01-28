using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Schedule
    {
        class week
        {
            public bool[][] schedule;
            public DateTime first_Day;
            public DateTime First_Day { get => first_Day; set => first_Day = first_day_of_week(value); }

            public week(week c)
            {
                first_Day = c.first_Day;
                schedule = new bool[5][];
                for (int i = 0; i < 5; i++)
                {
                    schedule[i] = new bool[6];
                    for (int j = 0; j < 6; j++)
                        schedule[i][j] = c.schedule[i][j];
                }
            }

            public week(bool[][] schedule, DateTime first_Day)
            {
                First_Day = first_Day;
                this.schedule = new bool[5][];
                for (int i = 0; i < 5; i++)
                {
                    this.schedule[i] = new bool[6];
                    for (int j = 0; j < 6; j++)
                        this.schedule[i][j] = false;
                }
            }

            public week(string weekstring)
            {
                try
                {

                string[] arr = weekstring.Split(',');
                int counter = 0;
                First_Day = new DateTime();
                First_Day = DateTime.Parse(arr[counter]);
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        counter++;
                        schedule[i][j] = bool.Parse(arr[counter]);
                    }
                }
                }
                catch (Exception)
                {

                    throw new Exception("the string not valid");
                }
            }

            public override string ToString()
            {
                string ret = "";
                ret += first_Day.ToString() + ',';
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                        ret += schedule[i][j].ToString() + ',';
                }
                return ret;
            }

            public void AddTest(int day, int hour)
            {
                if (day < 0 || day > 4)
                    throw new Exception("the day must be between sunday to thursday");
                hour -= 9;
                if (hour < 0 || hour > 5)
                    throw new Exception("the hour must be between 9:00 to 14:00");
                if (schedule[day][hour])
                    throw new Exception("there is already test in this hour");
                schedule[day][hour] = true;

            }

            public void RemoveTest(int day, int hour)
            {
                if (day < 0 || day > 4)
                    throw new Exception("this test dont exist");
                hour -= 9;
                if (hour < 0 || hour > 5)
                    throw new Exception("this test dont exist");
                if (!schedule[day][hour])
                    throw new Exception("this test dont exist");
                schedule[day][hour] = false;
            }

            public static DateTime first_day_of_week(DateTime value)
            {
                int day = value.Day;
                int year = value.Year;
                int month = value.Month;
                //if the day isn't sunday correct him
                if (value.DayOfWeek != DayOfWeek.Sunday)
                {
                    day -= (int)value.DayOfWeek;
                    if (day < 1)
                    {
                        month--;
                        if (month < 1)
                        {
                            year--;
                            month = 1;
                        }
                        //Initializing the day to the last sunday of the month
                        DateTime temp = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                        day = temp.Day - (int)temp.DayOfWeek;
                    }
                }
                return new DateTime(year, month, day);
            }

            public int TestsInWeek()
            {
                int counter = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (schedule[i][j])
                            counter++;
                    }
                }
                return counter;
            }

        }



        List<week> weeks;
        bool[][] schedule;
        public bool[][] _Schedule { get => schedule; set => schedule = value; }

        //ctor
        public Schedule(bool[][] schedule)
        {
            weeks = new List<week>();
            this.schedule = new bool[5][];
            for (int i = 0; i < 5; i++)
            {
                this.schedule[i] = new bool[6];
                for (int j = 0; j < 6; j++)
                    this.schedule[i][j] = schedule[i][j];
            }
        }
        public Schedule(Schedule c)
        {
            weeks = new List<week>(c.weeks);
            schedule = new bool[5][];
            for (int i = 0; i < 5; i++)
            {
                schedule[i] = new bool[6];
                for (int j = 0; j < 6; j++)
                    schedule[i][j] = c.schedule[i][j];
            }
        }
        public Schedule(string schedulestring )
        {
            try
            {
                weeks = new List<week>();
                string[] arr = schedulestring.Split('+');
                string[] innerarr = arr[0].Split(',');
                int counter = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        schedule[i][j] = bool.Parse(innerarr[counter]);
                        counter++;
                    }
                }
                counter = 0;
                foreach (var item in arr)
                {
                    if (counter == 0)
                        continue;
                    counter++;
                    weeks.Add(new week(item));
                }
            }
            catch (Exception)
            {

                throw new Exception("the string not valid");
            }
        }
        //funcs
        public override string ToString()
        {
            
            string result = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                    result += schedule[i][j].ToString()+',';
            }

            foreach (var item in weeks)
            {
                result += '+' + item.ToString();
            }
            return result;
        }
        public void AddHourToSchedule(DayOfWeek day, int hour)
        {
            if ((int)day < 0 || (int)day > 4)
                throw new Exception("the day must be between sunday to thursday");
            hour -= 9;
            if (hour < 0 || hour > 5)
                throw new Exception("the hour must be between 9:00 to 14:00");
            schedule[(int)day][hour] = true;
        }
        public void RemoveHourFromSchedule(DayOfWeek day, int hour)
        {
            if ((int)day < 0 || (int)day > 4)
                throw new Exception("the day must be between sunday to thursday");
            hour -= 9;
            if (hour < 0 || hour > 5)
                throw new Exception("the hour must be between 9:00 to 14:00");
            schedule[(int)day][hour] = false;
        }
        public void AddTest(DateTime d)
        {
            DayOfWeek day = d.DayOfWeek;
            int hour = d.Hour;
            if ((int)day < 0 || (int)day > 4)
                throw new Exception("the day must be between sunday to thursday");
            hour -= 9;
            if (hour < 0 || hour > 5)
                throw new Exception("the hour must be between 9:00 to 14:00");
            if (schedule[(int)day][hour] == false)
                throw new Exception("the tester dont work in this hours");
            //search if the schedule to this week already exist or create him
            week current = weeks.Find(w => week.first_day_of_week(d) == w.First_Day);

            if (current == null)
            {
                current = new week(schedule, d);
            }

            //add the test 
            try
            {
                current.AddTest((int)d.DayOfWeek, d.Hour);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RemoveTest(DateTime d)
        {
            DayOfWeek day = d.DayOfWeek;
            int hour = d.Hour;
            if ((int)day < 0 || (int)day > 4)
                throw new Exception("the day must be between sunday to thursday");
            hour -= 9;
            if (hour < 0 || hour > 5)
                throw new Exception("the hour must be between 9:00 to 14:00");

            //search the schedule to this week
            week current = weeks.Find(w => week.first_day_of_week(d) == w.First_Day);

            if (current == null)
            {
                throw new Exception("this test dont exist");
            }

            //remove the test 
            try
            {
                current.AddTest((int)d.DayOfWeek, d.Hour);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool RightTime(DateTime d)//return true if the tester can work in this hour
        {

            DayOfWeek day = d.DayOfWeek;
            int hour = d.Hour;
            if ((int)day < 0 || (int)day > 4)
                return false;
            hour -= 9;
            if (hour < 0 || hour > 5)
                return false;
            if (schedule[(int)day][hour] == false)
                return false;
            // search the schedule to this week
            week current = weeks.Find(w => week.first_day_of_week(d) == w.First_Day);

            //check if the tester busy
            if (current == null)
                return true;
            if (current.schedule[(int)day][hour] == true)
                return false;

            return true;
        }
        public bool[][] GetWeekSchedule(DateTime d)
        {
            bool[][] ret;
            ret = new bool[5][];
            for (int i = 0; i < 5; i++)
            {
                ret[i] = new bool[6];
                for (int j = 0; j < 6; j++)
                    ret[i][j] = false;
            }
            //search the schedule to this week
            week current = weeks.Find(w => week.first_day_of_week(d) == w.First_Day);
            if (current == null)
                return ret;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                    ret[i][j] = current.schedule[i][j];
            }

            return ret;
        }
        public int TestsInWeek(DateTime d)//return how many test he test in a specific week
        {
            week current = weeks.Find(w => week.first_day_of_week(d) == w.First_Day);
            if (current == null)
                return 0;
            return current.TestsInWeek();
        }

    }
}
