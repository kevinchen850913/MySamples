// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

/*//微軟範例程式
 Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
Thread.Sleep(10);
stopWatch.Stop();
// Get the elapsed time as a TimeSpan value.
TimeSpan ts = stopWatch.Elapsed;

// Format and display the TimeSpan value.
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
Console.WriteLine("RunTime " + elapsedTime);*/                        

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
Spin(stopWatch, 100);
stopWatch.Stop();
string elapsedTime = String.Format("{0:00}",
    stopWatch.ElapsedMilliseconds);
Console.WriteLine("RunTime " + elapsedTime);
Console.WriteLine("*****");

static void Spin(Stopwatch w, long duration)
{
    long current = w.ElapsedMilliseconds;
    while ((w.ElapsedMilliseconds - current) < duration)
        Thread.SpinWait(1);
}