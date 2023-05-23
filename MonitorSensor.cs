using FanControl.Plugins;
using System.Windows.Forms;

namespace Monitor_detection_Plugin;


public class MonitorSensor : IPluginSensor
{
    internal MonitorSensor(int index, string type, string id, string name)
    {
        Index = index;
        Type = type;
        Id = id;
        Name = name;
    }

    static public float get_status()
    {
        // var val = 50f;
        // System.Management.ManagementObjectSearcher monitorObjectSearch = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");
        // int Counter = monitorObjectSearch.Get().Count;
        var monitor_count = System.Windows.Forms.SystemInformation.MonitorCount;
        if (monitor_count > 1)
        {
            return 100f;
        }
        else
        {
            return 0f;
        }
        
    }
    static public MonitorSensor[] GetBatterySensors()
    {
        var list = new List<MonitorSensor>();
        var _sensor = new MonitorSensor(1, "Temperature", "bat_Temperature", "ac status");
        //var AC_status = SystemInformation.PowerStatus.PowerLineStatus;
        //Console.Write(AC_status);
        //var Charging_status = SystemInformation.PowerStatus.BatteryChargeStatus;

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