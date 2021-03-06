﻿using Go_Holiday_2._0.Models;
using ModelsView_Views = Go_Holiday_2._0.Models.ModelsView.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Utils.Session
{
    public interface ISessionManager
    {
        int UserID { get; set; }
        int TypeUser { get; set; }
        string Email { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        void Abandon();
        ModelsView_Views.UserInfos GetInfosUser();
    }
}
