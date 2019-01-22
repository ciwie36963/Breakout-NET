using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreakOutGameTest.Data
{
    class MockSession : ISession
    {
        public MockSession()
        {
            _storage = new Dictionary<string, byte[]>();
        }

        private Dictionary<string, byte[]> _storage;




        public bool IsAvailable { get { return true; } }

        public string Id => throw new NotImplementedException();

        public IEnumerable<string> Keys { get { return _storage.Keys; } }

        public void Clear()
        {
            _storage = new Dictionary<string, byte[]>();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            _storage.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            _storage.Add(key, value);
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            return _storage.TryGetValue(key, out value);
        }
    }
}
