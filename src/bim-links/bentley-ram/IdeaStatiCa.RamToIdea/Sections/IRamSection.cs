﻿using IdeaStatiCa.BimApi;

namespace IdeaStatiCa.RamToIdea.Sections
{
	internal interface IRamSection: IIdeaCrossSection
	{
		double Height { get; }
	}
}