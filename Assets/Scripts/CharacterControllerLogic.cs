public static class CharacterControllerLogic
{

    // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
    // This can be done using layers instead but Sample Assets will not overwrite your project settings.
    public static bool shouldLandEvent(string[] colliders, bool grounded, string thisName)
    {         
        bool wasGrounded = grounded;       
        bool shouldLand = false;
        for (int i = 0; i < colliders.Length; i++)
        {

            if (colliders[i] != thisName)
            {                
                if (!wasGrounded)
                    shouldLand = true;
            }
        }
        return shouldLand;
    }

    public static bool standCheck(bool crouch, bool obstructed){
       if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (obstructed)
            {
                return crouch = true;
            }
        } 
        return crouch;
    }

}