﻿#region BSD Licence
/* Copyright (c) 2013-2015, Doxense SAS
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
	* Redistributions of source code must retain the above copyright
	  notice, this list of conditions and the following disclaimer.
	* Redistributions in binary form must reproduce the above copyright
	  notice, this list of conditions and the following disclaimer in the
	  documentation and/or other materials provided with the distribution.
	* Neither the name of Doxense nor the
	  names of its contributors may be used to endorse or promote products
	  derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#endregion

namespace FoundationDB.Client
{
	using FoundationDB.Client.Utils;
	using JetBrains.Annotations;
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;

	/// <summary>Extensions methods to add FdbSubspace overrides to various types</summary>
	public static class FdbSubspaceExtensions
	{

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoding">If non-null, uses this specific instance of the TypeSystem. If null, uses the default instance for this particular TypeSystem</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbDynamicSubspace Using([NotNull] this IFdbSubspace subspace, [NotNull] IFdbKeyEncoding encoding)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoding == null) throw new ArgumentNullException("encoding");
			return FdbSubspace.CopyDynamic(subspace, encoding);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoder">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbDynamicSubspace UsingEncoder([NotNull] this IFdbSubspace subspace, [NotNull] IDynamicKeyEncoder encoder)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoder == null) throw new ArgumentNullException("encoder");
			return FdbSubspace.CopyDynamic(subspace, encoder);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoding">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbEncoderSubspace<T> UsingEncoder<T>([NotNull] this IFdbSubspace subspace, [NotNull] IFdbKeyEncoding encoding)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoding == null) throw new ArgumentNullException("encoding");
			return FdbSubspace.CopyEncoder<T>(subspace, encoding);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoder">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbEncoderSubspace<T> UsingEncoder<T>([NotNull] this IFdbSubspace subspace, [NotNull] IKeyEncoder<T> encoder)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoder == null) throw new ArgumentNullException("encoder");
			return FdbSubspace.CopyEncoder<T>(subspace, encoder);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoding">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbEncoderSubspace<T1, T2> UsingEncoder<T1, T2>([NotNull] this IFdbSubspace subspace, [NotNull] IFdbKeyEncoding encoding)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoding == null) throw new ArgumentNullException("encoding");
			return FdbSubspace.CopyEncoder<T1, T2>(subspace, encoding);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoder">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbEncoderSubspace<T1, T2> UsingEncoder<T1, T2>([NotNull] this IFdbSubspace subspace, [NotNull] ICompositeKeyEncoder<T1, T2> encoder)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoder == null) throw new ArgumentNullException("encoder");
			return FdbSubspace.CopyEncoder<T1, T2>(subspace, encoder);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoding">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbEncoderSubspace<T1, T2, T3> UsingEncoder<T1, T2, T3>([NotNull] this IFdbSubspace subspace, [NotNull] IFdbKeyEncoding encoding)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoding == null) throw new ArgumentNullException("encoding");
			return FdbSubspace.CopyEncoder<T1, T2, T3>(subspace, encoding);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoder">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbEncoderSubspace<T1, T2, T3> UsingEncoder<T1, T2, T3>([NotNull] this IFdbSubspace subspace, [NotNull] ICompositeKeyEncoder<T1, T2, T3> encoder)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoder == null) throw new ArgumentNullException("encoder");
			return FdbSubspace.CopyEncoder<T1, T2, T3>(subspace, encoder);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoding">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbEncoderSubspace<T1, T2, T3, T4> UsingEncoder<T1, T2, T3, T4>([NotNull] this IFdbSubspace subspace, [NotNull] IFdbKeyEncoding encoding)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoding == null) throw new ArgumentNullException("encoding");
			return FdbSubspace.CopyEncoder<T1, T2, T3, T4>(subspace, encoding);
		}

		/// <summary>Return a version of this subspace, which uses a different type system to produces the keys and values</summary>
		/// <param name="subspace">Instance of a generic subspace</param>
		/// <param name="encoder">Custom key encoder</param>
		/// <returns>Subspace equivalent to <paramref name="subspace"/>, but augmented with a specific TypeSystem</returns>
		public static IFdbEncoderSubspace<T1, T2, T3, T4> UsingEncoder<T1, T2, T3, T4>([NotNull] this IFdbSubspace subspace, [NotNull] ICompositeKeyEncoder<T1, T2, T3, T4> encoder)
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (encoder == null) throw new ArgumentNullException("encoder");
			return FdbSubspace.CopyEncoder<T1, T2, T3, T4>(subspace, encoder);
		}

		/// <summary>Clear the entire content of a subspace</summary>
		public static void ClearRange(this IFdbTransaction trans, [NotNull] IFdbSubspace subspace)
		{
			Contract.Requires(trans != null && subspace != null);

			//BUGBUG: should we call subspace.ToRange() ?
			trans.ClearRange(FdbKeyRange.StartsWith(subspace.ToFoundationDbKey()));
		}

		/// <summary>Clear the entire content of a subspace</summary>
		public static Task ClearRangeAsync(this IFdbRetryable db, [NotNull] IFdbSubspace subspace, CancellationToken cancellationToken)
		{
			if (db == null) throw new ArgumentNullException("db");
			if (subspace == null) throw new ArgumentNullException("subspace");

			return db.WriteAsync((tr) => ClearRange(tr, subspace), cancellationToken);
		}

		/// <summary>Returns all the keys inside of a subspace</summary>
		[NotNull]
		public static FdbRangeQuery<KeyValuePair<Slice, Slice>> GetRangeStartsWith(this IFdbReadOnlyTransaction trans, [NotNull] IFdbSubspace subspace, FdbRangeOptions options = null)
		{
			//REVIEW: should we remove this method?
			Contract.Requires(trans != null && subspace != null);

			return trans.GetRange(FdbKeyRange.StartsWith(subspace.ToFoundationDbKey()), options);
		}

		/// <summary>Tests whether the specified <paramref name="key"/> starts with this Subspace's prefix, indicating that the Subspace logically contains <paramref name="key"/>.</summary>
		/// <param name="subspace"/>
		/// <param name="key">The key to be tested</param>
		/// <exception cref="System.ArgumentNullException">If <paramref name="key"/> is null</exception>
		public static bool Contains<TKey>([NotNull] this IFdbSubspace subspace, [NotNull] TKey key)
			where TKey : IFdbKey
		{
			if (subspace == null) throw new ArgumentNullException("subspace");
			if (key == null) throw new ArgumentNullException("key");
			return subspace.Contains(key.ToFoundationDbKey());
		}

	}
}
