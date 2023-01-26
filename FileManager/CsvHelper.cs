using System.Runtime.CompilerServices;

namespace InOutLib
{
    public class CsvHelper : FileHelper
    {
        #region private attributs
        //TODO Private attributs - 2pts
        private char _separator;
        #endregion private attributs

        #region constructor
        public CsvHelper(string path, string fileName, char separator = ';') : base(path, fileName)
        {
            //TODO Constructor - 3pts
            if (IsCharSupported(separator))
            {
                throw new UnsupportedSeparatorException();
            }
            _separator = separator;
        }
        #endregion constructor

        #region public methods 
        override public void ExtractFileContent()
        {
            //TODO ExtractFileContent - 6pts
            StreamReader streamReader = new StreamReader(_fullPath);
            string line;
            // Reads and stores lines from the file until eof.
            while ((line = streamReader.ReadLine()) != null)
            {
                this.Lines.Add(line);
            }
            streamReader.Close();

            if (this.Lines.Count == 0)
            {
                throw new EmptyFileException();
            }

            foreach (string text in this.Lines)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    throw new CsvHelper.StructureException();
                }
            }
            //throw new InOutLib.StructureException();
        }
        #endregion public methods

        #region private methods
        private bool IsCharSupported(char separator)
        {
            //TODO IsCharSupported - 2pts
            return separator == '+';
        }
        #endregion privates methods

        #region nested classes
        public class CsvHelperException : FileHelperException{}
        public class UnsupportedSeparatorException : CsvHelperException { }
        public class StructureException : CsvHelperException { }
        #endregion nested classes
    }
}
