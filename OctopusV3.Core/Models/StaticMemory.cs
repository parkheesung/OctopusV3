using System;
using System.Collections.Concurrent;
using System.Threading;

namespace OctopusV3.Core
{
    public class StaticMemory
    {
        private static readonly Lazy<StaticMemory> lazy = new Lazy<StaticMemory>(() => new StaticMemory());
        public static StaticMemory Current { get { return lazy.Value; } }

        public ConcurrentDictionary<string, object> Cache { get; set; } = new ConcurrentDictionary<string, object>();

        protected Timer clearTimer { get; set; }

        public StaticMemory()
        {
        }

        public void SetClearTime(int Minute)
        {
            if (this.clearTimer == null)
            {
                this.clearTimer = new Timer(ClearTimerTick, null, 1000 * 60 * Minute, Timeout.Infinite);
            }
        }

        private void ClearTimerTick(object state)
        {
            this.Cache.Clear();
            this.clearTimer = null;
        }

        public T Get<T>(string key) where T : class
        {
            T result = default(T);

            if (!string.IsNullOrWhiteSpace(key))
            {
                if (this.Cache.ContainsKey(key))
                {
                    object obj = null;
                    if (this.Cache.TryGetValue(key, out obj))
                    {
                        result = obj as T;
                    }
                }
            }

            return result;
        }

        public void Set<T>(string key, T obj) where T : class
        {
            this.Cache.AddOrUpdate(key, obj, (oldkey, oldValue) => obj);
        }

        public bool Exists(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                return this.Cache.ContainsKey(key);
            }
            else
            {
                return false;
            }
        }
    }
}
