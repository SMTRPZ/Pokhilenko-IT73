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

            var parameter = calcUnit.ComputeParameter(matrix);
            PrintToFile(img, calcUnit.GetName(), parameter);
        }

        public void CalculatePng(PngImage img)
        {
            var matrix = new int[10, 10];

            //*Считаем матрицу специально для этого типа файла*

            var parameter = calcUnit.ComputeParameter(matrix);
            PrintToFile(img, calcUnit.GetName(), parameter);
        }

        public void CalculateJpeg(JpegImage img)
        {
            var matrix = new int[10, 10];

            //*Считаем матрицу специально для этого типа файла*

            var parameter = calcUnit.ComputeParameter(matrix);
            PrintToFile(img, calcUnit.GetName(), parameter);
        }

        private void PrintToFile(ImageFile file, string name, float parameter)
        {
            var newFilePath = Path.Combine(Path.GetDirectoryName(file.path), Path.GetFileNameWithoutExtension(file.path) + "_out.txt");
            var text = name + " = " + parameter;
            File.WriteAllText(newFilePath, text);
        }
    }
}