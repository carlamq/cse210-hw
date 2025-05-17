using System;

public class Resume
{
    public string _name;

    // Make sure to initialize your list to a new List before you use it.
    public List<Job> _jobs = new List<Job>();

    public void Display() //This method will display the resume infirmation. Have not the
    //string[] args because it is not main method and because have any parameters.
    {

        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine("Jobs:");

            // Notice the use of the custom data type "Job" in this loop
            foreach (Job job in _jobs)
            {
                job.Display();
            }
        }
    }
}