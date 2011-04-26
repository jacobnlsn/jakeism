using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Util
{
    public class Constants
    {
        // Tiers
        public const int TIER_ONE = 10;
        public const int TIER_TWO = 20;

        // Email
        public const string SMTP_SERVER = "mail.clarionmediadev.com";
        public const string FEEDBACK_EMAIL = "ttreat31@gmail.com";
        public const string CREDENTIALS_USERNAME = "jakeism@clarionmediadev.com";
        public const string CREDENTIALS_PASSWORD = "jpostmaster1";

        // Encryption
        public const string HASH = "SHA1";
        public const int SALT_SIZE = 16;

        // Comments
        public const bool ADMIN_COMMENTS = false;
    }
}
