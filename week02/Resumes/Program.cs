using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job(); //creating a new class for the job
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2020;
        job1._endYear = 2022;

        Job job2 = new Job();//creating a new class for the job with the variable job2
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();//creating a new class for the resume
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);//adding the job1 to the resume
        myResume._jobs.Add(job2);//adding the job2 to the resume

        myResume.Display();//myResume should display the resume
    }
}