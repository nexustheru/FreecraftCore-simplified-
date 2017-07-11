using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreecraftCore.Crypto;

namespace FreecraftCore.API.Client
{
	/// <summary>
	/// The mutable session key store.
	/// </summary>
	public interface ISessionKeyStore
	{
		/// <summary>
		/// The session key.
		/// </summary>
		BigInteger SessionKey { get; set; }
	}
}
