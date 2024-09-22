using System.Text.RegularExpressions;

namespace VKA.Cupido.Services
{
    public class NameSalutationConverter
    {
        public static string GetSalutation(string name)
        {
            switch (name)
            {
                case var someVal when EndsWith(someVal, "as"):
                    return ReplaceEnding(name, "as", "ai");
                case var someVal when EndsWith(someVal, "is"):
                    return ReplaceEnding(name, "is", "i");
                case var someVal when EndsWith(someVal, "us"):
                    return ReplaceEnding(name, "us", "au");
                case var someVal when EndsWith(someVal, "ė"):
                    return ReplaceEnding(name, "ė", "e");
                case var someVal when EndsWith(someVal, "ys"):
                    return ReplaceEnding(name, "ys", "y");
            }
            return name;
        }

        private static bool EndsWith(string name, string ending)
        {
            return new Regex($@"{ending}$").IsMatch(name);
        }

        private static string ReplaceEnding(string name, string ending, string newEnding)
        {
            return Regex.Replace(name, $@"{ending}$", newEnding);
        }

    }
}
