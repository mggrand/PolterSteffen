using Xunit;

namespace PolterSteffen
{
    public class Aufgabe_2
    {


// ########################################### AUFGABE ####################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ToCamel(string input) 
        {
            var resultat = string.Empty;
            
            for(int i = 0; i < input.Length; i++)
            {
                var shouldUpper = i % 2 == 0;
                if (shouldUpper)
                {
                    resultat += input[i].ToString().ToUpper();
                }
                else
                {
                    resultat += input[i].ToString().ToLower();
                }
            }

            return resultat;   
        }



// ########################################### TESTS ####################################################################

        [Theory]
        [InlineData("Steffen", "StEfFeN")]
        [InlineData("steffen", "StEfFeN")]
        [InlineData("BARBARA", "BaRbArA")]
        public void Tests(string input, string expected)
        {
            var result = ToCamel(input);

            Assert.Equal(expected, result);
        }
    }
}
