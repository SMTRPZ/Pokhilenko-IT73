
using ImageCalculator;

namespace UnitTests
{
    class TestFileFolder : FileFolder
    {
        private readonly string _unitName;

        public TestFileFolder(string path, string unitName = null) : base(path)
        {
            _unitName = unitName ?? DefaultUnitName;
        }

        public override string GetUnitName() => _unitName;
    }
}
