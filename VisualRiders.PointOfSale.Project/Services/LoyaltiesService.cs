using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services
{
    public class LoyaltiesService
    {
        private readonly LoyaltiesRepository _repository;
        private readonly DiscountsRepository _discountsRepository;
        private readonly IMapper _mapper;

        public LoyaltiesService(LoyaltiesRepository repository, DiscountsRepository discountsRepository, IMapper mapper)
        {
            _repository = repository;
            _discountsRepository = discountsRepository;
            _mapper = mapper;
        }

        public ReadLoyaltyDto Create(CreateUpdateLoyaltyDto dto)
        {
            var loyalty = _mapper.Map<Loyalty>(dto);

            loyalty.BusinessEntityId = 1;

            var discount = _discountsRepository.GetById(dto.DiscountId);

            if(discount == null)
            {
                throw new UnprocessableEntity($"Discount with Id = {dto.DiscountId} does not exist");
            }

            loyalty.Discount = discount;

            _repository.Add(loyalty);
            _repository.SaveChanges();

            return _mapper.Map<ReadLoyaltyDto>(loyalty);
        }

        public List<ReadLoyaltyDto> GetAll()
        {
            return _repository.GetAll().Select(_mapper.Map<ReadLoyaltyDto>).ToList();
        }

        public ReadLoyaltyDto? GetById(int id)
        {
            return _mapper.Map<ReadLoyaltyDto>(_repository.GetById(id));
        }

        public ReadLoyaltyDto? UpdateById(int id, CreateUpdateLoyaltyDto dto)
        {
            var loyalty = _repository.GetById(id);

            if (loyalty == null) return null;

            _mapper.Map(loyalty, dto);

            var discount = _discountsRepository.GetById(dto.DiscountId);

            if(discount == null)
            {
                throw new UnprocessableEntity($"Discount with Id = {dto.DiscountId} does not exist");
            }

            loyalty.Discount = discount;

            _repository.SaveChanges();

            return _mapper.Map<ReadLoyaltyDto>(loyalty);
        }

        public bool RemoveById(int id)
        {
            var loyalty = _repository.GetById(id);

            if(loyalty == null) return false;

            _repository.Remove(loyalty);
            _repository.SaveChanges();

            return true;
        }
    }
}