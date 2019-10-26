using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageCalculator
{
    public abstract class FileObject
    {
        public readonly string path;

        public FileObject(string path)
        {
            this.path = path;
        }

        public abstract void Accept(MatrixCalculator mcalc);

        public abstract void Add(FileObject fileObj);

        public abstract FileObject GetChild(int index);
    }
}