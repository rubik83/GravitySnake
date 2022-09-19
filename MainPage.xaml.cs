namespace GravitySnake;


public partial class MainPage : ContentPage
{
    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        var drawable = (GraphicsDrawable)gv.Drawable;
        var acc_data = e.Reading;
        drawable.Prog.Update(acc_data.Acceleration.X, acc_data.Acceleration.Y);
    }
    public MainPage()
    {
        if (Accelerometer.Default.IsSupported)
        {
            Accelerometer.Default.Start(SensorSpeed.Game);
            Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
        }
        InitializeComponent();

        var ts = TimeSpan.FromMilliseconds(20);
        Dispatcher.StartTimer(ts, TimerLoop);
    }
    private bool TimerLoop()
    {
        gv.Invalidate();
        return true;
    }
}
