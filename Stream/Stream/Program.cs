using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream
{
    class Program
    {
        private static List<char> vogaisEncontradasStream = new List<char>();

        static void Main(string[] args)
        {
            char value = firstChar(new WordStream());

            if (value != '\0')
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Não foi encontrado um caracter válido");
            }

            Console.ReadLine();
        }

        public static char firstChar(IStream input)
        {
            bool ultimoFoiConsoante = false;
            bool vogalRemovida = false;

            while (input.hasNext())
            {
                char caracter = char.ToLower(input.getNext());
                vogalRemovida = false;
                switch (caracter)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        if (ultimoFoiConsoante)
                        {
                            // É uma vogal agora
                            ultimoFoiConsoante = false;

                            for (int i = 0; i < vogaisEncontradasStream.Count; i++)
                            {
                                // Se já tem, remove, pois é repetida
                                if (caracter == vogaisEncontradasStream[i])
                                {
                                    vogaisEncontradasStream.RemoveAt(i);
                                    vogalRemovida = true;
                                    break;
                                }
                            }

                            if (!vogalRemovida)
                            {
                                // Senão tem, adiciona
                                vogaisEncontradasStream.Add(caracter);
                            }
                            
                        }
                        break;
                    default:
                        ultimoFoiConsoante = true;
                        break;
                }
            }

            return vogaisEncontradasStream.Count > 0 ? vogaisEncontradasStream[0] : default(char);
        }
    }
}
