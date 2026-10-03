using Cysharp.Threading.Tasks;
using Nox.CCK.Network.Assets;
using Nox.Mods.Runtime.Network;
using Nox.Network.Assets;
using Nox.Search;

namespace Nox.Mods.Runtime.Search {
	public class SearchWorker : IWorker {
		public string Title;
		public string Server;

		public string[] TitleArguments
			=> new[] { Title };

		public float Ratio
			=> 4f / 3f;

		public async UniTask<IResult> Fetch(IFetchOptions options) {
			if (string.IsNullOrEmpty(Server))
				return new SearchResult { Error = "Invalid server address." };

			var assets = Main.AssetsAPI;

			if (assets == null)
				return new SearchResult { Error = "The asset pipeline is not available." };

			var response = await assets.Search<AssetSearchResponse<Mod>>(
				Server,
				ModsEndpoint.Endpoint,
				new AssetSearchRequest {
					Query  = options.Query,
					Offset = options.Page * options.Limit,
					Limit  = options.Limit
				}
			);

			if (response == null)
				return new SearchResult { Error = "Error fetching mods." };

			return new SearchResult {
				Response = response,
				Error    = null
			};
		}
	}
}
