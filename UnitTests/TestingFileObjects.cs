using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ImageCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestingFileObjects
    {
        private readonly ImageFile[] _imageFiles;
        private readonly string[] _unitsNames;

        public TestingFileObjects()
        {
            _imageFiles = Assembly.GetAssembly(typeof(ImageFile)).GetTypes()
                .Where(type => type.IsSubclassOf(typeof(ImageFile)) && type.IsClass && !type.IsAbstract)
                .Select(type => (ImageFile)Activator.CreateInstance(type, "")).ToArray();
            
            _unitsNames = ((Dictionary<string, CalculatingUnit>)typeof(AllCalculatingUnits)
                .GetField("units", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(AllCalculatingUnits.GetInstance())).Keys.ToArray();
        }

        [TestMethod]
        public void ImageFiles_Count_3()
        {
            Assert.AreEqual(_imageFiles.Length, 3);
        }

        [TestMethod]
        public void ImageFiles_GetChild_NotSupportedException()
        {
            foreach (var imageFile in _imageFiles)//Check base class
            {
                Assert.ThrowsException<NotSupportedException>(() => imageFile.GetChild(0));
            }
        }

        [TestMethod]
        public void ImageFiles_Add_NotSupportedException()
        {
            foreach (var imageFile in _imageFiles)//Check base class
            {
                Assert.ThrowsException<NotSupportedException>(() => imageFile.Add(null));
            }
        }

        private TestFileFolder GetTestTree() 
        {
            var folder = new TestFileFolder(null);

            foreach (var unitName in _unitsNames)
            {
                var subFolder = new TestFileFolder(null, unitName);

                foreach (var imageFile in _imageFiles)
                {
                    subFolder.Add(imageFile);
                }

                folder.Add(subFolder);
            }

            return folder;
        }

        [TestMethod]
        public void FileFolders_CheckUnitNames()
        {
            var rootFolder = GetTestTree();

            Assert.AreEqual(rootFolder.GetUnitName(), FileFolder.DefaultUnitName);

            for (int i = 0; i < _unitsNames.Length; i++)
            {
                var subfolder = rootFolder.GetChild(i);

                Assert.AreEqual(((FileFolder)subfolder).GetUnitName(), _unitsNames[i]);
            }
        }
    }
}
