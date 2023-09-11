using FanControl.Plugins;

namespace FanControl.Monitor_detection_Plugin;

public class Monitor_plugin : IPlugin2
{
    private MonitorSensor[] _sensor = Array.Empty<MonitorSensor>();
    public string Name => "Monitor Count";

    public void Initialize()
    {
    }

    public void Close()
    {
        _sensor = Array.Empty<MonitorSensor>();
    }

    public void Load(IPluginSensorsContainer container)
    {
        _sensor = MonitorSensor.GetBatterySensors();
        foreach (var sensor in _sensor)
        {
            sensor.Value = MonitorSensor.Get_status();
            container.TempSensors.Add(sensor);

        }
    }

    public void Update()
    {
        foreach (var sensor in _sensor)
        {
            sensor.Value = MonitorSensor.Get_status();
        }
    }
}


