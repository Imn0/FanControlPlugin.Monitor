using FanControl.Plugins;

namespace FanControl.Monitor_detection_Plugin;


public class MonitorSensor : IPluginSensor
{
    internal MonitorSensor(int index, string type, string id, string name)
    {
        Index = index;
        Type = type;
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Converts monitor count to temperature.
    /// </summary>
    /// <returns>Value returned is how many monitors are connected, 1C one monitor, 2C two monitors etc.</returns>
    static public float Get_status()
    {

        var monitor_count = SystemInformation.MonitorCount;
        
        return monitor_count;
    }
    static public MonitorSensor[] GetBatterySensors()
    {
        var list = new List<MonitorSensor>();
        var _sensor = new MonitorSensor(1, "Temperature", "bat_Temperature", "monitor count");
       
        list.Add(_sensor);
        return list.ToArray();

    }
    internal string Type { get; }
    internal int Index { get; set; }
    public string Name { get; }

    public float? Value { get; internal set; }

    public string Id { get; }

    public void Update() { }

};