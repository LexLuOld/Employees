using Employees.UI;

namespace Employees.Helpers
{
    public static class Util
    {
        public static string AskForString(string prompt, IUI ui, Func<string, bool>? validate = null)
        {
            string answer;

            do
            {
                ui.Print($"{prompt}: ");
                answer = ui.GetInput();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    ui.Print($"You must enter a valid {prompt}");
                    continue;
                }

                if (validate != null && !validate(answer))
                {
                    ui.Print($"Invalid input for {prompt}");
                    continue;
                }

                return answer;

            } while (true);
        }

        public static uint AskForUInt(string prompt, IUI ui)
        {
            return uint.Parse(AskForString(
                prompt,
                ui,
                input => uint.TryParse(input, out _)
            ));
        }
    }

}
