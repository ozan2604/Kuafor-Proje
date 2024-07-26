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
	public class RezervasyonController : CustomBaseController
	{
	

		private readonly IMapper _mapper;
		private readonly IService<Rezervasyon> _service;
		private readonly IService<Müşteri> _musteriService;

		public RezervasyonController(IMapper mapper, IService<Rezervasyon> service, IService<Müşteri> musteriService)
		{
			_mapper = mapper;
			_service = service;
			_musteriService = musteriService;
		}

		[HttpGet]
		public IActionResult AvailableTimes()
		{
			

			// Örnek olarak sabit bir liste dönelim:
			var availableTimes = new List<string>
			{
				{ "09:00" }, {"10:00" }, {"11:00" }, {"12:00" }, {"13:00" },
				{ "14:00" }, {"15:00" }, {"16:00" }, {"17:00" }, {"18:00" }
			};

			// Başka bir sınıftan veya veritabanından alınıyorsa, o işlemleri burada yapabilirsiniz.

			return CreateActionResult(CustomResponseDto<List<string>>.Succes(200, availableTimes));
		}

		[HttpGet]
		public async Task<IActionResult> All(int Id)
		{
			var rezervasyons = await _service.GetAllAsync();
			var rezervasyonsDtos = _mapper.Map<List<RezervasyonDto>>(rezervasyons.ToList());
			return CreateActionResult(CustomResponseDto<List<RezervasyonDto>>.Succes(200, rezervasyonsDtos));
		}

		// GET/api/products/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var rezervasyon = await _service.GetByIdAsync(id);
			var rezervasyonsDtos = _mapper.Map<RezervasyonDto>(rezervasyon);
			return CreateActionResult(CustomResponseDto<RezervasyonDto>.Succes(200, rezervasyonsDtos));
		}


		[HttpPost]
		public async Task<IActionResult> Save(RezervasyonDto rezervasyonDto)
		{

			var musteri = _musteriService.where(x => x.KullaniciAdi == rezervasyonDto.musteriKullaniciAdi).FirstOrDefault();
			if (musteri == null)
			{
				return CreateActionResult(CustomResponseDto<RezervasyonDto>.Fail(500, "aynı tarih Lütfen farklı tarih veya kuaför seciniz"));
			}
			
			var FilterRezervasyon = _service.where(x => x.Kuaför_Id == rezervasyonDto.Kuaför_Id && x.RezervasyonTarih == rezervasyonDto.RezervasyonTarih).FirstOrDefault();
			
			if(FilterRezervasyon != null)
			{
				return CreateActionResult(CustomResponseDto<RezervasyonDto>.Fail(500, "aynı tarih Lütfen farklı tarih veya kuaför seciniz"));
					
			}
			rezervasyonDto.Müşteri_Id = musteri.Id;
			rezervasyonDto.CreateTime = DateTime.Now;
			var rezervasyon = await _service.AddAsync(_mapper.Map<Rezervasyon>(rezervasyonDto));
			var rezervasyonDtos = _mapper.Map<RezervasyonDto>(rezervasyon);
			return CreateActionResult(CustomResponseDto<RezervasyonDto>.Succes(201, rezervasyonDtos));
		}



		//put = update
		[HttpPut]
		public async Task<IActionResult> Update(RezervasyonUpdateDto rezervasyonDto)
		{
			await _service.UpdateAsync(_mapper.Map<Rezervasyon>(rezervasyonDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}

		// GET/api/products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var rezervasyon = await _service.GetByIdAsync(id);
			await _service.RemoveAsync(rezervasyon);
			return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
		}
	}
}
