using InterdispProj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterdispProj1.Data
{
    public interface IDataEntryRepository
    {
        Task<DataEntry> GetById(string id);
        Task<List<DataEntry>> GetAll();
        Task<DataEntry> Add(DataEntry dataEntry);
        Task Update(DataEntry dataEntry);
        Task Delete(DataEntry dataEntry);
        Task<bool> DataEntryExists(string id);
    }
}
