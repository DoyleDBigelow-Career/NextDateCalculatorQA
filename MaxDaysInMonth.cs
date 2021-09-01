using System;

public class MaxDaysInMonth
{
    public int getDaysInMonth(int month, int year)
    {
        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            case 2:
                return calcMaxFebDays(year);
            default:
                return 0;
        }
    }
    public int calcMaxFebDays(int year)
    {
        bool isLeapYear = false;
        //if leap year
        if (year % 4 == 0)
        {
            //if century year
            if (year % 100 == 0)
            {
                //if 400 year century
                if (year % 400 ==0)
                {
                    isLeapYear = true;
                }
                else
                {
                    isLeapYear = false;
                }
            }
            else
            {
                isLeapYear = true;
            }
        }
        if (isLeapYear)
        {
            return 29;
        }
        else
        {
            return 28;
        }
    }
}