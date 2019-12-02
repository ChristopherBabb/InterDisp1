using InterdispProj1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterdispProj1.Data
{
    public class DataEntryRepository : IDataEntryRepository
    {
        private readonly InterdispProj1Context _context;
        public DataEntryRepository(InterdispProj1Context context)
        {
            this._context = context;
        }


        public async Task<DataEntry> Add(DataEntry dataentry)
        {
            await _context.DataEntries.AddAsync(dataentry);
            return dataentry;
        }

        public Task Delete(DataEntry dataentry)
        {
            var deletedDataEntry = _context.DataEntries.Remove(dataentry);
            return Task.FromResult(deletedDataEntry);
        }

        public async Task<List<DataEntry>> GetAll()
        {
            var dataEntries = await _context.DataEntries.ToListAsync();
            return dataEntries;
        }
        public async Task<DataEntry> GetById(string id)
        {
            var dataEntry = await _context.DataEntries
                .Include(de => de.Requirement)
                .SingleOrDefaultAsync(de => de.Id == id);

            return dataEntry;
        }
        public Task Update(DataEntry dataentry)
        {
            return Task.FromResult(_context.DataEntries.Update(dataentry));
        }

        public async Task<bool> DataEntryExists(string id)
        {
            var dataEntry = await _context.DataEntries
              .Include(de => de.Requirement)
              .SingleOrDefaultAsync(de => de.Id == id);
            return (dataEntry != null);
        }
    }
}
