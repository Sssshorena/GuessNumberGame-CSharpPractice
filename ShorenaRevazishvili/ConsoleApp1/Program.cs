//status of game
bool playAgain = true;

while (playAgain)
{
    // Difficulty determination
    int gameDifficulty = 0;
    int[] validDifficulties = { 1, 2, 3 };
    bool validInput = false;


    while (!validInput)
    {
        Console.WriteLine("Choose game difficulty 1.Easy(0-50), 2.Medium(0-100), 3.Hard(0-200): ");

        if (int.TryParse(Console.ReadLine(), out gameDifficulty) && validDifficulties.Contains(gameDifficulty))
        {
            validInput = true;
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a valid number (1, 2, or 3).");
        }
    }

    // Random number generation by difficulty
    Random random = new Random();
    int guessedNumber = -1;

    if (gameDifficulty == 1) // Easy
    {
        do
        {
            guessedNumber = random.Next(0, 51);
        } while (guessedNumber % 10 == 0);
    }
    else if (gameDifficulty == 2) // Medium
    {
        do
        {
            guessedNumber = random.Next(0, 101);
        } while (guessedNumber % 10 == 0);
    }
    else if (gameDifficulty == 3) // Hard
    {
        do
        {
            guessedNumber = random.Next(0, 201);
        } while (guessedNumber % 10 == 0);
    }

    // Game logic
    int maxTries = 5;
    int userInputNumber = -1;
    int tries = 0;

    int[] previousUserInputNumbers = new int[maxTries]; //An array that holds the wrong guessed numbers
    while (userInputNumber != guessedNumber && tries < maxTries)
    {
        //Ask the player to enter a number
        Console.WriteLine($"Guess the number (Attempts left: {maxTries - tries}): ");
        if (int.TryParse(Console.ReadLine(), out userInputNumber))
        {

            previousUserInputNumbers[tries] = userInputNumber;

        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a number.");
            continue;
        }
        //What will happen if he guesses?
        if (userInputNumber == guessedNumber)
        {
            Console.WriteLine("Congrats! You guessed the number!");
            break;
        }
        //What message will the player get if he enters a number less than the guess number?
        else if (userInputNumber < guessedNumber)
        {
            Console.WriteLine("My number is greater!");
        }
        //What message will the player get if he enters a number higher than the guess number?
        else
        {
            Console.WriteLine("My number is less!");
        }
        //Attempts increase by +1 each iteration
        tries++;
        //If the player fails to guess the guessed number in all 5 attempts, display this message:
        if (tries == maxTries)
        {
            Console.WriteLine($"You Lost! The number was {guessedNumber}.");
        }


    }

    Console.WriteLine("Your previous guesses: " + string.Join(", ", previousUserInputNumbers[..tries]));
    Console.WriteLine($"The guessed number was: {guessedNumber}");


    // Ask the player if he wants to continue playing
    Console.WriteLine("Do you want to play again? (yes/no): _ ");
    string? response = Console.ReadLine();
    if (response == "yes")
        playAgain = true;
    else playAgain = false;
}

Console.WriteLine("Thanks for playing! Goodbye!");
