using Api.Shared.Enums;

namespace Api.Features.Desks.Queries.GetAllDesks
{
    public class DeskResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsAvailable { get; set; }

        public decimal PricePerHour { get; set; }

        public DeskChairTypeEnum ChairType { get; set; }

        public bool HasMouse { get; set; }

        public bool HasHeadphones { get; set; }

        public bool HasWebcam { get; set; }

        public bool HasLamp { get; set; }

        public bool HasEthernet { get; set; }

        public bool HasUsbHub { get; set; }

        
    }
}
