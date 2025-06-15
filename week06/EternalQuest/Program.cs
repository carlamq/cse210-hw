//Exeeding Requirements: I add a BadHabitGoal class that allows users to track bad habits,
//where user can earn points for not relapsing and lose points if relapsing.
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();// Start the goal management system
    }
}