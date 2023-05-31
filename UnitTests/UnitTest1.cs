using LAB_5;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void IntegerPartWithoutFrac()
        {
            Program.MyFrac frac = new Program.MyFrac(21,7);           
            string expected = "3";

            string actual = Program.ToStringWithIntegerPart(frac);

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void NegativeIntegerPart()
        {
            Program.MyFrac frac = new Program.MyFrac(-14,4);
            string expected = "-(3 + 2/4)";

            string actual = Program.ToStringWithIntegerPart(frac);

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void WithoutInegerPart() 
        {
            Program.MyFrac frac = new Program.MyFrac(2, 10);
            string expected = "2/10";

            string actual = Program.ToStringWithIntegerPart(frac);

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }        
        [TestMethod]
        public void NegativeDoubleValue()
        {
            Program.MyFrac frac = new Program.MyFrac(-5, 2);
            double expected = -2.5;

            double actual = Program.DoubleValue(frac);

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }        
        [TestMethod]
        public void SmallDoubleValue()
        {
            Program.MyFrac frac = new Program.MyFrac(13, 29);
            double expected = 0.4482758620689655;

            double actual = Program.DoubleValue(frac);

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void SumOfNegativeAndPostiveNumbers()
        {
            Program.MyFrac frac1 = new Program.MyFrac(4, 5);
            Program.MyFrac frac2 = new Program.MyFrac(-3, 5);

            string expected = "1/5";

            string actual = Program.Plus(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void SumOfNegativeNumbers()
        {
            Program.MyFrac frac1 = new Program.MyFrac(-4, 12);
            Program.MyFrac frac2 = new Program.MyFrac(-6, 12);

            string expected = "-5/6";

            string actual = Program.Plus(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void SubstractionOfTwoEqualNumbers()
        {
            Program.MyFrac frac1 = new Program.MyFrac(1, 5);
            Program.MyFrac frac2 = new Program.MyFrac(1, 5);

            string expected = "0";

            string actual = Program.Minus(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void SubstractionOfNegativeAndPositiveNumbers_1()
        {
            Program.MyFrac frac1 = new Program.MyFrac(5, 20);
            Program.MyFrac frac2 = new Program.MyFrac(-6, 20);

            string expected = "11/20";

            string actual = Program.Minus(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void SubstractionOfNegativeAndPositiveNumbers_2()
        {
            Program.MyFrac frac1 = new Program.MyFrac(-5, 20);
            Program.MyFrac frac2 = new Program.MyFrac(6, 20);

            string expected = "-11/20";

            string actual = Program.Minus(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void SubstractionOfNegativeNumbers()
        {
            Program.MyFrac frac1 = new Program.MyFrac(-5, 20);
            Program.MyFrac frac2 = new Program.MyFrac(-6, 20);

            string expected = "1/20";

            string actual = Program.Minus(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void MultiplicationOfNegativeNumbers()
        {
            Program.MyFrac frac1 = new Program.MyFrac(-5, 10);
            Program.MyFrac frac2 = new Program.MyFrac(-6, 10);

            string expected = "3/10";

            string actual = Program.Multiply(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void MultiplicationOfNegativeAndPositiveNumbers_1()
        {
            Program.MyFrac frac1 = new Program.MyFrac(-5, 10);
            Program.MyFrac frac2 = new Program.MyFrac(6, 10);

            string expected = "-3/10";

            string actual = Program.Multiply(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void MultiplicationOfNegativeAndPositiveNumbers_2()
        {
            Program.MyFrac frac1 = new Program.MyFrac(3, 5);
            Program.MyFrac frac2 = new Program.MyFrac(-6, 10);

            string expected = "-9/25";

            string actual = Program.Multiply(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void DivisionOfNegativeNumbers()
        {
            Program.MyFrac frac1 = new Program.MyFrac(-5, 10);
            Program.MyFrac frac2 = new Program.MyFrac(-6, 10);

            string expected = "5/6";

            string actual = Program.Divide(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void DivisionOfNegativeAndPositiveNumbers_1()
        {
            Program.MyFrac frac1 = new Program.MyFrac(-5, 10);
            Program.MyFrac frac2 = new Program.MyFrac(6, 10);

            string expected = "-5/6";

            string actual = Program.Divide(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void DivisionOfNegativeAndPositiveNumbers_2()
        {
            Program.MyFrac frac1 = new Program.MyFrac(3, 5);
            Program.MyFrac frac2 = new Program.MyFrac(-6, 10);

            string expected = "-1";

            string actual = Program.Divide(frac1, frac2).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void Formula_1()
        {
            string expected = "3/4";

            string actual = Program.CalcSum1(3).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
        [TestMethod]
        public void Formula_2()
        {
            string expected = "2/3";

            string actual = Program.CalcSum2(3).ToString();

            Assert.AreEqual(expected, actual, "Program is messed up :)");
        }
    }
}