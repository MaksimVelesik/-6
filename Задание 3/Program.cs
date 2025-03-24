using System;

public delegate void VolumeChangeHandler(int newVolume);

class VolumeControl
{
    private int volume;

    public event VolumeChangeHandler VolumeChanged;

    public int Volume
    {
        get => volume;
        set
        {
            if (volume != value)
            {
                volume = value;
                OnVolumeChanged(volume);
            }
        }
    }

    protected virtual void OnVolumeChanged(int newVolume)
    {
        VolumeChanged?.Invoke(newVolume);
    }
}

class Display
{
    public void OnVolumeChanged(int newVolume)
    {
        Console.WriteLine($"Уровень громкости изменен: {newVolume}");
    }
}

class SpeakerSystem
{
    public void OnVolumeChanged(int newVolume)
    {
        Console.WriteLine($"Громкость динамиков установлена на: {newVolume}");
    }
}

class Program
{
    static void Main()
    {
        VolumeControl volumeControl = new VolumeControl();
        Display display = new Display();
        SpeakerSystem speakerSystem = new SpeakerSystem();

        volumeControl.VolumeChanged += display.OnVolumeChanged;
        volumeControl.VolumeChanged += speakerSystem.OnVolumeChanged;

        volumeControl.Volume = 30;
        volumeControl.Volume = 50;
        volumeControl.Volume = 70;

        Console.WriteLine("Изменения громкости завершены.");
    }
}