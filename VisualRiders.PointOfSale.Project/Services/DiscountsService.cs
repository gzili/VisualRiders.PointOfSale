using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Exceptions;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class DiscountsService
{
    private readonly DiscountsRepository _repository;
    private readonly DiscountItemsRepository _discountItemsRepository;
    private readonly ProductsRepository _productsRepository;
    private readonly ServicesRepository _servicesRepository;
    private readonly IMapper _mapper;

    public DiscountsService(
        DiscountsRepository repository,
        DiscountItemsRepository discountItemsRepository,
        ProductsRepository productsRepository,
        ServicesRepository servicesRepository,
        IMapper mapper)
    {
        _repository = repository;
        _discountItemsRepository = discountItemsRepository;
        _productsRepository = productsRepository;
        _servicesRepository = servicesRepository;
        _mapper = mapper;
    }

    public ReadDiscountDto Create(CreateUpdateDiscountDto dto)
    {
        var discount = _mapper.Map<Discount>(dto);

        discount.BusinessEntityId = 1;
        
        _repository.Add(discount);
        _repository.SaveChanges();

        return _mapper.Map<ReadDiscountDto>(discount);
    }

    public List<ReadDiscountDto> GetAll()
    {
        return _repository.GetAll().Select(_mapper.Map<ReadDiscountDto>).ToList();
    }

    public ReadDiscountDto? GetById(int id)
    {
        return _mapper.Map<ReadDiscountDto>(_repository.GetById(id));
    }

    public ReadDiscountDto? UpdateById(int id, CreateUpdateDiscountDto dto)
    {
        var discount = _repository.GetById(id);

        if (discount == null) return null;

        discount = _mapper.Map<Discount>(dto); 

        _repository.SaveChanges();

        return _mapper.Map<ReadDiscountDto>(discount);
    }

    public ReadDiscountItemDto? AddItem(int discountId, CreateUpdateDiscountItemDto dto)
    {
        var discountItem = _mapper.Map<DiscountItem>(dto);

        if (_repository.GetById(discountId) == null) return null;

        discountItem.DiscountId = discountId;

        if (dto.ProductId == null && dto.ServiceId == null)
        {
            throw new UnprocessableEntity("Either productId or serviceId must be provided");
        }
        
        if (dto.ProductId != null && dto.ServiceId != null)
        {
            throw new UnprocessableEntity("Either productId or serviceId must be null");
        }

        if (dto.ProductId != null)
        {
            var product = _productsRepository.GetById(dto.ProductId.Value);
            if (product == null)
            {
                throw new UnprocessableEntity($"Product with Id = {dto.ProductId.Value} does not exist");
            }

            discountItem.Product = product;
        }

        if (dto.ServiceId != null)
        {
            var service = _servicesRepository.GetById(dto.ServiceId.Value);
            if (service == null)
            {
                throw new UnprocessableEntity($"Product with Id = {dto.ServiceId.Value} does not exist");
            }

            discountItem.Service = service;
        }

        _discountItemsRepository.Add(discountItem);
        _discountItemsRepository.SaveChanges();
        
        return _mapper.Map<ReadDiscountItemDto>(discountItem);
    }

    public ReadDiscountItemDto? UpdateItem(int discountId, int itemId, CreateUpdateDiscountItemDto dto)
    {
        if (_repository.GetById(discountId) == null) return null;

        var discountItem = _discountItemsRepository.GetById(itemId);

        if (discountItem == null)
        {
            throw new UnprocessableEntity($"Discount item with Id = {itemId} does not exist");
        }

        _mapper.Map(dto, discountItem);

        if (dto.ProductId != null)
        {
            var product = _productsRepository.GetById(dto.ProductId.Value);
            if (product == null)
            {
                throw new UnprocessableEntity($"Product with Id = {dto.ProductId.Value} does not exist");
            }

            discountItem.Product = product;
        }
        else
        {
            discountItem.Product = null;
        }

        if (dto.ServiceId != null)
        {
            var service = _servicesRepository.GetById(dto.ServiceId.Value);
            if (service == null)
            {
                throw new UnprocessableEntity($"Product with Id = {dto.ServiceId.Value} does not exist");
            }

            discountItem.Service = service;
        }
        else
        {
            discountItem.Service = null;
        }

        _discountItemsRepository.SaveChanges();
        _repository.SaveChanges();

        return _mapper.Map<ReadDiscountItemDto>(discountItem);

    }

    public bool RemoveItem(int discountId, int itemId)
    {
        if (_repository.GetById(discountId) == null) return false;

        var discountItem = _discountItemsRepository.GetById(itemId);

        if (discountItem == null) return false;

        _discountItemsRepository.Remove(discountItem);
        _discountItemsRepository.SaveChanges();

        return true;
    }

    public bool Remove(int id)
    {
        var discount = _repository.GetById(id);

        if (discount == null) return false;

        _repository.Remove(discount);
        _repository.SaveChanges();

        return true;
    }
}