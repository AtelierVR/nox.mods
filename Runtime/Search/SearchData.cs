using Cysharp.Threading.Tasks;
using Nox.CCK.Convertors;
using Nox.CCK.Network.Assets;
using Nox.Mods.Runtime.Network;
using Nox.Search;
using UnityEngine;

namespace Nox.Mods.Runtime.Search {
	public class SearchData : IResultData {
		public Mod Reference;

		public int Id
			=> Reference.Identifier.GetHashCode();

		public string[] TitleArguments
			=> new[] { Reference.Title?.Resolve() ?? Reference.Identifier.ToString() };

		public UniTask<ImageSource> Image
			=> UniTask.FromResult(ImageSource.FromUrl(Reference.BestImage(1f)?.Url));   // square result slot

		/// <summary>
		/// Opens the mod page: its repository when the mod is backed by one, otherwise the
		/// canonical URL of the asset. Mods have no in-game page yet.
		/// </summary>
		public void OnClick(int menuId) {
			var url = Reference.Alias(GithubAlias) ?? Reference.Alias(ApiAlias);

			if (!string.IsNullOrEmpty(url))
				Application.OpenURL(url);
		}

		private const string GithubAlias = "github";
		private const string ApiAlias    = "api";
	}
}
