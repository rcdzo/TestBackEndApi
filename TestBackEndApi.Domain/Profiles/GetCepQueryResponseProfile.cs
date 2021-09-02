    using AutoMapper;
using TestBackEndApi.Domain.Queries.Cep.Get;
using TestBackEndApi.Infrastructure.Services.Contract;

namespace TestBackEndApi.Domain.Profiles
{
    public class GetCepQueryResponseProfile : Profile
    {
        public GetCepQueryResponseProfile()
        {
            CreateMap<GetCepQuery, CepRequest>();
            CreateMap<CepResponse, GetCepQueryResponse>().ForMember(qr => qr.Localidade, opt => opt.MapFrom(r => $"{r.Localidade} - {r.Uf}")) ;
            CreateMap<MensagemResponse, MensagemQueryResponse>();
        }
    }
}
