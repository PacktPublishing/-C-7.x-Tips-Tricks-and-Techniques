using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocalFunctions
{
    public static class Program
    {
        static void Main()
        {
            const string url = "https://www.packtpub.com/";
            var before = new WebReaderBefore();
            before.ShowText(url);

            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();

            var after = new WebReaderAfter();
            after.ShowText(url);
        }
    }

    public class WebReaderBefore
    {
        public void ShowText(string url)
        {
            var lines = ReadPage(url).Result;
            var n = 0;
            foreach (var line in lines)
            {
                ++n;
                Console.WriteLine($"{n}: {line}");
            }
        }

        private async Task<string[]> ReadPage(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var client = new HttpClient();
            var contents = await client.GetStringAsync(url);
            return contents
                .Split(new[] { "<", "/>", ">" }, StringSplitOptions.None)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Take(6)
                .ToArray();
        }

        public int AnotherFunction(int a, int b)
        {
            // This function has access to ReadPage(), and it has no need to
            var result = ReadPage("https://www.packtpub.com/tech/C-Sharp");
            return a + b;
        }
    }

    public class WebReaderAfter
    {
        public void ShowText(string url)
        {

            var lines = ReadPage(url).Result;
            var n = 0;

            foreach (var line in lines)
            {
                ++n;
                Console.WriteLine($"{n}: {line}");
            }

            async Task<string[]> ReadPage(string address)
            {
                if (string.IsNullOrEmpty(address))
                    throw new ArgumentNullException(nameof(address));

                var client = new HttpClient();
                var contents = await client.GetStringAsync(address);
                return contents
                    .Split(new[] { "<", "/>", ">" }, StringSplitOptions.None)
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Take(6)
                    .ToArray();
            }
        }

        public int AnotherFunction(int a, int b)
        {
            // Can no longer see ReadPage() function
            //var result = ReadPage("https://www.packtpub.com/tech/C-Sharp");
            return a + b;
        }
    }
}