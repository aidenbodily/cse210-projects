using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        // uses the shared intro from the base class
        DisplayStartingMessage();

        // keep looping breaths until time is up
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("\nBreathe out... ");
            ShowCountdown(6);
        }

        DisplayEndingMessage();
    }
}
