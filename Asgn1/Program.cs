using System;
using System.Collections;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            //the below n,n2,n3 and k value for the print pattern,printseries and USFnumbers confirms that entered input is an integer always as we are declaring them as int.
            //This value cannot accept string or decimal and will fail to process further if the user forcefully inputs
            //If the n,n2,n3 and k value below is not pre-defined but entered by the user during runtime then we can use "int.Parse" function to confirm the valid input format
            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            //the below words value for the PalindromePairs confirms that entered input is string always as we are declaring it as string
            //This value cannot accept int or decimal and will fail to process further if the user forcefully inputs
            //The handling of an empty string input is handled in the function
            string[] words = {"abcd","dcba","lls","s","sssll"};
            PalindromePairs(words);

            Stones();


        }


        private static void PrintPattern(int n)
        {
            try
            {
                //SElf refection:This program took me 2hrs,was able to implement various iterative loops
                //Initializing the below mentioned boolean variable,which will be used for reference for while loop functionality
                bool stopProgram = false;
                //While loop functions only based on True/False values for stopProgram
                while (stopProgram == false)
                {
                    //Corner case covered for non positive integers
                    //If loop checks whether the n value is assigned is positive or not,if n is not positive it enters else loop
                    if (n > 0)
                    {
                        Console.WriteLine("Output for PrintPattern is as below:");
                        //the below while loop helps to print the output to the next line once the required number of sequnce is printed in a given row
                        while (n != 0)
                        {

                            //the below for loop helps to print the sequnce of numbers untill last list in a single row
                            for (int i = n; i > 0; i--)
                            {
                                Console.Write(i);
                            }
                            //the below code shifts the cursor to next line
                            Console.WriteLine("\n");
                            //based on below n value,the while loop executes and while loop stops executing once n value is 0
                            n--;
                        }
                        //the below value sets the boolean value to true once the n value reaches 0,thereby exiting the logic
                        stopProgram = true;
                    }
                    else
                    {
                        //if the n value is forcefully set to negative or zero value,the below message will be shown to the user which helps to set the required n value
                        Console.Write("Kindly enter a valid positive integer value input for PrintPattern function.Exiting the application");
                        //allocating true value stops the entry to while loop
                        stopProgram = true;
                    }

                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }


        private static void PrintSeries(int n2)
        {
            try
            {
                //SElf refection:This program took me 2hrs,was able to implement various iterative loops
                Console.Write("\n");
                //Initializing the below mentioned boolean variable,which will be used for reference for while loop functionality
                bool stopProgram = false;
                //While loop functions only based on True/False values for stopProgram
                while (stopProgram == false)
                {
                    //Corner case covered for non positive integers
                    //If loop checks whether the n2 value is assigned is positive or not,if n2 is not positive it enters else loop
                    if (n2 > 0)
                    {
                        Console.WriteLine("Output for PrintSeries is as below:");
                        //Initializing b values to use in below logic
                        int b = 0;

                        //the below for makes sure that the logic runs based on users input(n2) value and exits once n2 value becomes zero
                        for (int i = 1; n2 != 0; i++)
                        {

                            //below c value calculates each element in the series by adding to the both current and previous element
                            int c = b + i;
                            //below makes sure that the output is printed on same row and each element is seperated by comma
                            Console.Write(c + ",");
                            //the below value stores current c value and passes it for caluclation in the above stated step
                            b = c;
                            n2--;

                            //the below if loop checks whether the element printed is the last element,if true the print value removes comma seperator
                            if (n2 == 1)
                            {

                                int e = b + i + 1;
                                //comma seperator removed
                                Console.Write(e);
                                //decrementing n2(required for "FOR" loop condition)
                                n2--;
                            }
                        }
                        //the below value sets the boolean value to true once the n2 value reaches 0,thereby exiting the logic
                        stopProgram = true;
                        Console.Write("\n");

                    }
                    else
                    {
                        //if the n value is forcefully set to negative or zero value,the below message will be shown to the user which helps to set the required n value
                        Console.Write("Kindly enter a valid positive integer value for PrintSerries function.Exiting the application");
                        //allocating true value stops the entry to while loop
                        stopProgram = true;
                    }

                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }


        public static string UsfTime(string s)
        {
            try
            {
                //SElf refection:This program took me a lot of time,it helped to increase my logical thinking
                Console.Write("\n");
                //trimming the string input to remove AM or PM values
                char[] MyChar = { 'A', 'M', 'P', 'a', 'm', 'p' };
                string someString = s.TrimEnd(MyChar);
                //Corner case covered for ivalid date format and accepting only 12 hour date format
                //cross checking whether the input date format is correct
                DateTime someDate;

                someDate = DateTime.Parse(someString);
                
             

                //calculating input time to total seconds
                TimeSpan ts = TimeSpan.Parse(someString);
                double totalSeconds = ts.TotalSeconds;
                Console.WriteLine("Output for UsfTime is as below:");
                bool stopProgram = false;
                while (stopProgram == false)
                {
                    //cross checking whether the input date format is in 12 hour format or not,exits the program if its not
                    if (totalSeconds > 43200)
                    {
                        Console.WriteLine("Kindly enter time in 12 hour format.As the input time is an invalid input(more than 12 hours),exiting the application");
                        stopProgram = true;
                    }

                    else
                    {
                        //Usual time:1hour= 3600 sec(60*60)[values taken from 01<= hh<=12, 00<=mm,ss,<=60]
                        //USF time: 1 hour =2655 sec(59*45)[values taken from 01<= UU<=36, 00<=SS<=59,00<=FF<=45]
                        //Usf time/ normal time = 2.266536673166342[value based on above two]
                        //step1:Calculate totalUSFSeconds
                        //convert to USF time
                        double totalUSFSeconds = 2.266536673166342 * (totalSeconds);
                        //step2:calculating hour value
                        //calculating hour value by diving the totalusfseconds with the maximum number of seconds(2655) for 1 hour
                        Double hour = totalUSFSeconds / 2655;
                        //taking only integer value after diving the above value
                        int hours = (int)(hour);


                        //step3:calculating minute value
                        //below caluclate how many seconds are already covered by hours value
                        Double totalSecondinhour = hours * (2655);
                        //below caluclate the remaining seconds
                        Double remainingsec = ((totalUSFSeconds) - (totalSecondinhour));
                        //using remaining seconds calculating minute value by diving with maximum minutes
                        Double minute = remainingsec / 59;
                        //taking only integer value after diving the above value
                        int minutes = (int)(minute);


                        //step3:calculate second value
                        //below caluclate how many seconds are already covered by minutes value
                        Double totalSecondinminute = minutes * (59);
                        //below caluclate the remaining seconds
                        Double remainingseconds = ((remainingsec) - (totalSecondinminute));
                        //taking only integer value after diving the above value
                        int seconds = (int)(remainingseconds);


                        String t = (hours + ":" + minutes + ":" + seconds);
                        stopProgram = true;
                        return t;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }


        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                //SElf refection:This program took me 1hr and tthisprogram looked simple
                Console.Write("\n");
                //Corner case covered for non positive integers and invalid denominator values
                //If loop checks whether the n3,k values assigned are positive or not and dividend is divisible by divisor.If not it enters else loop
                if ((n3 > 0) && (k > 0) && (n3 % k == 0))
                {
                    Console.WriteLine("Output for UsfNumbers is as below:");

                    //the below for initializes i to print output from '1',and stops executing once n3 is becomes 0
                    for (int i = 1; n3 != 0; i++)
                    {
                       //if the number(i) is a multiple of both 3 & 5,then the number will be printed as US
                        if ((i % 3 == 0) & (i % 5 == 0))
                        {
                            Console.Write("US" + " ");
                        }
                        //if the number(i) is a multiple of both 7 & 5,then the number will be printed as SF
                        else if ((i % 5 == 0) & (i % 7 == 0))
                        {
                            Console.Write("SF" + " ");
                        }
                        //if the number(i) is a multiple of both 3 & 7,then the number will be printed as UF
                        else if ((i % 3 == 0) & (i % 7 == 0))
                        {
                            Console.Write("UF" + " ");
                        }
                        //if the number(i) is a multiple of both 3 only,then the number will be printed as U
                        else if (i % 3 == 0)
                        {
                            Console.Write("U" + " ");
                        }
                        //if the number(i) is a multiple of both 5 only,then the number will be printed as S
                        else if (i % 5 == 0)
                        {
                            Console.Write("S" + " ");
                        }
                        //if the number(i) is a multiple of both 7 only,then the number will be printed as F
                        else if (i % 7 == 0)
                        {
                            Console.Write("F" + " ");
                        }
                        //if the number(i) is not a multiple of 3,5 & 7 ,then the number itself will be printed 
                        else
                        {

                            Console.Write(i + " ");
                        }
                        //decrementing n3(required for "FOR" loop condition)
                        n3--;

                        //whenever the dividend is divisible by divisor the curosr moves to the next line
                        if (n3 % k == 0)
                            Console.WriteLine("\n");

                    }
                }
                else
                {
                    //if the n value is forcefully set to negative or zero value,the below message will be shown to the user which helps to set the required n value
                    Console.Write("Kindly enter a valid positive integer value for USFnumbers function,making sure that the dividend is greater than or equal to divisor.Exiting the application");
                    //allocating true value stops the entry to while loop
                    //stopProgram = true;
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }



        public static void PalindromePairs(string[] words)
        {
            try
            {
                //SElf refection:This program took me a lot of time,I was able to solve this after seeing some youtube videos
                //Corner case covered for empty,null values
                //Initializing the below mentioned boolean variable,which will be used for reference for while loop functionality
                bool stopProgram = false;
                //While loop functions only based on True/False values for stopProgram
                while (stopProgram == false)
                {
                    Console.Write("\n");
                    Console.WriteLine("Output for PalindromePairs is as below:");
                    //below loop checks for the existence of no input({}) string,if it exists the program exits with the proper message
                    if (words.Length == 0)
                    {
                        Console.WriteLine("There are no string input.Kindly input your string once more");
                        stopProgram = true;
                    }
                    //the below for initializes i and stops executing once its value is greater than the length of the words
                    for (int i = 0; i < words.Length; i++)
                    {
                        
                        //below loop checks for the existence of the empty(null or "") string,if it exists the program exits with the proper message
                       if (string.IsNullOrEmpty(words[i]))
                        {
                            Console.WriteLine("There is an empty string input.Kindly input your string once more with no empty values");
                            stopProgram = true;
                        }
                        //enter else once the input is proper without nulls
                        else
                        {
                          
                            //This for loop is used to concatinate the exisiting array element with all other elements.
                            //For example,if array has 3 elements then first element should be concatinated with all other elemnts[(0,1),(0,2)].In this example i is 1st elemts and j is 2nd element
                            for (int j = 0; j < words.Length; j++)
                            {
                                //as contination between same array elemnts(ex:[2,2]) is not required,a check is passed to skip concatination
                                if (i != j)
                                {
                                    //all concatinated results are stores in atemporary variable a
                                    string a = string.Concat(words[i], words[j]);

                                    char[] s1 = a.ToCharArray();
                                    //reversing the concatinated string and storing in rev1
                                    Array.Reverse(s1);
                                    String rev1 = new string(s1);
                                    
                                    //below prints output only if the pairs are palidrome based on comparision with concatinated string and reverse concatinated string
                                    if (a == rev1)
                                    {
                                        
                                     Console.Write("[" + i + "," + j + "]");
                                    }
                                }
                            }
                            //allocating true value stops the entry to while loop
                            stopProgram = true;
                            
                        }
                     
                    }

                }
                Console.Write("\n");

            }
            catch
            {

                Console.WriteLine("Exception occured while computing     PalindromePairs()");
            }
        }

        public static void Stones()
        {
            try
            {
                Console.Write("\n");
                //SElf refection:This program took me a lot of time,the introduction book really helped me to go through concepts and implement
                //Looking for more assignments of the similar type which helps students to research,learn from their mistakes and implement which not only increase language(c#) skills but also logical thinking
                //Corner case covered for non positive integers
                //declaring a string and integer value to accept input from user
                string val;
                int res;

                Console.WriteLine("Enter total number of stones available: ");
                //storing the input value in string
                val = Console.ReadLine();

                // assuring the input value is integer only
                res = int.Parse(val);
                Console.WriteLine("Output for Stones is as below:");
                //the following logic works only when stones entered are positive else it throws error message
                if (res > 0)
                {
                    
                    
                        bool stopProgram = false;
                        //intilizing n1 to the input entered and few other initializations
                        int n1 = res;
                        int n = 0;
                        int player1 = 0;
                        int stone4 = 0;
                        int stone5 = 0;
                        ArrayList array = new ArrayList();
                        
                        int a = 0;
                        //below loop continues to execute untill stones are removed
                        while ((n1 > 0) && (stopProgram == false))
                        {

                            if (n1 >= 3)
                            {
                                //as each player should pick maximum 3 stones,a random generator is created for 1,2 & 3 numbers
                                Random rnd4 = new Random();
                                //stone4 value stores the number of stones picked by player1
                                stone4 = rnd4.Next(1, 3);
                                //below n value stores the number of stones left after picked up by player1
                                n = ((n1) - (stone4));

                                //overwriting n1 value as per new calculation
                                n1 = n;

                                //initializing the below value to announce winner based on its value.Assuming initially that player1 is winner
                                player1 = 1;
                                //adding the stone spicked by player1 to array
                                array.Add(stone4);
                                a++;
                                //the below condition checks if there are no stones left 
                                if (n == 0)
                                {
                                    stopProgram = true;
                                }
                            }
                            //below executes if there are only two stones 
                            else if (n1 == 2)
                            {
                                //as there two stones,generating random selection for numbers 1 & 2 using random generator
                                Random rnd4 = new Random();
                                stone4 = rnd4.Next(1, 2);
                                //below n value stores the number of stones left after picked up by player1
                                n = ((n1) - (stone4));
                                //overwriting n1 value as per new calculation
                                n1 = n;
                                player1 = 1;
                                //adding the stone spicked by player1 to array
                                array.Add(stone4);
                                a++;
                                //the below condition checks if there are no stones left 
                                if (n == 0)
                                {
                                    
                                    stopProgram = true;
                                }
                            }
                            //below checks If there is only one stone then player1 is winner
                            else if (n1 == 1)
                            {

                                stone4 = 1;
                                n = 0;

                                

                                player1 = 1;

                                array.Add(1);
                                //as there are no stones left,stoppin the program
                                stopProgram = true;

                            }
                            //below logic checks if there are three or more stones after player1 has picked up
                            if (n >= 3)
                            {
                                //as each player should pick maximum 3 stones,a random generator is created for 1,2 & 3 numbers

                                Random rnd5 = new Random();
                                //stone5 value stores the number of stones picked by player2
                                stone5 = rnd5.Next(1, 3);
                                //below n2 value stores the number of stones left after picked up by player2
                                int n2 = ((n) - (stone5));

                                //the left over stones are now ready for player1 to pick,this can be done by assiging the below value
                                n1 = n2;
                                player1 = 0;
                                //adding the stone spicked by player2 to array
                                array.Add(stone5);
                                a++;
                                if (n2 == 0)
                                {
                                    stopProgram = true;
                                }
                            }
                            //below logic checks if there are two stones after player1 has picked up
                            else if (n == 2)
                            {

                                Random rnd6 = new Random();

                                stone5 = rnd6.Next(1, 2);
                                
                                int n2 = ((n) - (stone5));

                                
                                n1 = n2;
                                player1 = 0;
                               
                                array.Add(stone5);
                                a++;
                                if (n2 == 0)
                                {
                                    stopProgram = true;
                                }
                            }
                            //below logic checks if there is one stone after player1 has picked up
                            else if (n == 1)
                            {


                                stone5 = 1;
                               
                                n1 = 0;
                                player1 = 0;
                                
                                array.Add(1);
                                stopProgram = true;
                            }
                            

                        }

                        //below player1 value helps to determine who picked the last stone,this value is set in respective loops above
                        //the below condition helps to print the seuqnce of stone picked by each player if player1 is winner
                        if (player1 == 1)
                        {
                            
                            for (int i = 0; i < array.Count; i++)
                            {
                                if (array.Count == 1)
                                {
                                    Console.Write("[" + array[i] + "]");
                                }
                                else
                                {
                                    if (i == 0)
                                    {

                                        Console.Write("[" + array[i] + ",");
                                    }
                                    else if (i == (array.Count - 1))
                                    {
                                        Console.Write(array[i] + "]");
                                    }
                                    else
                                    {
                                        Console.Write(array[i] + ",");
                                    }
                                }
                            }

                        }
                        //the output prints as false if player1 is not winner
                        else
                        {
                            Console.WriteLine("False");

                        }

                    
                }
                else
                {
                    Console.Write("Kindly enter a valid positive integer value for Stones function.Exiting the application");
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }


    }
}
