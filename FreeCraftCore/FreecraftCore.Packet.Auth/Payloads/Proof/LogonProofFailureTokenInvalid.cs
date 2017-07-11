﻿using System;
using System.Collections.Generic;
using System.Linq;
using FreecraftCore.API.Common;
using FreecraftCore.Serializer;

namespace FreecraftCore.Packet.Auth
{
	/// <summary>
	/// Sent by the server when a logon proof request was failed due to either an invalid SRP6 M sent
	/// or an invalid token (Authenticator pin) sent. (Ex. Invalid authenticator pin or invalid phone pin)
	/// </summary>
	[WireDataContract]
	public class LogonProofFailure : ILogonProofResult
	{
		//This is sent when SRP6 was invalid or Token failed
		/// <summary>
		/// Indicates a failure to authenticate.
		/// </summary>
		public AuthenticationResult Result { get; } = AuthenticationResult.FailUnknownAccount;

		//The below fields are always the same whether it's an invalid token or if it's an invalid SRP6 M sent.

		//TODO: What is this?
		//Trinitycore always sends 3
		[WireMember(1)]
		private readonly byte unknownOne = 3;

		//TODO: What is this?
		[WireMember(2)]
		private readonly byte unknownTwo = 0;

		//TODO: Only doing client stuff. Implement ctor later if/when we build a server.

		public LogonProofFailure()
		{

		}
	}
}

/*
ByteBuffer packet;
packet << uint8(AUTH_LOGON_PROOF);
packet << uint8(WOW_FAIL_UNKNOWN_ACCOUNT);
packet << uint8(3);
packet << uint8(0);
SendPacket(packet);
*/