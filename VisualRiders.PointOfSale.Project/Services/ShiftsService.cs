using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class ShiftsService
{
    private readonly ShiftsRepository _repository;
    private readonly StaffMembersService _staffMembersService;
    private readonly IMapper _mapper;

    public ShiftsService(ShiftsRepository repository, StaffMembersService staffMembersService, IMapper mapper)
    {
        _repository = repository;
        _staffMembersService = staffMembersService;
        _mapper = mapper;
    }

    public ReadShiftDto Create(CreateUpdateShiftDto dto)
    {
        var shift = _mapper.Map<Shift>(dto);
        if (_staffMembersService.GetById(shift.StaffMemberId) == null)
        {
            throw new ArgumentException();
        }

        _repository.Add(shift);
        _repository.SaveChanges();

        return _mapper.Map<ReadShiftDto>(shift);
    }

    public List<ReadShiftDto> GetAll()
    {
        return _repository.GetAll().Select(a => _mapper.Map<ReadShiftDto>(a)).ToList();
    }

    public ReadShiftDto? GetById(int id)
    {
        return _mapper.Map<ReadShiftDto>(_repository.GetById(id));
    }

    public ReadShiftDto? UpdateById(int id, CreateUpdateShiftDto dto)
    {
        var shift = _repository.GetById(id);

        if (shift == null) return null;

        shift.StartDate = dto.StartDate;
        shift.EndDate = dto.EndDate;
        shift.StaffMemberId = dto.StaffMemberId;
        
        _repository.SaveChanges();

        return _mapper.Map<ReadShiftDto>(shift);
    }

    public bool RemoveById(int id)
    {
        var shift = _repository.GetById(id);

        if (shift == null) return false;
        
        _repository.Remove(shift);
        _repository.SaveChanges();

        return true;
    }
}