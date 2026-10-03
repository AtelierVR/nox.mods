using System;
using Newtonsoft.Json;
using Nox.CCK.Network.Assets;
using Nox.CCK.Utils;

namespace Nox.Mods.Runtime.Network {
	/// <summary>
	/// A mod as returned by the <c>mods</c> endpoint: the generic <see cref="Asset"/>. The API
	/// exposes no mod-only value, so nothing is added here; the collection is only typed to get
	/// the right model out of the search.
	/// </summary>
	[Serializable, JsonObject]
	public class Mod : Asset, IMod, INoxObject {
		public override string ToString()
			=> $"{GetType().Name}[id={Id}, name={Name ?? "<no-name>"}, owner={Owner}, server={Server}, images={Images?.Length ?? 0}]";
	}
}
