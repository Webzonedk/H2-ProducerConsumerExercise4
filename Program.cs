using System;
using System.Threading;

namespace H2ProducerConsumerExercise4
{
    class Program
    {
        public static string[] basket = new string[] { "one", "two", "three", "four", "five" };//Creating the Array/Buffer
        public static volatile int counter = 0;//Just a counter to keep track of the indexnumber in the array
        public static Random random = new Random();//initialising a random
        static void Main(string[] args)
        {
            Thread producer = new Thread(Produce);//initializing the threads
            Thread consumer = new Thread(Consume);
            producer.Start();//Starts the threads
            Thread.Sleep(100);//Just a little break to get things syncronized
            consumer.Start();
        }

        static void Produce()//Method to produce to the buffer
        {

            while (true)//A loop to ensure that the thread keeps running
            {
                for (int j = 0; j < basket.Length + 5; j++) //Running a loop for 10 times
                {
                    //int sleepProduce = random.Next(50, 1000); (just played around with some random timing for the sleep to visualize what is happening)
                    try//Do the following code if possible
                    {
                        if (counter < basket.Length)//If counter is less than the buffers length, then write the content of the array with index number equal to the counter and add one to the counter
                        {
                            Console.WriteLine($"Producer produced: {basket[counter]}");
                            counter++;
                            // Thread.Sleep(sleepProduce); (just played around with some random timing for the sleep to visualize what is happening)
                        }
                        else//Else write that Producer could not produce the content of the array with indexnumber equal to counter-1
                        {
                            Console.WriteLine($"Producer was not allowed to produce {basket[counter - 1]}");
                            //Thread.Sleep(sleepProduce); (just played around with some random timing for the sleep to visualize what is happening)
                        }
                    }
                    finally//No content in here for now, as it was not nessesary to make the code run
                    {
                    }
                }
                        Thread.Sleep(100);//Just a little sleep to make it look pretty
            }
        }

        static void Consume()//Method to consume from the buffer
        {

            while (true)//A loop to ensure that the thread keeps running
            {

                for (int j = 0; j < basket.Length + 5; j++)//Running a loop for 10 times
                {
                    //  int sleepConsume = random.Next(50, 1000); (just played around with some random timing for the sleep to visualize what is happening)
                    try//Do the following code if possible
                    {
                        if (counter > 0)//If counter is higher than the buffers length, then write the content of the array with index number equal to the counter-1 (to avoid out of bounce) and add one to the counter
                        {
                            Console.WriteLine($"Consumer consumed: {basket[counter - 1]}");
                            counter--;
                            //Thread.Sleep(sleepConsume); (just played around with some random timing for the sleep to visualize what is happening)
                        }
                        else//Else write that consumer could not consume the content of the array with indexnumber equal to counter
                        {
                            Console.WriteLine($"Consumer was not allowed to Consume {basket[counter]}");
                            // Thread.Sleep(sleepConsume); (just played around with some random timing for the sleep to visualize what is happening)
                        }
                    }
                    finally//No content in here for now, as it was not nessesary to make the code run
                    {

                    }
                }
                        Thread.Sleep(100);//Just a little sleep to make it look pretty
            }
        }
    }
}
