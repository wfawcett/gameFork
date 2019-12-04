using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ExtensionMethodsTests
    {
        [Test]

        public void ExtensionMethods_CreatesNewVector2()
        {
            var vector3 = new Vector3(2f, 3f);
            var vector2 = vector3.toVector2();

            Assert.AreEqual(vector2.x, vector3.x);
            Assert.AreEqual(vector2.y, vector3.y);
        }
    }
}
