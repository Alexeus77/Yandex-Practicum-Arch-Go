public class TemperatureResponse
{
    public double Value { get; set; }
    public string Unit { get; set; } = "Celsius";
    public DateTime Timestamp { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
    public string SensorID { get; set; }
    public string SensorType { get; set; }
    public string Description { get; set; }
}