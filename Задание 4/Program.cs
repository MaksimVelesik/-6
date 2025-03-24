using System;

public class BatteryMonitor
{
    public event EventHandler BatteryLow;

    private int batteryLevel;

    public int BatteryLevel
    {
        get => batteryLevel;
        set
        {
            if (batteryLevel != value)
            {
                batteryLevel = value;
                if (batteryLevel < 20) // Уровень заряда ниже 20%
                {
                    OnBatteryLow(EventArgs.Empty);
                }
            }
        }
    }

    protected virtual void OnBatteryLow(EventArgs e)
    {
        BatteryLow?.Invoke(this, e);
    }
}

public class PowerManager
{
    private BatteryMonitor batteryMonitor;

    public PowerManager(BatteryMonitor monitor)
    {
        batteryMonitor = monitor;
        batteryMonitor.BatteryLow += OnBatteryLow;
    }

    private void OnBatteryLow(object sender, EventArgs e)
    {
        PowerSaver powerSaver = new PowerSaver();
        powerSaver.EnablePowerSavingMode();

        UserNotifier userNotifier = new UserNotifier();
        userNotifier.NotifyUser();
    }
}

public class PowerSaver
{
    public void EnablePowerSavingMode()
    {
        Console.WriteLine("Режим энергосбережения включен.");
    }
}

public class UserNotifier
{
    public void NotifyUser()
    {
        Console.WriteLine("Предупреждение: уровень заряда батареи низкий!");
    }
}

class Program
{
    static void Main()
    {
        BatteryMonitor batteryMonitor = new BatteryMonitor();
        PowerManager powerManager = new PowerManager(batteryMonitor);

        batteryMonitor.BatteryLevel = 30; 
        batteryMonitor.BatteryLevel = 15; 

        Console.WriteLine("Контроль заряда батареи завершен.");
    }
}