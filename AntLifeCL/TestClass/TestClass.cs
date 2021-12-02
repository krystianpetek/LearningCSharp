using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntLifeCL.TestClass
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
