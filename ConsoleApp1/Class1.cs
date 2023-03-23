namespace Programming101
{
    public enum Relation 
    {
        CHILD, SPOUSE
    }

    public enum Gender
    {
        MALE, FEMALE
    }

    public struct Relative
    {
        public Person person;
        public Relation relation;

        public Relative(Person person, Relation relation)
        {
            this.person = person;
            this.relation = relation;
        }
    }

    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _maidenName;
        private int _age;
        private float _chanceToDie;
        private List<Relative> _family = new List<Relative>();

        public bool IsAlive { get; private set; }
        public bool IsMarried { get; private set; }
        public Gender Gender { get; private set; }
        public List<Relative> Family { get { return _family; } }

        public Person(string firstName, string lastName, Gender gender)
        {
            _firstName = firstName;
            _lastName = lastName;
            _maidenName = "";
            _age = 0;
            IsAlive = true;
            IsMarried = false;
            Gender = gender;
            _chanceToDie = 0f;
        }

        public void Age()
        {
            Random random = new Random();
            _age++;
            _chanceToDie += 0.05f;
            switch(_age)
            {
                case 18:
                    {
                        _chanceToDie += 1f;
                        break;
                    }
                case 80:
                    {
                        _chanceToDie += 20f;
                        break;
                    }
            }
            int randomNumber = random.Next(0, 100);
            if (randomNumber < _chanceToDie)
            {
                Die();
                return;
            }
        }

        private void Die()
        {
            IsAlive = false;
        }

        public Person HaveChild(string firstName, Gender gender)
        {
            Person child = new Person(firstName, _lastName, gender);
            _family.Add(new Relative(child, Relation.CHILD));
            return child;
        }

        public void GetMarried(Person spouse)
        {
            IsMarried = true;
            if (Gender == Gender.FEMALE)
            {
                _maidenName = _lastName;
                _lastName = spouse._lastName;
            }
            _family.Add(new Relative(spouse, Relation.SPOUSE));
        }

        public bool CanMarryPerson(Person other)
        {
            if (IsMarried || _age < 18)
            {
                return false;
            }
            else if (_family.Where(relative => relative.person == other).Count() != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
