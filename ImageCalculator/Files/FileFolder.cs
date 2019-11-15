using System.Collections.Generic;
using System.IO;

namespace ImageCalculator
{
    public class FileFolder : FileObject
    {
        public const string DefaultUnitName = "CON";
        private readonly List<FileObject> children;
        public FileFolder(string path) : base(path)
        {
            children = new List<FileObject>();
        }

        public virtual string GetUnitName()
        {
            var settings = Directory.GetFiles(path, "settings.txt");

            return settings.Length != 0 
                ? string.Join("", File.ReadAllLines(settings[0])) 
                : DefaultUnitName;
        }

        public override void Accept(MatrixCalculator mcalc)
        {
            mcalc.ChangeUnit(AllCalculatingUnits.GetInstance().GetUnit(GetUnitName()));

            children.ForEach(c => c.Accept(mcalc));
        }

        public override void Add(FileObject fileObj) => children.Add(fileObj);

        public override FileObject GetChild(int index) => children[index];
    }
}