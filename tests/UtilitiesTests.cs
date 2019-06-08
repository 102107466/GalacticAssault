using NUnit.Framework;
using GalacticAssault;

namespace GalacticAssaultTests
{
	[TestFixture]
	public static class UtilitiesTests
	{
		[Test]
		public static void ClampMinIntTest()
		{
			int val = 2;
			Assert.AreEqual(5, Utilities.Clamp<int>(val, 5, 20));
		}

		[Test]
		public static void ClamValIntTest()
		{
			int val = 15;
			Assert.AreEqual(val, Utilities.Clamp<int>(val, 5, 20));
		}

		[Test]
		public static void ClampMaxIntTest()
		{
			int val = 50;
			Assert.AreEqual(20, Utilities.Clamp<int>(val, 5, 20));
		}

		[Test]
		public static void ClampMinFloatTest()
		{
			float val = 2.0f;
			Assert.AreEqual(5.5f, Utilities.Clamp<float>(val, 5.5f, 25.5f));
		}

		[Test]
		public static void ClampValFloatTest()
		{
			float val = 15.7f;
			Assert.AreEqual(val, Utilities.Clamp<float>(val, 5.5f, 25.5f));
		}

		[Test]
		public static void ClampMaxFloatTest()
		{
			float val = 56.24f;
			Assert.AreEqual(25.5f, Utilities.Clamp<float>(val, 5.5f, 25.5f));
		}
	}
}
