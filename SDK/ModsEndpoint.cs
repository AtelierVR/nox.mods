using Nox.Network.Assets;

namespace Nox.Mods {
	/// <summary>
	/// The mods collection: declared server-side with <c>@AssetController('mod', 'mods')</c>,
	/// so every route is the generic asset route applied to <c>mods</c>.
	/// </summary>
	public static class ModsEndpoint {
		/// <summary>Logical asset type expected by the server-side validator.</summary>
		public const string Type = "mod";

		/// <summary>REST endpoint holding the collection, relative to the node gateway.</summary>
		public const string Route = "mods";

		public static AssetEndpoint Endpoint
			=> new(Type, Route);
	}
}
