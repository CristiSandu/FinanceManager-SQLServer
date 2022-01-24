namespace FinanceManagerAPI.Helper
{
    public static class HelperMethods
    {
        public static List<DateTime> GetLastXMonths(int months_number)
        {
            DateTime currentDate = DateTime.Now;

            List<DateTime> dates = new();
            for (int i = 0; i < months_number; i++)
            {
                dates.Add(new DateTime(currentDate.Year, currentDate.Month, 1));
                currentDate = currentDate.AddMonths(-1);
            }

            return dates;
        }

        public static List<DateTime> GetLastXYears(int year_number)
        {
            DateTime currentDate = DateTime.Now;

            List<DateTime> dates = new();
            for (int i = 0; i < year_number; i++)
            {
                dates.Add(new DateTime(currentDate.Year, 1, 1));
                currentDate = currentDate.AddYears(-1);
            }

            return dates;
        }
    }
}
