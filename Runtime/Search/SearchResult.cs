using System;
using System.Linq;
using Nox.CCK.Network.Assets;
using Nox.Mods.Runtime.Network;
using Nox.Search;

namespace Nox.Mods.Runtime.Search {
	public class SearchResult : IResult {
		public string Error { get; internal set; }

		public AssetSearchResponse<Mod> Response;

		public bool IsError
			=> !string.IsNullOrEmpty(Error);

		public bool HasNext()
			=> !IsError && Response != null && Response.HasNext;

		public IResultData[] Data
			=> Response?.Items != null
				? Response.Items
					.Select(mod => new SearchData { Reference = mod })
					.Cast<IResultData>()
					.ToArray()
				: Array.Empty<IResultData>();
	}
}
