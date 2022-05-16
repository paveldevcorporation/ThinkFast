using System.Threading.Tasks;
using Xamarin.Forms;

namespace ThinkFast.Models
{
    public static class GameLauncher
    {
        public static async Task Start(int firstRung, int secondRung, Operation operation, uint leadTime)
        {
            await Shell.Current.GoToAsync($"Training?firstRung={firstRung}&secondRung={secondRung}&operation={operation.Id}&leadTime={leadTime}");
        }

        public static async Task RuleAdd()
        {
            await Shell.Current.GoToAsync("AddRule");
        }
        public static async Task RuleMinus()
        {
            await Shell.Current.GoToAsync("MinusRule");
        }

        public static async Task RuleMulti()
        {
            await Shell.Current.GoToAsync("MultiplyRule");
        }

        public static async Task RuleDivision()
        {
            await Shell.Current.GoToAsync("DivisionRule");
        }
    }
}