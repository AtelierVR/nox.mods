using Cysharp.Threading.Tasks;
using Nox.CCK.Language;
using Nox.CCK.Mods.Cores;
using Nox.CCK.Mods.Initializers;
using Nox.Mods.Runtime.Search;
using Nox.Network.Assets;
using Nox.Search;

namespace Nox.Mods.Runtime {
	/// <summary>
	/// Entry point of the mods mod: it wires the generic asset pipeline to the mods collection
	/// and registers the mod search.
	/// </summary>
	public class Main : IMainModInitializer {
		public static Main Instance;
		public IMainModCoreAPI CoreAPI;

		private LanguagePack _lang;
		private Search.Search _search;

		/// <summary>Generic asset pipeline, shared with every other asset type.</summary>
		public static IAssetsAPI AssetsAPI
			=> Instance?.CoreAPI.ModAPI
				.GetMod("network")
				?.GetInstance<IAssetsAPI>();

		static internal ISearchAPI SearchAPI
			=> Instance.CoreAPI.ModAPI
				.GetMod("search")
				?.GetInstance<ISearchAPI>();

		public void OnInitializeMain(IMainModCoreAPI api) {
			Instance = this;
			CoreAPI  = api;

			api.LoggerAPI.LogDebug("Initialized");

			_lang = CoreAPI.AssetAPI.GetAsset<LanguagePack>("lang.asset");
			LanguageManager.AddPack(_lang);

			_search = new Search.Search();
		}

		public async UniTask OnDisposeMainAsync() {
			LanguageManager.RemovePack(_lang);

			_search?.Dispose();

			_lang    = null;
			_search  = null;
			CoreAPI  = null;
			Instance = null;

			await UniTask.CompletedTask;
		}
	}
}
