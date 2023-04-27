using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarAppTests
{
    [TestClass]
    public class AssemblyHandler
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context) 
        {
            context.WriteLine("Assembly init");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup() 
        {
            
        }
    }
}
