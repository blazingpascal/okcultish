using System;

namespace AssemblyCSharp
{
	public class UserProfile
	{
		private User user;

		private UserProfile ()
		{
			
		}

        public User User
        {
            get
            {
                return user;
            }
        }
    }
}

