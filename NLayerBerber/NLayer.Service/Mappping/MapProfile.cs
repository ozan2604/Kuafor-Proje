using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mappping
{
	public class MapProfile : Profile
	{
		public MapProfile() 
		{
			CreateMap<Admin, AdminDto>().ReverseMap();
			CreateMap<Hizmet, HizmetDto>().ReverseMap();
			CreateMap<İletişim, İletişimDto>().ReverseMap();
			CreateMap<Kuaför, KuaförDto>().ReverseMap();
			CreateMap<Müşteri, MüşteriDto>().ReverseMap();
			CreateMap<Rezervasyon, RezervasyonDto>().ReverseMap();
			CreateMap<Yorum, YorumDto>().ReverseMap();
			CreateMap<AdminLogin, AdminLoginDto>().ReverseMap();
			CreateMap<RezervasyonUpdateDto, Rezervasyon>();
			CreateMap<AdminUpdateDto, Admin>();
			CreateMap<HizmetUpdateDto, Hizmet>();
			CreateMap<İletişimUpdateDto, İletişim>();
			CreateMap<KuaförUpdateDto, Kuaför>();
			CreateMap<MüşteriUpdateDto , Müşteri>();
			CreateMap<YorumUpdateDto, Yorum>();
			CreateMap<AdminLoginUpdateDto, AdminLogin>();
			




		}
	}
}
