using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class ClientsService
{
    private readonly ClientLoyaltiesRepository _clientLoyaltiesRepository;
    private readonly ClientsRepository _repository;
    private readonly IMapper _mapper;

    public ClientsService(ClientsRepository repository, ClientLoyaltiesRepository clientLoyaltiesRepository, IMapper mapper)
    {
        _repository = repository;
        _clientLoyaltiesRepository = clientLoyaltiesRepository;
        _mapper = mapper;
    }

    public ReadClientDto Create(CreateUpdateClientDto dto)
    {
        var client = _mapper.Map<Client>(dto);
        
        if (client.ClientLoyaltyId.HasValue && _clientLoyaltiesRepository.GetById(client.ClientLoyaltyId.Value) == null)
        {
            throw new UnprocessableEntity($"Client Loyalty with Id = {dto.ClientLoyaltyId} does not exist");
        }

        _repository.Add(client);
        _repository.SaveChanges();

        return _mapper.Map<ReadClientDto>(client);
    }

    public List<ReadClientDto> GetAll()
    {
        return _repository.GetAll().Select(_mapper.Map<ReadClientDto>).ToList();
    }

    public ReadClientDto? GetById(int id)
    {
        return _mapper.Map<ReadClientDto>(_repository.GetById(id));
    }

    public ReadClientDto? UpdateById(int id, CreateUpdateClientDto dto)
    {
        var client = _repository.GetById(id);

        if (client == null) return null;

        if (dto.ClientLoyaltyId.HasValue && _clientLoyaltiesRepository.GetById(dto.ClientLoyaltyId.Value) == null)
        {
            throw new UnprocessableEntity($"Client Loyalty with Id = {dto.ClientLoyaltyId} does not exist");
        }

        _mapper.Map(dto, client);

        _repository.SaveChanges();

        return _mapper.Map<ReadClientDto>(client);
    }

    public bool RemoveById(int id)
    {
        var client = _repository.GetById(id);

        if (client == null) return false;

        _repository.Remove(client);
        _repository.SaveChanges();

        return true;
    }
}