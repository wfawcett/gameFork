public static class EnemyMovementLogic{
  public static bool shouldDamageHappen(string thisTag, string otherTag, bool isDying ){
        return (thisTag != "ShadowTed" && isDying == false && otherTag == "Player");
    }

  public static bool shouldStompHappen(string thisTag, string otherTag ){
      return thisTag != "ShadowTed" && otherTag == "Player";
  }

  public static bool shouldTurnHappen(bool groundInFrontOfMe, bool shouldAvoidFalling, bool isBlocked){
    if(isBlocked){
      return true;
    }    

    // if I should avoid falling and the ground is gone turn
    if(shouldAvoidFalling && groundInFrontOfMe == false ){
      return true;
    }

    return false;    
  }

}