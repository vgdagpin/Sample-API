using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TestProj
{
    [Serializable]
    public class TestProjException : Exception
    {
        public TestProjException()
        {

        }

        public TestProjException(string message)
            : base(message)
        {

        }

        protected TestProjException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
