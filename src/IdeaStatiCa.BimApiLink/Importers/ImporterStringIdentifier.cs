﻿using IdeaStatiCa.BimApiLink.Identifiers;
using IdeaStatiCa.BimApi;

namespace IdeaStatiCa.BimApiLink.Importers
{
	public abstract class StringIdentifierImporter<T> : AbstractImporter<T>
		where T : IIdeaObject
	{
		public override T Create(Identifier<T> identifier)
		{
			return Create(((StringIdentifier<T>)identifier).Id);
		}

		public abstract T Create(string id);
	}
}