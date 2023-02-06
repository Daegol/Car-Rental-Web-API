using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDabiServiceAPI.Repositories.file
{
    public interface IFileRepository
    {
        public Task AddRentCarFile(File file);
        public Task<ResultInfo> AddReturnCarFile(File file);
        public Task<IEnumerable<FileDto>> GetAllFileDto();
        public Task<File> GetFileById(Guid id);
    }
}
