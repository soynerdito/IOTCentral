namespace IOTCentral.Data
{
    /// <summary>
    /// Allow organizing devices
    /// </summary>
    public class DeviceGroup : OwnedModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}