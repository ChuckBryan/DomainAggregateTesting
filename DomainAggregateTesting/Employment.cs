namespace DomainAggregateTesting
{
    using System;
    using NodaTime;
    /*
     * This is an example of using an Employment Aggregate.
     *
     */
    public class Employment
    {
        public Employment(int employeeId, int employerId, LocalDate dateOfHire)
        {
            EmployeeId = employeeId;
            EmployerId = employerId;
            DateOfHire = new DateOfHire(dateOfHire);
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public int EmployeeId { get; private set; }

        public int EmployerId { get; private set; }

        public DateOfHire DateOfHire { get; }

        
        public bool AtLeastOneYear()
        {
            return DateOfHire.NumberOfMonths() >= 12;
        }
    }

    /*
     * Date of Hire is a value class. It is using the Noda Date Library that has a "Loa
     */
    public class DateOfHire
    {
        public DateOfHire(LocalDate date)
        {
            Date = date;
        }

        public LocalDate Date { get; }

        // The value class performs calculations on the internal state. This way
        // You can compose
        public long NumberOfMonths()
        {
            var period = Period.Between(Date, new LocalDate());
            return period.Months;
        }

    }

    
    



    /*
     I make 24,000 per year
     I make 7.15 hourly
     we need to convert this to a gross monthly income....
        Annual: Gross Income
         Hourly: 
         */

    public enum PayType
    {
        Hourly,
        Annual
    }
    public enum PayCycle
    {
        Weekly, // 52 Pay Periods Per Year
        BiWeekly, // 26 Pay Periods Per Year
        TwiceAMonth, // 24 Pay Periods Per Year
        Monthly // 12 Pay Periods Per Year

    }
}