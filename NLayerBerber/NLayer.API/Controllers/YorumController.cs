using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Repository;

namespace NLayer.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class YorumController : CustomBaseController
	{

		private readonly IMapper _mapper;
		private readonly IService<Yorum> _service;
		private readonly AppDbContext _context;

		public YorumController(IMapper mapper, IService<Yorum> service, AppDbContext context)
		{
			_mapper = mapper;
			_service = service;
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> all(int Id)
		{
			var yorums = await _service.GetAllAsync();
			var yorumsDtos = _mapper.Map<List<YorumDto>>(yorums.ToList());
			return CreateActionResult(CustomResponseDto<List<YorumDto>>.Succes(200, yorumsDtos));

		}

		// GET/api/products/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var yorum = await _service.GetByIdAsync(id);
			var yorumsDto = _mapper.Map<YorumDto>(yorum);
			return CreateActionResult(CustomResponseDto<YorumDto>.Succes(200, yorumsDto));


		}
		//[HttpPost]
		//public async Task<IActionResult> Save(YorumDto yorumDto)
		//{ 
		//	if (!string.IsNullOrEmpty(yorumDto.KullaniciAdi) && !string.IsNullOrEmpty(yorumDto.YorumDetay))
		//	{
		//		var existingMüşteri = await _context.Müşteris.FirstOrDefaultAsync(c => c.KullaniciAdi == yorumDto.KullaniciAdi);

		//		if (existingMüşteri != null)
		//		{
		//			return CreateActionResult(CustomResponseDto<YorumDto>.Fail(400, "Geçerli bir kullanıcı adı giriniz."));
		//		}

		//		yorumDto.YorumTarih = DateTime.Now;
		//		yorumDto.CreateTime = DateTime.Now;
		//		var yorum = await _service.AddAsync(_mapper.Map<Yorum>(yorumDto));
		//		var yorumsDtos = _mapper.Map<YorumDto>(yorum);
		//		return CreateActionResult(CustomResponseDto<YorumDto>.Succes(201, yorumsDtos));

		//	}
		//	else
		//	{
		//		return CreateActionResult(CustomResponseDto<YorumDto>.Fail(400, "Lütfen geçerli kullanıcı adı ve yorum detayı giriniz."));
		//	}

		//}

		[HttpPost]
		public async Task<IActionResult> Save(YorumDto yorumDto)
		{
			// Gelen verilerin geçerliliğini kontrol et
			if (string.IsNullOrEmpty(yorumDto.KullaniciAdi) || string.IsNullOrEmpty(yorumDto.YorumDetay))
			{
				return CreateActionResult(CustomResponseDto<YorumDto>.Fail(400, "Lütfen geçerli kullanıcı adı ve yorum detayı giriniz."));
			}

			try
			{
				var existingMüşteri = await _context.Müşteris.FirstOrDefaultAsync(c => c.KullaniciAdi == yorumDto.KullaniciAdi);

				if (existingMüşteri == null)
				{
					return CreateActionResult(CustomResponseDto<YorumDto>.Fail(400, "Geçerli bir kullanıcı adı giriniz."));
				}

				yorumDto.YorumTarih = DateTime.Now;
				yorumDto.CreateTime = DateTime.Now;

				var yorum = await _service.AddAsync(_mapper.Map<Yorum>(yorumDto));

				var yorumDtoSonuc = _mapper.Map<YorumDto>(yorum);

				return CreateActionResult(CustomResponseDto<YorumDto>.Succes(201, yorumDtoSonuc));
			}
			catch (Exception ex)
			{
				// Hata durumunda uygun mesaj ile 500 kodlu hata döndür
				return CreateActionResult(CustomResponseDto<YorumDto>.Fail(500, $"Yorum eklenirken bir hata oluştu: {ex.Message}"));
			}
		}




		//put = update
		[HttpPut]
		public async Task<IActionResult> Update(YorumUpdateDto yorumDto)
		{
			await _service.UpdateAsync(_mapper.Map<Yorum>(yorumDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}

		// GET/api/products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var yorum = await _service.GetByIdAsync(id);
			await _service.RemoveAsync(yorum);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}

		[HttpGet("SonBes")]
		public async Task<ActionResult<IEnumerable<Yorum>>> GetSonBesYorum()
		{
			var sonBesYorum = await _context.Yorums
				.OrderByDescending(y => y.YorumTarih)
				.Take(8)
				.ToListAsync();

			return sonBesYorum;
		}
	}
}
