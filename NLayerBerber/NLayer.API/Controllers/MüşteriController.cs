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
	public class MüşteriController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<Müşteri> _service;

		public MüşteriController(IMapper mapper, IService<Müşteri> service)
		{
			_mapper = mapper;
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> All(int Id)
		{
			var müşteris = await _service.GetAllAsync();
			var müşterisDto = _mapper.Map<List<MüşteriDto>>(müşteris.ToList());
			return CreateActionResult(CustomResponseDto<List<MüşteriDto>>.Succes(200, müşterisDto));
		}

		// GET/api/products/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var müşteri = await _service.GetByIdAsync(id);
			var müşterisDto = _mapper.Map<MüşteriDto>(müşteri);
			return CreateActionResult(CustomResponseDto<MüşteriDto>.Succes(200, müşterisDto));
			

		}
		[HttpPost]
		public async Task<IActionResult> Save(MüşteriDto müşteriDto)
		{
			müşteriDto.CreateTime = DateTime.Now;
			var müşteri = await _service.AddAsync(_mapper.Map<Müşteri>(müşteriDto));
			var müşterisDtos = _mapper.Map<MüşteriDto>(müşteri);
			return CreateActionResult(CustomResponseDto<MüşteriDto>.Succes(201, müşterisDtos));
		}



		//put = update
		[HttpPut]
		public async Task<IActionResult> Update(MüşteriUpdateDto müşteriDto)
		{
			await _service.UpdateAsync(_mapper.Map<Müşteri>(müşteriDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}

		// GET/api/products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var müşteri = await _service.GetByIdAsync(id);
			await _service.RemoveAsync(müşteri);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}
	}
}
