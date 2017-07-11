using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore.API
{
	//Can be used to mocking
	//Also, most likely this is coming from the UI or some sort of watcher/listener hooked up to the UI
	/// <summary>
	/// Contract for any object that can produce authentication details.
	/// </summary>
	public interface IAuthenticationDetailsProvider
	{
		/// <summary>
		/// The authentication details.
		/// </summary>
		[NotNull]
		AuthenticationDetailsInfo Details { get; }
	}
}
