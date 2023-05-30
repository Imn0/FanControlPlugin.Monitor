using FanControl.Plugins;

namespace Monitor_detection_Plugin;

public class Monitor_plugin : IPlugin2
{
    public string Name => "Dock status";

    private MonitorSensor[] sensors = Array.Empty<MonitorSensor>();

    public void Initialize()
    {
    }

    public void Close()
    {
        sensors = Array.Empty<MonitorSensor>();
    }

    public void Load(IPluginSensorsContainer container)
    {
        sensors = MonitorSensor.GetBatterySensors();
        foreach (var sensor in sensors)
        {
            sensor.Value = MonitorSensor.get_status();
            container.TempSensors.Add(sensor);

        }
    }

    public void Update()
    {
        foreach (var sensor in sensors)
        {
            sensor.Value = MonitorSensor.get_status();
        }
    }
}


