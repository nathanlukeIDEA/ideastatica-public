﻿using IdeaRS.OpenModel;
using IdeaRS.OpenModel.Material;
using IdeaStatiCa.BimApi;
using IdeaStatiCa.BimImporter.Importers;
using IdeaStatiCa.Plugin;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace IdeaStatiCa.BimImporter.Tests.Importers
{
	[TestFixture]
	public class MaterialImporterTest
	{
		public static IEnumerable<TestCaseData> GetMaterialInstances()
		{
			IIdeaMaterialByName materialByName = Substitute.For<IIdeaMaterialByName>();
			materialByName.Id.Returns("mat1");
			materialByName.Name.Returns("S 235");
			yield return new TestCaseData(materialByName);

			IIdeaMaterialSteel materialSteel = Substitute.For<IIdeaMaterialSteel>();
			materialSteel.Id.Returns("mat1");
			materialSteel.Name.Returns("S 235");
			MatSteel matSteel = Substitute.For<MatSteel>();
			materialSteel.Material.Returns(matSteel);
			yield return new TestCaseData(materialSteel);

			IIdeaMaterialConcrete materialConcrete = Substitute.For<IIdeaMaterialConcrete>();
			materialConcrete.Id.Returns("mat1");
			materialConcrete.Name.Returns("Concrete C12/15");
			MatConcrete matConcrete = Substitute.For<MatConcrete>();
			materialConcrete.Material.Returns(matConcrete);
			yield return new TestCaseData(materialConcrete);
		}

		[Test]
		[TestCaseSource(nameof(GetMaterialInstances))]
		public void Import_ReturnsMaterialObject(IIdeaMaterial material)
		{
			// Setup
			MaterialImporter importer = new MaterialImporter(new NullLogger());

			// Tested method
			OpenElementId result = importer.Import(null, material);

			// Assert
			Assert.That(result, Is.InstanceOf<Material>());
		}

		public void Import_WhenObjectIsIIdeaMaterialByName_PropertyLoadFromLibraryIsTrue()
		{
			// Setup
			IIdeaMaterialByName materialByName = Substitute.For<IIdeaMaterialByName>();
			materialByName.Id.Returns("mat1");
			materialByName.Name.Returns("S 235");

			MaterialImporter importer = new MaterialImporter(new NullLogger());

			// Tested method
			Material result = (Material)importer.Import(null, materialByName);

			// Assert
			Assert.That(result.LoadFromLibrary, Is.True);
		}
	}
}