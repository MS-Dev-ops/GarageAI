using GarageAI.Application.Mechanics.DTOs;

namespace GarageAI.Application.Mechanics.Interfaces;

public interface IMechanicRepository
{
    Task<List<MechanicDto>> GetMechanicsAsync();
}