namespace ImageCalculator
{
    public class PngImage : ImageFile
    {
        public PngImage(string path) : base(path) { }

        public override void Accept(MatrixCalculator mcalc) => mcalc.CalculatePng(this);
    }
}