﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Maropost.Api
{
    public class Campaigns : _BaseApi
    {
        public Campaigns(int accountId, string authToken)
            :base(accountId, authToken, "campaigns")
        { }
    }
}