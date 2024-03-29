﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Util
{
    public class Constants
    {
        // Tiers
        public const int TIER_ONE = 5;
        public const int TIER_TWO = 10;

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

        // Time
        public const double YEAR_IN_DAYS = 365.2425;
        public const double MONTH_IN_DAYS = 30.436875;
        public const int HOUR_OFFSET = 2;

        // UI
        public enum SORT_ORDER { VOTES, FAVORITES, COMMENTS, DATE, USER };
        public const int PAGE_SIZE = 15;
        public const int PAGINATION_SIZE = 25;
    }
}
