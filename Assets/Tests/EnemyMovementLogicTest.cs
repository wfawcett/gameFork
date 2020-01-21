using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemyMovementLogicTest
    {
        [Test]

        public void EnemyMovementLogic_shouldDamage()
        {
            bool isDying = false;
            bool shouldDamage = EnemyMovementLogic.shouldDamageHappen("NotShadowTed", "Player", isDying);
            Assert.AreEqual(shouldDamage, true);
        }

        [Test]
        public void EnemyMovementLogic_shouldNotDamageShadowTed()
        {
            bool isDying = false;
            bool shouldDamage = EnemyMovementLogic.shouldDamageHappen("ShadowTed", "Player", isDying);
            Assert.AreEqual(shouldDamage, false);
        }

        [Test]
        public void EnemyMovementLogic_shouldNotDamageIfNotPlayer()
        {
            bool isDying = false;
            bool shouldDamage = EnemyMovementLogic.shouldDamageHappen("NotShadowTed", "NotPlayer", isDying);
            Assert.AreEqual(shouldDamage, false);
        }

        [Test]
        public void EnemyMovementLogic_shouldTurnIfCliff()
        {
            bool groundInFrontOfMe = false;
            bool avoidFalling = true;
            bool isBlocked = false;
            bool shouldTurn = EnemyMovementLogic.shouldTurnHappen(groundInFrontOfMe, avoidFalling, isBlocked);
            Assert.AreEqual(shouldTurn, true);
        }

        [Test]
        public void EnemyMovementLogic_shouldNotTurnIfCliffButNotAvoidFalling()
        {
            bool groundInFrontOfMe = true;
            bool avoidFalling = false;
            bool isBlocked = false;
            bool shouldTurn = EnemyMovementLogic.shouldTurnHappen(groundInFrontOfMe, avoidFalling, isBlocked);
            Assert.AreEqual(shouldTurn, false);
        }

        
        [Test]
        public void EnemyMovementLogic_shouldTurnIfBlocked()
        {
            bool cliffAproaching = false;
            bool avoidFalling = true;
            bool isBlocked = true;
            bool shouldTurn = EnemyMovementLogic.shouldTurnHappen(cliffAproaching, avoidFalling, isBlocked);
            Assert.AreEqual(shouldTurn, true);
        }
    }
}
