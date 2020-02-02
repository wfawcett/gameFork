using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CharacterControllerLogicTest
    {
        #region shouldLandEvent
        [Test]
        public void shouldLandWhenColliderNotSelf()
        {
            string[] colliders = {"one", "two", "three"};
            bool shouldLandEvent = CharacterControllerLogic.shouldLandEvent(colliders, false, "four");
            Assert.AreEqual(shouldLandEvent, true);
        }

        [Test]
        public void shouldNotLandWhenColliderSelf()
        {
            string[] colliders = {"one", "two", "three", "four"};
            bool shouldLandEvent = CharacterControllerLogic.shouldLandEvent(colliders, false, "four");
            Assert.AreEqual(shouldLandEvent, true);
        }

        [Test]
        public void shouldNotLandWhenAlreadGrounded()
        {
            string[] colliders = {"one", "two", "three"};
            bool shouldLandEvent = CharacterControllerLogic.shouldLandEvent(colliders, true, "four");
            Assert.AreEqual(shouldLandEvent, false);
        }
        #endregion 

        #region standCheck
        [Test]
        public void shouldStandCheckTrueWhenCrouchingAndObstructed(){
          bool crouch = true;
          crouch = CharacterControllerLogic.standCheck(crouch, true);
          Assert.AreEqual(crouch, true);
        }

        [Test]
        public void shouldStandCheckTrueWhenCrouchingNotObstructed(){
          bool crouch = true;
          crouch = CharacterControllerLogic.standCheck(crouch, false);
          Assert.AreEqual(crouch, true);
        }

        [Test]
        public void shouldStandCheckTrueWhenNotCrouchingNotObstructed(){
          bool crouch = false;
          crouch = CharacterControllerLogic.standCheck(crouch, false);
          Assert.AreEqual(crouch, false);
        }

        public void shouldStandCheckTrueWhenNotCrouchingAndObstructed(){
          bool crouch = false;
          crouch = CharacterControllerLogic.standCheck(crouch, true);
          Assert.AreEqual(crouch, false);
        }
        #endregion

       
    }
}
