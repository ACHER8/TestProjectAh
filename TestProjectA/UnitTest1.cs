using SF2022User01Lib;

namespace TestProjectA
{
    public class Tests
    {

        Calculations calculations;

        [SetUp]
        public void Setup()
        {
            calculations = new Calculations();
        }

        [Test]
        public void Comparison_Of_Input_Data_With_Output()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10,0,0), new TimeSpan(11,0,0), new TimeSpan(15,0,0), new TimeSpan(15,30,0), new TimeSpan(16,50,0)};
            int[] durations = new int[] { 60, 30,10,10,40 };
            TimeSpan beginWorkingTime = new TimeSpan (8,0,0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;

            var result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            string[] strings = new string[] {   "08:00 - 08:30",
                                                "08:30 - 09:00",
                                                "09:00 - 09:30",
                                                "09:30 - 10:00",
                                                "11:30 - 12:00",
                                                "12:00 - 12:30",
                                                "12:30 - 13:00",
                                                "13:00 - 13:30",
                                                "13:30 - 14:00",
                                                "14:00 - 14:30",
                                                "14:30 - 15:00",
                                                "15:40 - 16:10",
                                                "16:10 - 16:40",
                                                "17:30 - 18:00"};

            Assert.AreEqual(result, strings);
        }

        [Test]
        public void Comparing_The_Result_When_Changing_Duration()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0),  new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 50, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;

            var result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            string[] strings = new string[] {   "08:00 - 08:30",
                                                "08:30 - 09:00",
                                                "09:00 - 09:30",
                                                "09:30 - 10:00",
                                                "11:30 - 12:00",
                                                "12:00 - 12:30",
                                                "12:30 - 13:00",
                                                "13:00 - 13:30",
                                                "13:30 - 14:00",
                                                "14:00 - 14:30",
                                                "14:30 - 15:00",
                                                "15:50 - 16:20",
                                                "16:20 - 16:50",
                                                "17:30 - 18:00"};

            Assert.AreEqual(result, strings);//
        }

        [Test]
        public void Inequality_Test()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 40;

            var result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            string[] strings = new string[] {   "08:00 - 08:30",
                                                "08:30 - 09:00",
                                                "09:00 - 09:30",
                                                "09:30 - 10:00",
                                                "11:30 - 12:00",
                                                "12:00 - 12:30",
                                                "12:30 - 13:00",
                                                "13:00 - 13:30",
                                                "13:30 - 14:00",
                                                "14:00 - 14:30",
                                                "14:30 - 15:00",
                                                "15:40 - 16:10",
                                                "16:10 - 16:40",
                                                "17:30 - 18:00"};

            Assert.AreNotEqual(result, strings);
        }

        [Test]
        public void Exception_Confirmation()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 50, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(7, 0, 0);
            int consultationTime = 30;

            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void Test_Result_Is_Not_Null()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;

            var result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Exception_Negativ_Number()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = -30;

            Assert.Throws<ArgumentException>(()=> calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void Exception_Mismatch_Quantity_StartTimes_Durations()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;

            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }

        [Test]
        public void Variables_Refer_To_Different_Object()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;

            var result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            string[] strings = new string[] {   "08:00 - 08:30",
                                                "08:30 - 09:00",
                                                "09:00 - 09:30",
                                                "09:30 - 10:00",
                                                "11:30 - 12:00",
                                                "12:00 - 12:30",
                                                "12:30 - 13:00",
                                                "13:00 - 13:30",
                                                "13:30 - 14:00",
                                                "14:00 - 14:30",
                                                "14:30 - 15:00",
                                                "15:40 - 16:10",
                                                "16:10 - 16:40",
                                                "17:30 - 18:00"};

            Assert.AreNotSame(result, strings);
        }

       

    }
}