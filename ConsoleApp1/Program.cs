// See https://aka.ms/new-console-template for more information
using Programming101;

string[] firstNamesM = new string[10] { "James", "Robert", "John", "Michael", "David", "William", "Richard", "Joseph", "Thomas", "Charles" };
string[] firstNamesF = new string[10] { "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Barbara", "Susan", "Jessica", "Sarah", "Karen" };
string[] lastNames = new string[10] { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };

Random random = new Random();

List<Person> alivePeople = new List<Person>();
List<Person> deadPeople = new List<Person>();

for(int i = 0; i < lastNames.Length; i++)
{
    for(int j = 0; j < firstNamesM.Length; j++)
    {
        alivePeople.Add(new Person(firstNamesM[j], lastNames[i], Gender.MALE));
    }
    for(int k = 0; k < firstNamesF.Length; k++)
    {
        alivePeople.Add(new Person(firstNamesF[k], lastNames[i], Gender.FEMALE));
    }
}

while(alivePeople.Count > 0)
{
    foreach(Person person in alivePeople)
    {
        person.Age();
        if(person.IsAlive)
        {
            int randomNumber = random.Next(0, 100);
            if (randomNumber < 30)
            {
                Person randomPerson = alivePeople[random.Next(alivePeople.Count)];
                if (person.CanMarryPerson(randomPerson) && randomPerson.CanMarryPerson(person))
                {
                    person.GetMarried(randomPerson);
                }
            }
            randomNumber = random.Next(0, 100);
            if (randomNumber < 10 && person.Gender == Gender.FEMALE && person.IsMarried)
            {

                randomNumber = random.Next(0, 100);
                Gender gender = (Gender)(randomNumber % 2);
                string firstName;
                if (gender == Gender.MALE)
                {
                    firstName = firstNamesM[random.Next(firstNamesM.Length)];
                }
                else
                {
                    firstName = firstNamesF[random.Next(firstNamesF.Length)];
                }
                Person child = person.HaveChild(firstName, gender);
                alivePeople.Add(child);
            }
        }
        else
        {
            deadPeople.Add(person);
            alivePeople.Remove(person);
        }
    }
}

Console.WriteLine("Total People: " + deadPeople.Count);