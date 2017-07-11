using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore.API
{
	/// <summary>
	/// Immutable structure containing the details for authentication
	/// </summary>
	public class AuthenticationDetailsInfo
	{
		/// <summary>
		/// The account name for authentication.
		/// </summary>
		[NotNull]
		public string AccountName { get; }

		/// <summary>
		/// The plaintext password for authentication.
		/// </summary>
		[NotNull]
		public string PlainTextPassword { get; }

		public AuthenticationDetailsInfo([NotNull] string accountName, [NotNull] string plainTextPassword)
		{
			if (string.IsNullOrWhiteSpace(accountName))
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(accountName));
			if (string.IsNullOrWhiteSpace(plainTextPassword))
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(plainTextPassword));

			AccountName = accountName;
			PlainTextPassword = plainTextPassword;
		}
	}
}
