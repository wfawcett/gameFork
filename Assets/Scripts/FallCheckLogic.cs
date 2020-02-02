public static class FallCheckLogic{

    public static bool farFall(string gameObjectTag, float fallVelocity){
        if(gameObjectTag.Equals("Ground") && fallVelocity < -26){
            return true;
        }else{
            return false;
        }
    }
}

