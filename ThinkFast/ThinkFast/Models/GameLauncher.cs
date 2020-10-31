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
    }
}