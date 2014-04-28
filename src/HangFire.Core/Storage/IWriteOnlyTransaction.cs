// This file is part of HangFire.
// Copyright � 2013-2014 Sergey Odinokov.
// 
// HangFire is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3 
// of the License, or any later version.
// 
// HangFire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with HangFire. If not, see <http://www.gnu.org/licenses/>.

using System;
using HangFire.States;

namespace HangFire.Storage
{
    public interface IWriteOnlyTransaction : IDisposable
    {
        // Job operations
        void ExpireJob(string jobId, TimeSpan expireIn);
        void PersistJob(string jobId);
        void SetJobState(string jobId, State state);
        void AddJobState(string jobId, State state);

        // Queue operations
        void AddToQueue(string queue, string jobId);

        // Counter operations
        void IncrementCounter(string key);
        void IncrementCounter(string key, TimeSpan expireIn);
        void DecrementCounter(string key);
        void DecrementCounter(string key, TimeSpan expireIn);

        // Set operations
        void AddToSet(string key, string value);
        void AddToSet(string key, string value, double score);
        void RemoveFromSet(string key, string value);

        // List operations
        void InsertToList(string key, string value);
        void RemoveFromList(string key, string value);
        void TrimList(string key, int keepStartingFrom, int keepEndingAt);

        // Value operations
        void IncrementValue(string key);
        void DecrementValue(string key);
        void ExpireValue(string key, TimeSpan expireIn);

        void Commit();
    }
}