using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = new List<int>();
            Console.Write("Count of candidates: ");
            int countOfCandidates = int.Parse(Console.ReadLine());
            for (int i = 0; i< countOfCandidates; i++)
            {
                Console.Write($"Offer of candidate №{i+1}: ");
                targets.Add(int.Parse(Console.ReadLine()));
            }
            PrintWinner(targets);
            FindOffer(targets);
            EvenOffers(targets);
            FindAverage(targets);
            FindBigOffers(targets);

            int sort = 0;
            do { 
            Console.Write("Do you prefer bubble sort(1) or insertion sort(2)? Enter 1 or 2: ");
            sort=int.Parse(Console.ReadLine());
            
                switch (sort)
                {
                    case 1:
                        BubbleSort(targets);
                        break;
                    case 2:
                        InsertionSort(targets);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }while(sort!=1 && sort!=2);
            PrintList(targets);


        }
        public static void PrintWinner(List<int> offers)
        {
            if (offers.Count == 0) return;
            List<int> indexes = new List<int>();
            double maxOffer = offers.Max();
            for (int i = 0; i < offers.Count; i++)
            {
                if (offers[i] == maxOffer)
                {
                    indexes.Add(i);
                }
            }
            if (indexes.Count > 1)
            {
                Console.WriteLine("\nThe winners with the highest offer are:");
                foreach (int index in indexes)
                {
                    Console.WriteLine($"№{index + 1} with the offer being {offers[index]} euro.");
                }
                Console.WriteLine();
            }
            else if (indexes.Count == 1)
            {
                int index = indexes[0];
                Console.WriteLine($"\nThe winner with the highest offer is №{index + 1} with the offer being {offers[index]} euro.\n");
            }
        }
        public static void FindOffer(List<int> offers)
        {
            //Сложност : O(N)
            int count = 0;
            bool found = false;
            List<int> foundIndexes = new List<int>();
            Console.Write("Enter an offer to search: ");
            double offer = double.Parse(Console.ReadLine());
            for (int i = 0; i < offers.Count; i++)
            {
                if (offers[i] == offer)
                {
                    foundIndexes.Add(i);
                }
            }

            if (foundIndexes.Count > 0)
            {
                List<int> candidateNumbers = new List<int>();

                for (int i = 0; i < offers.Count; i++)
                {
                    if (offers[i] == offer)
                    {
                        candidateNumbers.Add(i + 1);
                    }
                }

                string candidatesList = string.Join(", ", candidateNumbers);
                Console.WriteLine($"The offer you searched exists at candidate №: {candidatesList} with the value: {offer} euro.");
                Console.WriteLine($"Count of found offers: {foundIndexes.Count}");
            }
            else
            {
                Console.WriteLine("The offer you searched doesn't exist.");
            }
        }
        public static void EvenOffers(List<int> offers)
        {
            List<int> evenOffers=new List<int>();
            foreach (int item in offers)
            {
                if (item%2==0)
                {
                    evenOffers.Add(item);
                }
            }
            Console.Write("\nEven offers: ");
            foreach (int item in evenOffers)
            {
                Console.Write(item+"euro ");
            }
            Console.WriteLine();
        }
        public static void FindAverage(List<int> offers)
        {
            int sum = 0;
            foreach(var item in offers)
            {
                sum += item;
            }
            double average = (double)sum/offers.Count;
            Console.WriteLine($"\nThe average of all offers is {average:F2} euro.");
            Console.WriteLine();
        }
        public static void FindBigOffers(List<int> offers)
        {
            List<int> bigOffers=new List<int>();
            bool existingBigOffer = false;
            foreach(var offer in offers)
            {
                if (offer>500)
                {
                    bigOffers.Add(offer);
                    existingBigOffer = true;
                }
            }
            if (existingBigOffer)
            {
                Console.Write("Offers over 500 euro: ");
            }
            else
            {
                Console.WriteLine("There aren't any offers over 500 euro.");
            }
            foreach (var offer in bigOffers)
            {
                Console.Write(offer+"euro ");
            }

            Console.WriteLine($"\nCount of offers over 500: {bigOffers.Count}");
            Console.WriteLine();
        }
        public static void PrintList(List<int> offers)
        {
            Console.WriteLine("\nThe list printed: ");
            foreach(var offer in offers)
            {
                Console.Write(offer+"euro ");
            }
        }
        public static void BubbleSort(List<int> offers)
        {
            //Сложност : O(N^2)
            for (int i = 0; i < offers.Count - 1; i++)
            {
                for (int j = 0; j < offers.Count - i - 1; j++)
                {
                    if (offers[j] > offers[j + 1])
                    {
                        int temp = offers[j];
                        offers[j] = offers[j + 1];
                        offers[j + 1] = temp;
                    }
                }
            }
        }
        public static void InsertionSort(List<int> offers)
        {
            //Сложност : O(N^2), а в най-добрия случай е O(N)
            int n = offers.Count;
            for (int i = 1; i < n; i++)
            {
                int key = offers[i];
                int j = i - 1;

                while (j >= 0 && offers[j] > key)
                {
                    offers[j + 1] = offers[j];
                    j--;
                }
                offers[j + 1] = key;
            }
        }
    }

}
