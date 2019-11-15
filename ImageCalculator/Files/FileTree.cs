using System.IO;
using System.Linq;

namespace ImageCalculator
{
    public class FileTree
    {
        private readonly FileFolder root;

        public FileTree(string path)
        {
            root = new FileFolder(path);
            AddChildren(root);            
        }

        private void AddChildren(FileFolder folder)
        {
            foreach (var file in Directory.GetFiles(folder.path))
            {
                switch (Path.GetExtension(file))
                {
                    case ".png":
                        folder.Add(new PngImage(file));
                        break;
                    case ".bmp":
                        folder.Add(new BmpImage(file));
                        break;
                    case ".jpeg":
                    case ".jpg":
                        folder.Add(new JpegImage(file));
                        break;
                    default:
                        continue;
                }
            }

            foreach (var directory in Directory.GetDirectories(folder.path))
            {
                var newFolder = new FileFolder(directory);
                folder.Add(newFolder);
                AddChildren(newFolder);
            }
        }

        public void Accept(MatrixCalculator mcalc) => root.Accept(mcalc);
    }
}