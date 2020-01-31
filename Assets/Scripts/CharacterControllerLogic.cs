public static class CharacterControllerLogic
{

    // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
    // This can be done using layers instead but Sample Assets will not overwrite your project settings.
    public static boolean shouldLandEvent(Collider2D[] colliders)
    {
        bool wasGrounded = m_Grounded;
        bool m_Grounded = false;
        bool shouldLand = false;
        for (int i = 0; i < colliders.Length; i++)
        {

            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    shouldLand = true;
            }
        }
        return shouldLand;
    }

}