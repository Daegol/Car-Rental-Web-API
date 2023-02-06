using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.Models;
using AutoDabiServiceAPI.Repositories;
using AutoDabiServiceAPI.Repositories.file;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoDabiServiceAPI.Controllers
{
    [Authorize]
    public class FileController : GenericController<File>
    {
        private readonly IFileRepository _fileRepository;
        public FileController(IGenericRepository<File> repository, IFileRepository fileRepository) : base(repository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet("getAllFileDto")]
        public async Task<IActionResult> GetAllFileDto()
        {
            var result = await _fileRepository.GetAllFileDto();

            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var file = await _fileRepository.GetFileById(id);

            return File(file?.Stream, file?.ContentType, file?.Name);
        }
    }
}
