namespace ImageCalculator
{
    public class JpegImage : ImageFile
    {
        public JpegImage(string path) : base(path)
        {
        }

        public override void Accept(MatrixCalculator mcalc) => mcalc.CalculateJpeg(this);
    }
}