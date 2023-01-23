using AutoMapper;
using CarReservation.Application.DTOs;
using CarReservation.Application.Interfaces;
using CarReservation.Application.Interfaces.Repositories;
using CarReservation.Application.Interfaces.Services;
using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.Application.Services;

public class EmployeeService : IClientFacingFormService
{
    #region Fields

    private readonly IUnitOfWork unitOfWork;
    private readonly IGenericRepository<Employee> employeeRepository;
    private readonly IMapper mapper;

    #endregion Fields

    #region CTOR

    public EmployeeService(IUnitOfWork unitOfWork, IGenericRepository<Employee> employeeRepository, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.employeeRepository = employeeRepository;
        this.mapper = mapper;
    }

    #endregion CTOR

    public async Task<Response<List<Employee>>> GetAllEmployeeByRegionIdAsync(int regionId)
    {
        var employees = await employeeRepository.AsQueryable().Include(employee => employee.Region).Where(employee => employee.RegionId == regionId || employee.Region.ParentRegionId == regionId).ToListAsync();
        return new Response<List<Employee>>(employees, "Successful operation");

    }
    public async Task<Response<ClientFacingFormDTO>> AddEmployeeAsync(ClientFacingFormDTO employeeDTO)
    {
        Employee employee = new()
        {
            FirstName = employeeDTO.FirstName,
            LastName = employeeDTO.LastName,
            RegionId = employeeDTO.RegionId
        };

        await employeeRepository.AddAsync(employee);
        await unitOfWork.CommitAsync();
        return new Response<ClientFacingFormDTO>(employeeDTO, "Successful operation");
    }


}

