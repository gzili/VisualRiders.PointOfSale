using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class ClientLoyaltiesService
{
    private readonly ClientLoyaltiesRepository _repository;
    private readonly LoyaltiesRepository _loyaltiesRepository;
    private readonly IMapper _mapper;

    public ClientLoyaltiesService(ClientLoyaltiesRepository repository, LoyaltiesRepository loyaltiesRepository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _loyaltiesRepository = loyaltiesRepository;
    }

    public ClientLoyalty Create(CreateUpdateClientLoyaltyDto dto)
    {
        var cLoyalty = _mapper.Map<ClientLoyalty>(dto);

        var loyalty = _loyaltiesRepository.GetById(dto.LoyaltyId);

        if (loyalty == null)
        {
            throw new UnprocessableEntity($"Loyalty with Id = {dto.LoyaltyId} does not exist");
        }

        cLoyalty.Loyalty = loyalty;


        _repository.Add(cLoyalty);
        _repository.SaveChanges();

        return cLoyalty;
    }

    public List<ClientLoyalty> GetAll()
    {
        return _repository.GetAll();
    }

    public ClientLoyalty? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public ClientLoyalty? UpdateById(int id, CreateUpdateClientLoyaltyDto dto)
    {
        var cLoyalty = _repository.GetById(id);

        if (cLoyalty == null) return null;

        _mapper.Map(dto, cLoyalty);

        var loyalty = _loyaltiesRepository.GetById(dto.LoyaltyId);

        if (loyalty == null)
        {
            throw new UnprocessableEntity($"Loyalty with Id = {dto.LoyaltyId} does not exist");
        }

        cLoyalty.Loyalty = loyalty;

        _repository.SaveChanges();

        return cLoyalty;
    }

    public bool RemoveById(int id)
    {
        var loyalty = _repository.GetById(id);

        if (loyalty == null) return false;
        
        _repository.Remove(loyalty);
        _repository.SaveChanges();

        return true;
    }
}