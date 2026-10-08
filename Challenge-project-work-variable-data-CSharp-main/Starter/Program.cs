using System;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

// ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// array used to store runtime data
string[,] ourAnimals = new string[maxPets, 7];

// sample data ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "gus";
            suggestedDonation = "49.99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "snow";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "lion";
            suggestedDonation = "";

            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

// top-level menu options
do
{
    // NOTE: the Console.Clear method is throwing an exception in debug sessions
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // switch-case to process the selected menu option
    switch (menuSelection)
    {
        case "1":
            // list all pet info
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }

            Console.WriteLine("\r\nPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "2":
            // #1 Display all dogs with a multiple search characteristics

            string dogCharacteristic = "";

            // list of all characteristics entered
            string[] characteristicList = [];

            // list of dogs that have been matched
            string[] matchList = [];

            while (dogCharacteristic == "")
            {
                // #2 have user enter multiple comma separated characteristics to search for
                Console.WriteLine($"\r\nEnter desired dog characteristic to search for, with each term separated by a comma");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();

                    // splitting the entered string into an array
                    characteristicList = dogCharacteristic.Split(",");

                    //sorting the array
                    characteristicList.Sort();

                    Console.WriteLine();
                }
            }

            string dogDescription = "";

            // #4 update to "rotating" animation with countdown
            //updated searching array
            string[] searchingIcons = {" |", " /", "--", @"\", " *"};

            // loop ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {

                if (ourAnimals[i, 1].Contains("dog"))
                {


                    // Search combined descriptions and report results
                    dogDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5];

                    // searching each term in the list
                    foreach (string term in characteristicList)
                    {
                        // if the term is not empty/null
                        if (term != null || term != "")
                        {

                            for (int j = 5; j > -1; j--)
                            {
                                // #5 update "searching" message to show countdown 
                                foreach (string icon in searchingIcons)
                                {
                                    // ouputs what is currently being searched for
                                    Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {icon} {term} {j.ToString()}");
                                    Thread.Sleep(250);
                                }

                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }

                            // #3a iterate submitted characteristic terms and search description for each term

                            if (dogDescription.Contains(term))
                            {
                                // #3b update message to reflect term 
                                // #3c set a flag "this dog" is a match
                                Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match for your search for {term}!");

                                // storing the found animal in an array
                                if (!matchList.Contains(ourAnimals[i, 0]))
                                {
                                    Array.Resize(ref matchList, matchList.Length + 1);
                                    matchList[matchList.Length - 1] = (ourAnimals[i, 0]);
                                }

                            }
                        }

                        // #3d if "this dog" is match write match message + dog description

                        
                    }


                }

            }
            
            // if no matches were found
            if (matchList.Length == 0)
            {
                Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
            }
            else
            {

                // otherwise output the nickname, id and descriptions of the animal
                foreach (string id in matchList)
                {
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] == id)
                        {
                            Console.WriteLine($"\nNickname: {ourAnimals[i, 3]} ({ourAnimals[i, 0]})");
                            Console.WriteLine($"Physical Description: {ourAnimals[i, 4]}");
                            Console.WriteLine($"Personality: {ourAnimals[1, 5]}");
                        }
                    }
                }
            }

            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        default:
            break;
    }

} while (menuSelection != "exit");
