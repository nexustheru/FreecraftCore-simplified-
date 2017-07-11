using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreecraftCore.Crypto;

namespace FreecraftCore.API.Client
{
	/// <summary>
	/// A session key provider service
	/// (The immutable version of <see cref="ISessionKeyStore"/>)
	/// </summary>
	public interface ISessionKeyProvider
	{
		/// <summary>
		/// The session key.
		/// </summary>
		BigInteger SessionKey { get; }
	}
}
