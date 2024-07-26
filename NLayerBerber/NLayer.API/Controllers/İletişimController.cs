using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class İletişimController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<İletişim> _service;

		public İletişimController(IMapper mapper, IService<İletişim> service)
		{
			_mapper = mapper;
			_service = service;
		}



		[HttpGet]
		public async Task<IActionResult> All(int Id)
		{
			var iletişims = await _service.GetAllAsync();
			var iletişimsDtos = _mapper.Map<List<İletişimDto>>(iletişims.ToList());
			return CreateActionResult(CustomResponseDto<List<İletişimDto>>.Succes(200, iletişimsDtos));
		}

		// GET/api/products/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var iletişim = await _service.GetByIdAsync(id);
			var iletişimsDtos = _mapper.Map<İletişimDto>(iletişim);
			return CreateActionResult(CustomResponseDto<İletişimDto>.Succes(200, iletişimsDtos));
		}


		[HttpPost]
		public async Task<IActionResult> Save(İletişimDto iletişimDto)
		{
			iletişimDto.CreateTime = DateTime.Now;
			var iletişim = await _service.AddAsync(_mapper.Map<İletişim>(iletişimDto));
			var iletişimsDtos = _mapper.Map<İletişimDto>(iletişim);
			return CreateActionResult(CustomResponseDto<İletişimDto>.Succes(201, iletişimsDtos));
		}



		//put = update
		[HttpPut]
		public async Task<IActionResult> Update(İletişimUpdateDto iletişimDto)
		{
			await _service.UpdateAsync(_mapper.Map<İletişim>(iletişimDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}

		// GET/api/products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var iletişim = await _service.GetByIdAsync(id);
			await _service.RemoveAsync(iletişim);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}
	}
}
