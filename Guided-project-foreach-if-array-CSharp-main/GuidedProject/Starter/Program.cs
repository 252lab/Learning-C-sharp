using System;

// initialize variables - graded assignments 
// number of assignments
int examAssignments = 5;

// each person's scores

int[] sophiaScores = new int[] {90, 86, 87, 98, 100, 94, 90};
int[] andrewScores = new int[] {92, 89, 81, 96, 90, 89};
int[] emmaScores = new int[] {90, 85, 87, 98, 68, 89, 89, 89};
int[] loganScores = new int[] {90, 95, 87, 88, 96, 96};
int[] beckyScores = new int[] { 92, 91, 90, 91, 92, 92, 92 };
int[] chrisScores = new int[] { 84, 86, 88, 90, 92, 94, 96, 98 };
int[] ericScores = new int[] { 80, 90, 100, 80, 90, 100, 80, 90 };
int[] gregorScores = new int[] { 91, 91, 91, 91, 91, 91, 91 };

// array of student names
string[] studentNames = new string[] {"Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor"};


//array to store the current student's scores
int[] studentScores = new int[10];

// string that holds the student's letter grade
string currentStudentLetterGrade = "";

/// output
Console.WriteLine("Student\t\tGrade\n");

// calculating the sum of each person's different scores
foreach (string name in studentNames)
{
    // holds the current student's name
    string currentStudent = name;

    // checks what student the grade is being calculated for
    if (currentStudent == "Sophia")
        studentScores = sophiaScores;
    
    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;
    
    else if (currentStudent == "Logan")
        studentScores = loganScores;

    else if (currentStudent == "Becky")
        studentScores = beckyScores;
        
    else if (currentStudent == "Chris")
        studentScores = chrisScores;

    else if (currentStudent == "Eric")
        studentScores = ericScores;

    else if (currentStudent == "Gregor")
        studentScores = gregorScores;

    else
        continue;


// initialise the sum of the different assignments
    int sumAssignmentScores = 0;

// initialise the average of the different assigments and any extra credit
    decimal currentStudentGrade = 0;

// number of graded assigments summed so far
int gradedAssignments = 0;

// summing the assignment scores and extra credit
    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        // if the score is an exam score, add it to the sum
        if (gradedAssignments <= examAssignments)
            sumAssignmentScores += score;

            // otherwise add the extra credit scores - worth 10% of exam grades
        else 
            sumAssignmentScores += score/10;
    }

// calculating the current grade
    currentStudentGrade = (decimal)sumAssignmentScores / examAssignments;

// working out what letter grade corresponds with the student's avergae score
if (currentStudentGrade >= 97)
    currentStudentLetterGrade = "A+";

else if (currentStudentGrade >= 93)
    currentStudentLetterGrade = "A";

else if (currentStudentGrade >= 90)
    currentStudentLetterGrade = "-A";

else if (currentStudentGrade >= 87)
    currentStudentLetterGrade = "B+";

else if (currentStudentGrade >= 83)
    currentStudentLetterGrade = "B";

else if (currentStudentGrade >= 80)
    currentStudentLetterGrade = "B-";

else if (currentStudentGrade >= 77)
    currentStudentLetterGrade = "C+";

else if (currentStudentGrade >= 73)
        currentStudentLetterGrade = "C";

else if (currentStudentGrade >= 70)
    currentStudentLetterGrade = "C-";

else if (currentStudentGrade >= 67)
    currentStudentLetterGrade = "D+";

else if (currentStudentGrade >= 63)
    currentStudentLetterGrade = "D";

else if (currentStudentGrade >= 60)
    currentStudentLetterGrade = "D-";
    
else 
    currentStudentLetterGrade = "F";

// outputting the grade
    Console.WriteLine($"{currentStudent}\t\t{currentStudentGrade}\t{currentStudentLetterGrade}");

}

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();
