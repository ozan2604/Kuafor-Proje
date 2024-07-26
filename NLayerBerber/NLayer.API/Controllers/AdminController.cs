using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers   
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AdminController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<Admin> _service;

		public AdminController(IMapper mapper, IService<Admin> service)
		{
			_mapper = mapper;
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> All(int Id)
		{
			var admins = await _service.GetAllAsync();
			var adminsDtos = _mapper.Map<List<AdminDto>>(admins.ToList());
			return CreateActionResult(CustomResponseDto<List<AdminDto>>.Succes(200, adminsDtos));
		}

		// GET/api/products/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var admin = await _service.GetByIdAsync(id);
			var adminsDtos = _mapper.Map<AdminDto>(admin);
			return CreateActionResult(CustomResponseDto<AdminDto>.Succes(200, adminsDtos));
		}

		[HttpPost]
		public async Task<IActionResult> Save(AdminDto adminDto)
		{
			adminDto.CreateTime = DateTime.Now;
			var admin = await _service.AddAsync(_mapper.Map<Admin>(adminDto));
			var adminsDtos = _mapper.Map<AdminDto>(admin);
			return CreateActionResult(CustomResponseDto<AdminDto>.Succes(201, adminsDtos));
		}

		[HttpPost]
		public async Task<IActionResult> Login(AdminDto adminDto)
		{
			bool adminVarMi = await _service.AnyAsync(x => x.AdminMail == adminDto.AdminMail && x.AdminŞifre == adminDto.AdminŞifre);

			if (adminVarMi)
			{
				return CreateActionResult(CustomResponseDto<AdminDto>.Succes(201));
			}
            else
            {
				return CreateActionResult(CustomResponseDto<AdminDto>.Fail(401, "Böyle bir admin kullanıcısı yoktur."));
			}
        }

		//put = update
		[HttpPut]
		public async Task<IActionResult> Update(AdminUpdateDto admindto)
		{
			await _service.UpdateAsync(_mapper.Map<Admin>(admindto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}

		// GET/api/products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var admin = await _service.GetByIdAsync(id);
			await _service.RemoveAsync(admin);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}
	}
}
