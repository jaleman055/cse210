using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startDate = 2019;
        job1._endDate = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startDate = 2022;
        job2._endDate = 2023;

        /*
        Console.WriteLine(job1._company);
        Console.WriteLine(job2._company);
        */

        job1.Display();
        job2.Display();

        Resume myResume = new Resume();
        myResume._name = "Julio Aleman";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        Console.WriteLine(myResume._jobs[0]._jobTitle);
        myResume.Display();
    }

    class Job
    {
        public string _jobTitle;
        public string _company;
        public int _startDate;
        public int _endDate;

        public void Display()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startDate}-{_endDate}");
        }
    }

    class Resume
    {
        public string _name;
        public List<Job> _jobs = new List<Job>();

        public void Display()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine("Jobs:");
            foreach (Job job in _jobs)
            {
                job.Display();
            }
        }
    }

}