using System.IO;

namespace ImageCalculator
{
    public class MatrixCalculator
    {
        private CalculatingUnit calcUnit;

        public void ChangeUnit(CalculatingUnit calc)
        {
            calcUnit = calc;
        }

        public void CalculateBmp(BmpImage img)
        {
            var matrix = new int[10, 10];

            //*Считаем матрицу специально для этого типа файла*

            PrintToFile(img, calcUnit.GetName(), calcUnit.ComputeParameter(matrix));
        }

        public void CalculatePng(PngImage img)
        {
            var matrix = new int[10, 10];

            //*Считаем матрицу специально для этого типа файла*

            PrintToFile(img, calcUnit.GetName(), calcUnit.ComputeParameter(matrix));
        }

        public void CalculateJpeg(JpegImage img)
        {
            var matrix = new int[10, 10];

            //*Считаем матрицу специально для этого типа файла*

            PrintToFile(img, calcUnit.GetName(), calcUnit.ComputeParameter(matrix));
        }

        private void PrintToFile(ImageFile file, string name, float parameter)
        {
            var newFilePath = Path.Combine(Path.GetDirectoryName(file.path), Path.GetFileNameWithoutExtension(file.path) + "_out.txt");

            File.WriteAllText(newFilePath, $"{name} = {parameter}");
        }
    }
}