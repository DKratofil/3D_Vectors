using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorLibrary;

namespace VectorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            var a = new Vector3(3, 7, 4);
            var b = new Vector3(2, 9, 11);
            var result = a + b;

            result.X.Should().Be(5);
            result.Y.Should().Be(16);
            result.Z.Should().Be(15);
        }

        [TestMethod]
        public void SubtractTest()
        {
            var a = new Vector3(1, 2, 3);
            var b = new Vector3(3, 3, 3);
            var result = a - b;

            result.X.Should().Be(-2);
            result.Y.Should().Be(-1);
            result.Z.Should().Be(-0);
        }
        [TestMethod]
        public void CrossProduct_Test()
        {
            var a = new Vector3(4, 1, 0);
            var b = new Vector3(-5, 6, 0);
            var result = a.CrossProduct(b);

            result.X.Should().Be(0);
            result.Y.Should().Be(0);
            result.Z.Should().Be(29);
        }

        [TestMethod]
        public void DotProduct_Test()
        {
            var v1 = new Vector3(-10, 0, 0);
            var v2 = new Vector3(1, 0, 0);

            var result = v1.DotProduct(v2);

            result.Should().Be(-10);
        }
        [TestMethod]
        public void Angel_Test()
        {
            var a = new Vector3(1, 0, 0);
            var b = new Vector3(0, 1, 0);
            var angle = a.Angle(b);
            var val = System.Math.PI / 2;
            angle.Should().Be(val);
        }

        [TestMethod]
        public void Equality_Test()
        {
            Vector3 v1 = new Vector3(1, 2, 3);
            Vector3 v2 = new Vector3(1, 2, 3);

            var result = v1 == v2;

            result.Should().Be(true);
        }

        [TestMethod]
        public void Magnitude_Test()
        {
            var vector = new Vector3(0, 0, 0);
            var magnitude = vector.Magnitude;

            magnitude.Should().Be(0);
        }
    }
}
