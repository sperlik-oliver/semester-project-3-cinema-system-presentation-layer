﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data {
    public interface IHallService {
        Task<Hall> CreateHall(Hall hall);

        Task<Hall> EditHall(Hall hall);

        Task<bool> DeleteHall(int hallId);

        Task<Hall> GetHall(int hallId);

        Task<IList<Hall>> GetAllHalls();
    }
}