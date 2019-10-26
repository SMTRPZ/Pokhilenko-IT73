namespace ImageCalculator
{
    public class BmpImage : ImageFile
    {
        public BmpImage(string path) : base(path)
        {
        }

        public override void Accept(MatrixCalculator mcalc) => mcalc.CalculateBmp(this);
    }
}