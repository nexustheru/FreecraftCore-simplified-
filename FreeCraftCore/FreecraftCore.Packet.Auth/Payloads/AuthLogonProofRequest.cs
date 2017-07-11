﻿using FreecraftCore.Packet.Common;
using FreecraftCore.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace FreecraftCore.Packet.Auth
{
	[WireDataContract]
	[AuthenticationPayload(AuthOperationCode.AUTH_LOGON_PROOF, AuthOperationDestinationCode.Server)] //TODO: Figure out how to support linking with the limited information.
	public class AuthLogonProofRequest : AuthenticationPayload
	{
		//TODO: Implement
		public override bool isValid { get; } = true;

		//TODO: Add BigInter serialization to our "JAM"
		/// <summary>
		/// SRP A. One of the public keys. Created by the client.
		/// See http://srp.stanford.edu/design.html for more information.
		/// </summary>
		[KnownSize(32)]
		[WireMember(1)]
		public byte[] A { get; private set; }

		/// <summary>
		/// SRP6 M. Essentially a hash of the provided token data and SRP generated data on the client.
		/// (M = H(H(N) xor H(g), H(I), salt, A, B, H(S)) where S is session key.
		/// </summary>
		[KnownSize(20)]
		[WireMember(2)]
		public byte[] M1 { get; private set; }

		//TODO: Implement clientside hash response. Is this in 1.12.1?
		//This is not a CRC. http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-emulator-servers/wow-emu-questions-requests/236273-auth-proof-crc-hash.html
		//Says that it is a SHA1(A, HMAC(client_files)) meaning SRP6 A public component hashed with an HMAC of WoW.ex, Divx and Unicows (maybe).
		/// <summary>
		/// Supposedly a hash using the empherally computed SRP6 A and some client files.
		/// Most servers don't implement this.
		/// </summary>
		[KnownSize(20)]
		[WireMember(3)]
		public byte[] EphemeralClientFileHash { get; private set; } = new byte[20]; //TODO: When we actually implement this remove this empty array

		//Documentation says it's never used
		//TODO: Find out what this is. Trinitycore doesn't seem to reference it. Neither does Mangos.
		[WireMember(4)]
		private readonly byte KeyCount = 0;

		//No server implements tokens so security flags are always 0
		[WireMember(5)]
		private readonly byte securityFlags = 0;

		public AuthLogonProofRequest([NotNull] byte[] providedA, [NotNull] byte[] m1Hash)
		{
			if (providedA == null) throw new ArgumentNullException(nameof(providedA));
			if (m1Hash == null) throw new ArgumentNullException(nameof(m1Hash));

			ThrowIfInvalidLength(nameof(providedA),
				() => GetType().GetTypeInfo().GetMember(nameof(A)).First().GetCustomAttribute<KnownSizeAttribute>(true).KnownSize, providedA.Length);

			ThrowIfInvalidLength(nameof(m1Hash),
				() => GetType().GetTypeInfo().GetMember(nameof(M1)).First().GetCustomAttribute<KnownSizeAttribute>(true).KnownSize, m1Hash.Length);

			A = providedA;
			M1 = m1Hash;
		}

		public AuthLogonProofRequest()
		{

		}

		private static void ThrowIfInvalidLength(string argumentName, Func<int> expectedLength, int actualLength)
		{
			if (expectedLength() != actualLength)
				throw new ArgumentException($"Provided SRP6a {argumentName} is invalid length. Expected {expectedLength} but was {actualLength}.");
		}
	}
}

/*typedef struct AUTH_LOGON_PROOF_C
{
	uint8   cmd;
	uint8   A[32];
	uint8   M1[20];
	uint8   crc_hash[20];
	uint8   number_of_keys;
	uint8   securityFlags;
} sAuthLogonProof_C;
*/
