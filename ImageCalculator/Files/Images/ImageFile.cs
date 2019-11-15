using System;
using System.IO;

namespace ImageCalculator
{
    public abstract class ImageFile : FileObject
    {
        public ImageFile(string path) : base(path) { }

        public FileStream GetFileStream() => new FileStream(path, FileMode.Open);

        public override void Add(FileObject fileObj) //???
        {
            throw new NotSupportedException("Нельзя добавить ребёнка файлу.");
        }

        public override FileObject GetChild(int index)
        {
            throw new NotSupportedException("У этого типа файлов нет детей.");
        }
    }
}