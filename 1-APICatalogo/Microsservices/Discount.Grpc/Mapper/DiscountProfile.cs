using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            // ReverseMap siginifica que ele vai converter para os 2 lados
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
