using Api.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Features.Desks.Commands.CreateDesk
{
    public class CreateDeskRequest
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal PricePerHour { get; set; }


        [FromQuery]
        public DeskChairTypeEnum ChairType { get; set; }

        
        public bool HasMouse { get; set; }

        public bool HasHeadphones { get; set; }

        public bool HasWebcam { get; set; }

        public bool HasLamp { get; set; }

        public bool HasEthernet { get; set; }

        public bool HasUsbHub { get; set; }
    }
}