﻿using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.Core.IServices
{
    public interface ITreatmentsService
    {
        List<Treatment> GetAllTreatments();
    }
}