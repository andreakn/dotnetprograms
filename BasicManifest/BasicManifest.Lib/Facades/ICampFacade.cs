﻿using System;
using BasicManifest.Lib.Models;

namespace BasicManifest.Lib.Facades
{
    public interface ICampFacade
    {
        CampIndexModel GetCamps();
        CampModel Edit(Guid id);
    }
}