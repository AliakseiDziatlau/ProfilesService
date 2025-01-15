using System.ComponentModel.DataAnnotations;

namespace ProfilesService.BusinessLogic.Domain.Entities;

public abstract class BaseProfile
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}