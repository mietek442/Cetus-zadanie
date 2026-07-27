

using Api.Domain.Models;

namespace Api.Features.Desks.Queries.GetAllDesks
{
    public static class GetAllDeskMapper
    {
        public static DeskResult ToDeskResult(this Desk desk)
        {
            return new DeskResult
            {
                Id = desk.Id,
                Name = desk.Name,
                Description = desk.Description,
                IsAvailable = desk.IsAvailable,
                PricePerHour = desk.PricePerHour,
                ChairType = desk.ChairType,
                HasMouse = desk.HasMouse,
                HasHeadphones = desk.HasHeadphones,
                HasWebcam = desk.HasWebcam,
                HasLamp = desk.HasLamp,
                HasEthernet = desk.HasEthernet,
                HasUsbHub = desk.HasUsbHub,
               
            };
        }
    }
}