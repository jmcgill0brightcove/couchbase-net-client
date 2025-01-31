﻿using Couchbase.Core;
using Couchbase.Core.Transcoders;

namespace Couchbase.IO.Operations
{
    internal sealed class Add<T> : MutationOperationBase<T>
    {
        public Add(string key, T value, IVBucket vBucket, ITypeTranscoder transcoder, uint timeout)
            : base(key, value, vBucket, transcoder, SequenceGenerator.GetNext(), timeout)
        {
        }

        private Add(string key, T value, IVBucket vBucket, ITypeTranscoder transcoder, uint opaque, uint timeout)
            : base(key, value, vBucket, transcoder, opaque, timeout)
        {
        }

        public Add(string key, T value, ulong cas, IVBucket vBucket, ITypeTranscoder transcoder, uint timeout)
            : base(key, value, vBucket, transcoder, SequenceGenerator.GetNext(), timeout)
        {
            Cas = cas;
        }

        public override OperationCode OperationCode
        {
            get { return OperationCode.Add; }
        }

        public override IOperation Clone()
        {
            var cloned = new Add<T>(Key, RawValue, VBucket, Transcoder, Opaque, Timeout)
            {
                Attempts = Attempts,
                Cas = Cas,
                CreationTime = CreationTime,
                MutationToken = MutationToken
            };
            return cloned;
        }

        public override bool CanRetry()
        {
            return true;
        }
    }
}

#region [ License information ]

/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2014 Couchbase, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/

#endregion [ License information ]