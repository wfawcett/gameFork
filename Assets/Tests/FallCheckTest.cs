using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FallCheckTest
    {
        [Test]
        public static void isFarFallIfGroundAndFast(){
            float fallRate = -27;
            bool isFar = FallCheckLogic.farFall("Ground", fallRate);
            Assert.AreEqual(isFar, true);
        }
        [Test]
        public static void isNotFarFallIfNotGround(){
            float fallRate = -27;
            bool isFar = FallCheckLogic.farFall("NotGround", fallRate);
            Assert.AreEqual(isFar, false);
        }
        [Test]
        public static void isNotFarFallIfNotFast(){
            float fallRate = -25;
            bool isFar = FallCheckLogic.farFall("Ground", fallRate);
            Assert.AreEqual(isFar, false);
        }
    } 
}
