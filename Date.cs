using System;

public class Date
{
    public int year;
    public int month;
    public int day;
    MaxDaysInMonth maxDaysInMonth = new MaxDaysInMonth();
    /////
    public Date(String date) {
        try {
            month = Int32.Parse(date.Substring(0,2));
            day = Int32.Parse(date.Substring(3,2));
            year = Int32.Parse(date.Substring(6,4));
        }
        catch {
            throw new ArgumentException("Invalid Date Entered");
        }
    }

    public bool validate()
    {
        bool isValid = true;
        if (year < 1900 || year > 2025)
        {
            Console.WriteLine("Value of year not in the range 1900...2025");
            isValid = false;
        }
        //basic range check of valid months
        if (month < 1 || month > 12)
        {
            Console.WriteLine("Value of month not in the range 1...12");
            isValid = false;
        }
        //basic range check of valid days
        int daysInMonth = maxDaysInMonth.getDaysInMonth(month, year);
        if (day < 1 || day > daysInMonth)
        {
            Console.WriteLine("Value of day not in the range 1..." + daysInMonth);
            isValid = false;
        }
        return isValid;
    }

    public String toString() 
    {
        String dateString = "";
        if (month < 10)
            dateString += "0" + month.ToString();
        else
            dateString += month.ToString();
        dateString += "/";
        if (day < 10)
            dateString += "0" + day.ToString();
        else
            dateString += day.ToString();
        dateString += "/" + year.ToString();
        return dateString;
    }

    public String getNext()
    {
        Date nextDate = this;
        nextDate.day++;
        if (!nextDate.validate())
        {
            nextDate.day = 1;
            nextDate.month++;
            if (!nextDate.validate())
            {
                nextDate.month = 1;
                nextDate.year++;
            }
        }
        return nextDate.toString();
    }
}