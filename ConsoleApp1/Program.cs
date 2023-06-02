using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solicita ao usuário o comprimento da senha desejada
            Console.WriteLine("Digite o comprimento da senha desejada (min: 8): ");
            
            // Lê a entrada do usuário e atribui a 'input', se a entrada for nula, o valor padrão "8" é atribuído
            string input = Console.ReadLine() ?? "8";
            int length;
            
            if (string.IsNullOrEmpty(input))
            {
                length = 8; // Valor padrão caso a entrada esteja vazia
            }
            else
            {
                // Converte a entrada para um número inteiro
                length = int.Parse(input);
            }
            
            // Verifica se o comprimento da senha é menor que 8
            if (length < 8)
            {
                Console.WriteLine("O comprimento da senha deve ser maior ou igual a 8.");
                return;
            }

            // Gera uma senha usando o comprimento fornecido
            string password = GeneratePassword(length);
            
            // Imprime a senha gerada na tela
            Console.WriteLine($"A senha gerada é: {password}");
        }

        static string GeneratePassword(int length)
        {
            // Conjunto de caracteres permitidos na senha
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            
            // Conjunto de números permitidos na senha
            const string numbers = "1234567890";

            // Conjunto de caracteres especiais permitidos na senha
            const string specialCharacters = "!@#$%^&*().";
            
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            // Gera a senha com o comprimento fornecido
            for (int i = 0; i < length; i++)
            {
                // Seleciona um índice aleatório do conjunto de caracteres
                int index = random.Next(characters.Length);
                
                // Verifica se o último caractere da senha é igual ao caractere atual e se eles têm a mesma letra minúscula equivalente
                string passwordString = password.ToString();
                if (password.Length > 0 && password[password.Length - 1] == characters[index] && char.ToLower(passwordString[password.Length - 1]) != characters[index])
                {
                    // Se forem iguais, decrementa o contador e continua para a próxima iteração para evitar caracteres repetidos
                    i--;
                }
                else
                {
                    // Se forem diferentes, adiciona o caractere atual à senha
                    password.Append(characters[index]);
                }
            }
            
            // Verifica se a senha não contém números e adiciona um número aleatório
            if (password.ToString().IndexOfAny(numbers.ToCharArray()) == -1)
            {
                int index = random.Next(numbers.Length);
                password.Append(numbers[index]);
            }
            
            // Verifica se a senha não contém caracteres especiais e substitui aleatoriamente alguns caracteres por caracteres especiais
            if (password.ToString().IndexOfAny(specialCharacters.ToCharArray()) == -1)
            {
                for (int i = 0; i < 4; i++)
                {
                    int index = random.Next(specialCharacters.Length);
                    int passwordIndex = random.Next(password.Length);
                    password[passwordIndex] = specialCharacters[index];
                }
            }

            return password.ToString();
        }
    }
}