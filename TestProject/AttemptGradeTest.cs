using TubesKPL;
using LoginAPI;

namespace TestProject
{
    [TestClass]
    public sealed class AttemptGradeTest
    {
        [TestMethod]
        public void TestGetGradeA()
        {
            Assert.AreEqual("A", TubesKPL.AttemptsService.GetGradeByScore(81));
        }
        [TestMethod]
        public void TestGetGradeAB()
        {
            Assert.AreEqual("AB", TubesKPL.AttemptsService.GetGradeByScore(71));
        }
        [TestMethod]
        public void TestGetGradeB()
        {
            Assert.AreEqual("B", TubesKPL.AttemptsService.GetGradeByScore(66));
        }
        [TestMethod]
        public void TestGetGradeBC()
        {
            Assert.AreEqual("BC", TubesKPL.AttemptsService.GetGradeByScore(61));
        }
        [TestMethod]
        public void TestGetGradeC()
        {
            Assert.AreEqual("C", TubesKPL.AttemptsService.GetGradeByScore(51));
        }
        [TestMethod]
        public void TestGetGradeD()
        {
            Assert.AreEqual("D", TubesKPL.AttemptsService.GetGradeByScore(41));
        }
        [TestMethod]
        public void TestGetGradeE()
        {
            Assert.AreEqual("E", TubesKPL.AttemptsService.GetGradeByScore(0));
        }
    }
}
