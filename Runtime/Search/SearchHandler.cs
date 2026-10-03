using System;
using System.Linq;
using Nox.CCK.Search;
using Nox.Search;
using UnityEngine;

namespace Nox.Mods.Runtime.Search {
	public class SearchHandler : IHandler {
		public string GetId()
			=> Main.Instance.CoreAPI.ModMetadata.GetId();

		public string GetTitleKey()
			=> "mod.search.title";

		public string[] GetTitleArguments()
			=> Array.Empty<string>();

		public string GetPlaceholderKey()
			=> "mod.search.placeholder";

		public string[] GetPlaceholderArguments()
			=> Array.Empty<string>();

		public Texture2D GetIcon()
			=> Main.Instance.CoreAPI.AssetAPI
				.GetAsset<Texture2D>("ui:icons/apps.png");

		public string GetDescriptionKey()
			=> "mod.search.description";

		public string[] GetDescriptionArguments()
			=> Array.Empty<string>();

		/// <summary>One worker per server that advertises the <c>mod</c> feature.</summary>
		public IWorker[] GetWorkers()
			=> SearchHelper.ServersBy(ModsEndpoint.Type)
				.Select(s => new SearchWorker { Title = s.Title, Server = s.Address })
				.ToArray<IWorker>();
	}
}
