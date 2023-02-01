namespace BusinessLogic.Models
{
    public class RegisteredUser
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public RegisteredUser(int number, string name, string description)
        {
            Number = number;
            Name = name;
            Description = description;
        }

        public bool Equals(RegisteredUser user)
        {
            return this.Number == user.Number
                && this.Name == user.Name
                && this.Description == user.Description;
        }
    }
}
