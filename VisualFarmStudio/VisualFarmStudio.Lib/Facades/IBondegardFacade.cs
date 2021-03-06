﻿using System.Collections.Generic;
using VisualFarmStudio.Lib.Model;

namespace VisualFarmStudio.Lib.Facades
{
    public interface IBondegardFacade
    {
        BondegardModel GetDefaultBondegard();
        IEnumerable<BondegardModel> GetAllBondegards();
        void Save(BondegardModel bondegard);
        BondegardModel GetBondegard(long id);
        void GenerateBondegards(BondeModel bonde, int number);
    }
}