using Nox.Network.Assets;

namespace Nox.Mods {
	/// <summary>
	/// A mod published on a node. Mods are declared server-side with
	/// <c>@AssetController('mod', 'mods')</c> and expose exactly the generic asset shape, so
	/// <see cref="IMod"/> brings no member of its own: it gives the collection its own type.
	/// Not to be confused with <c>Nox.CCK.Mods.IMod</c>, a mod loaded by the runtime.
	/// </summary>
	public interface IMod : IAsset { }
}
