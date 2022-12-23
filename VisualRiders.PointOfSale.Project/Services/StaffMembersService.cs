using AutoMapper;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Services;

public class StaffMembersService
{
    private readonly StaffMembersRepository _repository;
    private readonly IMapper _mapper;

    public StaffMembersService(StaffMembersRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ReadStaffMemberDto Create(CreateUpdateStaffMemberDto dto)
    {
        var staffMember = _mapper.Map<StaffMember>(dto);
        staffMember.BusinessEntityId = 1;

        _repository.Add(staffMember);
        _repository.SaveChanges();

        return _mapper.Map<ReadStaffMemberDto>(staffMember);
    }

    public List<ReadStaffMemberDto> GetAll()
    {
        return _repository.GetAll().Select(_mapper.Map<ReadStaffMemberDto>).ToList();
    }

    public ReadStaffMemberDto? GetById(int id)
    {
        return _mapper.Map<ReadStaffMemberDto>(_repository.GetById(id));
    }

    public ReadStaffMemberDto? UpdateById(int id, CreateUpdateStaffMemberDto dto)
    {
        var staffMember = _repository.GetById(id);

        if (staffMember == null) return null;

        _mapper.Map(dto, staffMember);
        
        _repository.SaveChanges();

        return _mapper.Map<ReadStaffMemberDto>(staffMember);
    }

    public bool RemoveById(int id)
    {
        var staffMember = _repository.GetById(id);

        if (staffMember == null) return false;
        
        _repository.Remove(staffMember);
        _repository.SaveChanges();

        return true;
    }
}