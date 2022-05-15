using System.Threading.Tasks;
using Xamarin.Forms;

namespace ThinkFast.Models
{
    public static class GameLauncher
    {
        public static async Task Start(int firstRung, int secondRung, Operation operation)
        {
            await Shell.Current.GoToAsync($"Training?firstRung={firstRung}&secondRung={secondRung}&operation={operation.Id}");
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
    }
}