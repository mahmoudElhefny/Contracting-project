﻿using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentPageController : ControllerBase
    {
        private readonly IContentPageRepository _contentPageRepository;

        public ContentPageController(IContentPageRepository contentPageRepository)
        {
            _contentPageRepository = contentPageRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string Lang="EN")
        {
            var result = await _contentPageRepository.GetAll(Lang);
            return Ok(result);
        }
    }
}