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
	public class KuaförController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<Kuaför> _service;

		public KuaförController(IMapper mapper, IService<Kuaför> service)
		{
			_mapper = mapper;
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> All(int Id)
		{
			var kuaförs = await _service.GetAllAsync();
			var kuaförsDtos = _mapper.Map<List<KuaförDto>>(kuaförs.ToList());
			return CreateActionResult(CustomResponseDto<List<KuaförDto>>.Succes(200, kuaförsDtos));
		}

		// GET/api/products/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var kuaför = await _service.GetByIdAsync(id);
			var kuaförsDtos = _mapper.Map<KuaförDto>(kuaför);
			return CreateActionResult(CustomResponseDto<KuaförDto>.Succes(200, kuaförsDtos));
		}


		[HttpPost]
		public async Task<IActionResult> Save(KuaförDto kuaförDto)
		{

			kuaförDto.CreateTime = DateTime.Now;
			var kuaför = await _service.AddAsync(_mapper.Map<Kuaför>(kuaförDto));
			var kuaförsDtos = _mapper.Map<KuaförDto>(kuaför);
			return CreateActionResult(CustomResponseDto<KuaförDto>.Succes(201, kuaförsDtos));
		}



		//put = update
		[HttpPut]
		public async Task<IActionResult> Update(KuaförUpdateDto kuaförDto)
		{
			await _service.UpdateAsync(_mapper.Map<Kuaför>(kuaförDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}

		// GET/api/products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var kuaför = await _service.GetByIdAsync(id);
			await _service.RemoveAsync(kuaför);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}
	}
}
