using System.IO;

namespace MarvelApi.Utils
{
    public class FileTxt
    {
        string pasta = @"C:\RetornoApiMarvel";
        string arqTxt = @"C:\RetornoApiMarvel\personagensmarvel.txt";

        public FileTxt(string resultado)
        {
            VerificarPasta(resultado);
            EscrevendoArquivo(resultado);
        }

        private void VerificarPasta(string resultado)
        {
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
                FileStream txt = File.Create(arqTxt);
            }
        }

        private void EscrevendoArquivo(string resultado)
        {
            var sw = new StreamWriter(arqTxt);
            sw.AutoFlush = true;
            sw.WriteLine(resultado);
        }
    }
}
