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
	public class HizmetController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<Hizmet> _service;

		public HizmetController(IMapper mapper, IService<Hizmet> service)
		{
			_mapper = mapper;
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> All(int Id)
		{
			var hizmets = await _service.GetAllAsync();
			var hizmetsDtos = _mapper.Map<List<HizmetDto>>(hizmets.ToList());
			return CreateActionResult(CustomResponseDto<List<HizmetDto>>.Succes(200, hizmetsDtos));
		}

		// GET/api/products/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var hizmet = await _service.GetByIdAsync(id);
			var hizmetsDtos = _mapper.Map<HizmetDto>(hizmet);
			return CreateActionResult(CustomResponseDto<HizmetDto>.Succes(200, hizmetsDtos));
		}


		[HttpPost]
		public async Task<IActionResult> Save(HizmetDto hizmetDto)
		{
			hizmetDto.CreateTime= DateTime.Now;
			var hizmet = await _service.AddAsync(_mapper.Map<Hizmet>(hizmetDto));
			var hizmetsDtos = _mapper.Map<HizmetDto>(hizmet);
			return CreateActionResult(CustomResponseDto<HizmetDto>.Succes(201, hizmetsDtos));
		}



		//put = update
		[HttpPut]
		public async Task<IActionResult> Update(HizmetUpdateDto hizmetDto)
		{
			await _service.UpdateAsync(_mapper.Map<Hizmet>(hizmetDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}

		// GET/api/products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var hizmet = await _service.GetByIdAsync(id);
			await _service.RemoveAsync(hizmet);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}
	}
}
