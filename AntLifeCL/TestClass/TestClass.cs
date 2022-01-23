namespace SZAntLifeCL.TestClass
{
    public class TestClass
    {
        public int TestClassId { get; set; }
        public string TestClassName { get; set; }
        public TestClass()
        {

        }
        public TestClass(int id, string name)
        {
            TestClassId = id;
            TestClassName = name;
        }
    }
}
