using Autofac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest
{
    public interface TestInterface
    {
        string GetValue();
    }

    public class TestImplementation1 : TestInterface
    {
        public string GetValue()
        {
            return "TestImplementation1";
        }
    }

    public class TestImplementation2 : TestInterface
    {
        public string GetValue()
        {
            return "TestImplementation2";
        }
    }



    [TestFixture]
    public class Tests
    {
        [Test]
        public void NestedContainersWithInitOverride()
        {
            // Latest version of autofac doesn't have the nested container with lambda initialization bug I saw.
            var builder = new ContainerBuilder();
            builder.RegisterType<TestImplementation1>().As<TestInterface>();
            using (var container = builder.Build())
            {
                var fromParent = container.Resolve<TestInterface>();
                Assert.AreEqual("TestImplementation1", fromParent.GetValue());

                using (var scope = container.BeginLifetimeScope(b => b.RegisterType<TestImplementation2>().As<TestInterface>()))
                {
                    var fromScope = scope.Resolve<TestInterface>();

                    Assert.AreEqual("TestImplementation2", fromScope.GetValue());
                }

                fromParent = container.Resolve<TestInterface>();
                Assert.AreEqual("TestImplementation1", fromParent.GetValue());

            }
        }

        [Test]
        public void Lambda1()
        {
            Func<int,int> myLambda = (x => x * 2);

            var result1 = myLambda(3);
            var result2 = myLambda.Invoke(4);
        }
    }
}
