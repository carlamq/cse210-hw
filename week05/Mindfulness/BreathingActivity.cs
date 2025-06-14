using System;
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly " +
            "Clear your mind and focus on your breathing.")
    {//the constructor take from the base class activity, and sets the name, description and duration of the activity
        //in that order
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool breathIn = true;

        while (DateTime.Now < endTime)
        {
            if (breathIn)
            {
                AnimatedBreath("Inhale...", 4);
            }
            else
            {
                AnimatedBreath("Exhale...", 4);
            }

            breathIn = !breathIn;
            Console.Write("\b");
        }

        DisplayEndingMessage();
    }
    public void AnimatedBreath(string text, int totalDuration)
    {
        int length = text.Length;//length of the text
        int fastPart = length / 2;//divide the text in two parts, fast and slow
        int slowPart = length - fastPart;

        //calculate the timefor each part
        int fastTime = (int)(totalDuration * 0.3 * 1000); // 30% of the time
        int slowTime = (int)(totalDuration * 0.7 * 1000); // 70% of the time

        int fastDelay = fastTime / fastPart;//calculate the delay for each character
        int slowDelay = slowTime / slowPart;

        //Shows one bye one the characters of the text
        //fast part
        for (int i = 0; i < fastPart; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(fastDelay);
        }
        //sloww part
        for (int i = fastPart; i < length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(slowDelay);
        }
        Console.WriteLine();
    }
}
