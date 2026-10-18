// Guided Project - Plan a Petting Zoo Visit

using System;

// string that holds all of the animals
string[] pettingZoo =
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
};

// schools that are visiting the zoo
PlanSchoolVisit("School A");
PlanSchoolVisit("School B", 3);
PlanSchoolVisit("School C", 2);

// function to handle different schools and requirements
void PlanSchoolVisit(string schoolName, int groups = 6)
{
    // calling the function to randomise the pettingZoo array
    RandomiseAnimals();

    // calling function to assign groups of animals
    string[,] group = AssignGroup(groups);

    //outputting what school is visiting
    Console.WriteLine(schoolName);

    // outputting the assigned groups
    PrintGroup(group);

}

// function used to randomise animals
void RandomiseAnimals()
{

    // setting up random 
    Random random = new Random();

    // for loop to iterate through all elements in array
    for (int i = 0; i < pettingZoo.Length; i++)
    {

        // variable used to change the index at which the animals are located
        int r = random.Next(i, pettingZoo.Length);

        // first position change
        string temp = pettingZoo[i];
        pettingZoo[i] = pettingZoo[r];
        pettingZoo[r] = temp;

    }

}

// function to assign groups of animals
string[,] AssignGroup(int groups = 6)
{
    // creating return value
    string[,] result = new string[groups, pettingZoo.Length / groups];

    // variable for keeping track of starting position of groups
    int start = 0;

    // assigning groups of animals
    for (int i = 0; i < groups; i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = pettingZoo[start++];
        }
    }

    // returning the assigned groups
    return result;
}

// function for printing out the assigned groups
void PrintGroup(string[,] group)
{

    // using two for loops to iterate through 2d array
    for (int i = 0; i < group.GetLength(0); i++)
    {
        // outputting group number
        Console.Write($"Group {i + 1}: ");

        for (int j = 0; j < group.GetLength(1); j++)
        {
            // outputting array of animals
            Console.Write($"{group[i, j]} ");
        }
        Console.WriteLine();
    }
}
