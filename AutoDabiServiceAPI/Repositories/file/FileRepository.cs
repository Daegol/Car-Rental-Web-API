using AutoDabiServiceAPI.Data;
using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.Models;
using AutoDabiServiceAPI.Repositories.file;
using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDabiServiceAPI.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;
        public FileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddRentCarFile(File file)
        {
            await _context.AddAsync(file);
            await _context.SaveChangesAsync();
        }

        public async Task<ResultInfo> AddReturnCarFile(File file)
        {
            File rentFile = _context.Files.Where(f => f.CarId == file.CarId).Where(f => f.FileType == FileType.RENT).OrderBy(f => f.UpdateTime).Last();

            if (rentFile == null)
            {
                return new ResultInfo(StatusType.Failed, "Nie udało się zapisać protokołu zwrotu. Nie znaleziono protokołu wypożyczena.");
            }

            rentFile.Name = file.Name;
            rentFile.ContentType = file.ContentType;
            rentFile.Stream = file.Stream;
            rentFile.FileType = file.FileType;
            rentFile.UpdateTime = file.UpdateTime;

            _context.Update(rentFile);
            await _context.SaveChangesAsync();

            return new ResultInfo(StatusType.Success, "Pomyślnie zaktualizowano protokół zwrotu samochodu.");
        }

        public async Task<IEnumerable<FileDto>> GetAllFileDto()
        {
            List<File> files = _context.Files.ToList();
            List<FileDto> filesDto = new List<FileDto>();

            foreach (File file in files)
            {
                Car car = _context.Cars.FirstOrDefault(c => c.Id == file.CarId);
                file.setCarName(car);

                filesDto.Add(MapFileToFileDto(file));
            }

            return filesDto;
        }

        public async Task<File> GetFileById(Guid id)
        {
            return _context.Files.FirstOrDefault(f => f.Id == id);
        }

        private FileDto MapFileToFileDto(File file)
        {
            return new FileDto { Id = file.Id, Name = file.Name, Stream = Encoding.Default.GetString(file.Stream), CarId = file.CarId, ContentType = file.ContentType, CreationTime = file.CreationTime.ToString(), UpdateTime = file.UpdateTime.ToString(), FileType = file.FileType, CarName = file.CarName };
        }
    }
}
