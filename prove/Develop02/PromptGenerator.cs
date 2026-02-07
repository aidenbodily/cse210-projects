using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> _prompts;
    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What emotions showed up most strongly for you today? ",
            "What moment from today keeps replaying in your mind and why? ",
            "What is one small thing you are grateful for today that you might normally overlook? ",
            "What challenged your patience today and how did you respond? ",
            "What did today teach you about yourself? ",
            "Did you make a mistake today that helped you learn or grow? ",
            "What drained your energy today and what helped restore it? ",
            "Did your actions today align with the person you want to become? ",
            "Who crossed your mind today and why do you think that was? ",
            "Did you help someone today, even in a small or quiet way? ",
            "What conversation today had the biggest impact on you? ",
            "What intention would you like to carry into tomorrow? ",
            "Where did you feel guided or protected today? ",
            "Did you face a moment where you had to trust God instead of yourself today? ",
            "What prayer, verse or thought stayed with you throughout the day? ",
            "Where did you struggle spiritually today and what might that reveal? ",
            "What are you proud of yourself for today? ",
            "What do you need to surrender or let go of right now? ",
        };
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}