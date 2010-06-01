﻿//-----------------------------------------------------------------------
// <copyright file="IAuthorizationServer.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using DotNetOpenAuth.Messaging.Bindings;

namespace DotNetOpenAuth.OAuthWrap {
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using System.Linq;
	using System.Text;
	using DotNetOpenAuth.OAuth.ChannelElements;
	using DotNetOpenAuth.OAuthWrap.ChannelElements;

	[ContractClass(typeof(IAuthorizationServerContract))]
	public interface IAuthorizationServer {
		/// <summary>
		/// Gets the client with a given identifier.
		/// </summary>
		/// <param name="clientIdentifier">The client identifier.</param>
		/// <returns>The client registration.  Never null.</returns>
		/// <exception cref="ArgumentException">Thrown when no client with the given identifier is registered with this authorization server.</exception>
		IConsumerDescription GetClient(string clientIdentifier);

		/// <summary>
		/// Determines whether a described authorization is (still) valid.
		/// </summary>
		/// <param name="authorization">The authorization.</param>
		/// <returns>
		/// 	<c>true</c> if the original authorization is still valid; otherwise, <c>false</c>.
		/// </returns>
		/// <remarks>
		/// <para>When establishing that an authorization is still valid,
		/// it's very important to only match on recorded authorizations that
		/// meet these criteria:</para>
		///  1) The client identifier matches.
		///  2) The user account matches.
		///  3) The scope on the recorded authorization must include all scopes in the given authorization.
		///  4) The date the recorded authorization was issued must be <em>no later</em> that the date the given authorization was issued.
		/// <para>One possible scenario is where the user authorized a client, later revoked authorization,
		/// and even later reinstated authorization.  This subsequent recorded authorization 
		/// would not satisfy requirement #4 in the above list.  This is important because the revocation
		/// the user went through should invalidate all previously issued tokens as a matter of
		/// security in the event the user was revoking access in order to sever authorization on a stolen
		/// account or piece of hardware in which the tokens were stored. </para>
		/// </remarks>
		bool IsAuthorizationValid(IAuthorizationDescription authorization);

		byte[] Secret { get; }

		INonceStore VerificationCodeNonceStore { get; }
	}

	[ContractClassFor(typeof(IAuthorizationServer))]
	internal abstract class IAuthorizationServerContract : IAuthorizationServer {
		private IAuthorizationServerContract() {
		}

		IConsumerDescription IAuthorizationServer.GetClient(string clientIdentifier) {
			Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(clientIdentifier));
			Contract.Ensures(Contract.Result<IConsumerDescription>() != null);
			throw new NotImplementedException();
		}

		byte[] IAuthorizationServer.Secret {
			get {
				Contract.Ensures(Contract.Result<byte[]>() != null);
				throw new NotImplementedException();
			}
		}

		INonceStore IAuthorizationServer.VerificationCodeNonceStore {
			get {
				Contract.Ensures(Contract.Result<INonceStore>() != null);
				throw new NotImplementedException();
			}
		}

		bool IAuthorizationServer.IsAuthorizationValid(IAuthorizationDescription authorization) {
			Contract.Requires<ArgumentNullException>(authorization != null, "authorization");
			throw new NotImplementedException();
		}
	}

}
