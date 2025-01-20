using System.ComponentModel.DataAnnotations;
using MediatR;
using ProfilesService.BusinessLogic.Domain.Entities;

namespace ProfilesService.Application.Commands.DoctorCommands;

public class CreateDoctorCommand : BaseProfile, IRequest<bool>
{
    [Required(ErrorMessage = "DateOfBirth is required.")]
    public DateTime DateOfBirth { get; set; }
    public int? AccountId { get; set; }
    [Required(ErrorMessage = "SpecializationId is required.")]
    public int SpecializationId { get; set; }
    [Required(ErrorMessage = "OfficeId is required.")]
    public string OfficeId { get; set; }
    [Required(ErrorMessage = "CareerStartYear is required.")]
    public int CareerStartYear { get; set; }
    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; }
}