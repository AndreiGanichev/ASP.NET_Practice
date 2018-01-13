
namespace ASP.NET_Practice.Models
{
    public interface IWeapon
    {
        string Execute();
    }

    public class Sword : IWeapon
    {
        public string Execute()
        {
            return "chop-chop";
        }
    }
}