using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing",
    "This activity will help you relax by walking you through breathing\n in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Start();

        int elapsed = 0;
        bool breathIn = true;

        while (elapsed < _durationSeconds)
        {
            if (breathIn)
            {
                Console.Write("Breathe in... ");
            }
            else
            {
                Console.Write("Breathe Out... ");
            }

            int pauseTime = 4;
            ShowCountdown(pauseTime);
            elapsed += pauseTime;
            breathIn = !breathIn;
        }

        End();
    }
}