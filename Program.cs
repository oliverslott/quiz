const byte maxHealth = 6;
/*

Lav et Quiz spil, hvor man skal gætte et tilfældigt ord.
• Spillet skal indeholde 25 forskellige ord.
• Når spillet starter skal der vælges et tilfældigt ord, som spilleren skal
gætte.
• Antallet af bogstaver i det valgte ord vises på følgende måde: _ _ _ _ _ _
• Spilleren kan kun gætte på et bogstav ad gangen.
• Hvis ordet indeholder det gættede bogstav (E) vises det på følgende
måde: _ E _ _ E _ _
• Hvis ordet ikke indeholder det gættede bogstav mister spilleren et liv.
Du bestemmer selv, hvor mange liv spilleren har.
• Hvis spilleren ikke har flere liv tilbage afsluttes spillet, og beskeden
Game Over vises til spilleren.
• Hvis spilleren gætter ordet vises en ”vinder besked” og spillet spørger
om man vil spille igen eller afslutte.
• Efter hvert gæt skal spillet vise hvor mange liv spilleren har tilbage samt
hvilke bogstaver der er blevet gættet på.
*/

string[] words = [ 
    "balance", 
    "theater", 
    "magnify",
    "include",
    "brother",
    "courage",
    "happiness",
    "internet",
    "forward",
    "diamond",
    "journey",
    "relaxing",
    "friend",
    "between",
    "excited",
    "picture",
    "example",
    "believe",
    "progress",
    "victory",
    "freedom",
    "choices",
    "support",
    "connect",
    "respect"
];

StartGame();
void StartGame()
{
    Random rand = new Random();
    string wordToGuess = words[rand.Next(0, words.Length)];
    char[] word_template = new char[wordToGuess.Length];
    for (int i = 0; i < word_template.Length; i++)
    {
        word_template[i] = '_';
    }
    byte currentHealth = maxHealth;
    byte guessAmount = 0;
    char[] guessed_letters = new char[256]; //Jeg ville havde lavet en List<T> her i stedet, men prøver at holde mig indenfor det vi har været igennem.
    while (true)
    {
        Console.WriteLine();
        Console.Write("Current word: ");
        for (int i = 0; i < word_template.Length; i++)
        {
            Console.Write(word_template[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine($"Current health: {currentHealth}");
        Console.Write($"Guessed letters: ");
        for (int i = 0; i < guessed_letters.Length; i++)
        {
            Console.Write(guessed_letters[i] + " ");
        }
        Console.WriteLine();
        Console.Write("Guess a letter: ");
        //char guess;
        if (!char.TryParse(Console.ReadLine().Trim(), out char guess))
        {
            Console.WriteLine("Your input has to be a letter! You lost a health point");
            continue;
        }
        if (guessed_letters.Contains(guess))
        {
            Console.WriteLine("You have already guessed that letter!");
            continue;
        }
        guessed_letters[guessAmount] = guess;
        guessAmount++;
        bool found_letter = false;
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == guess)
            {
                found_letter = true;
                word_template[i] = guess;
            }
        }
        if (found_letter)
        {
            Console.WriteLine($"The letter {guess} is in the word!");
        }
        else
        {
            currentHealth--;
            Console.WriteLine($"The word doesn't include the letter: \"{guess}\"");
        }

        if (currentHealth == 0)
        {
            Console.WriteLine($"Game Over. The word was {wordToGuess}");
            return;
        }

        if (wordToGuess == new string(word_template))
        {
            Console.Write("You won! Do you want to play again (yes/no)?: ");
            if (wantsToPlayAgain())
            {
                StartGame();
                break;
            }
            else
            {
                return;
            }
        }
    }
}

bool wantsToPlayAgain()
{
    while (true)
    {
        string aaa = Console.ReadLine().ToLower();
        if (aaa == "yes")
        {
            return true;
        }
        else if (aaa == "no")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}

