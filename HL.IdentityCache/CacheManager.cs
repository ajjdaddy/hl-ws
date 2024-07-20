using System.Diagnostics;

namespace HL.IdentityCache
{
    public class CacheManager : ICacheManager
    {
        private static CacheManager _instance = null;
        private IdentityCache cache = null;
        private static object _lockObject = new object();

        public IdentityCache Cache
        {
            get { return cache; }
        }

        public static CacheManager Instance
        {
            get { return _instance ??= new CacheManager(); }
        }

        public CacheManager()
        {
            cache = new IdentityCache();
            cache.ChangeTracker.Clear();
        }

        private bool CheckConnection()
        {
            if (cache == null || !cache.Database.CanConnect())
                cache = new IdentityCache();

            return cache != null;
        }

        public void CloseCacheManager()
        {
            try
            {
                if (cache != null)
                {
                    cache.SaveChanges();
                    cache.Dispose();
                    cache = null;
                }

                _instance = null;
            }
            catch { }
        }

        public async Task<HuongLinh> GetHuongLinhByName(string huongLinhName)
        {
            if (CheckConnection())
            {
                var huongLinh = cache?.HuongLinhList
                        .Where(i => i.Name == huongLinhName)
                        .FirstOrDefault();
                return huongLinh;
            }
            return null;
        }

        public async Task<HuongLinh> GetHuongLinhByID(int huongLinhID)
        {
            if (CheckConnection())
            {
                var huongLinh = cache?.HuongLinhList
                        .Where(i => i.ID == huongLinhID)
                        .FirstOrDefault();
                return huongLinh;
            }
            return null;
        }

        /// <summary>
        /// TODO (CD): Update HuongLinh by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="huongLinhData"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateHuongLinhByID(int id, HuongLinh huongLinhData)
        {
            if (CheckConnection())
            {
                var hlRow = await GetHuongLinhByID(id);
                if (hlRow != null)
                {
                    if (cache == null)
                        return false;

                    Debug.WriteLine($"Updating huong linh '{id}: {hlRow.Name}'");
                    try
                    {
                        // TODO (CD): Assing new values from huongLinhData
                        cache.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        if (e.InnerException != null && e.InnerException.GetType() == typeof(Microsoft.Data.Sqlite.SqliteException))
                        {
                            // duplicate
                            if (e.InnerException.Message.Contains("UNIQUE constraint failed"))
                                return true;

                        }
                        throw new Exception(e?.InnerException?.Message ?? e?.Message);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// TODO (CD): Update HuongLinh by Name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="huongLinhData"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateHuongLinhByName(string name, HuongLinh huongLinhData)
        {
            // TODO (CD): Add logic similar to UpdateHuongLinhByID
            return false;
        }

        public async Task<bool> AddHuongLinh(string name, HuongLinh huongLinhData)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            var hlRow = await GetHuongLinhByName(name);
            if (hlRow != null)
            {
                // huonglinh already exists
                return true;
            }

            lock (_lockObject)
            {
                if (CheckConnection())
                {
                    if (cache == null)
                        return false;

                    Debug.WriteLine("Adding huong linh: " + name);
                    try
                    {
                        cache.HuongLinhList.Add(huongLinhData);
                        cache.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {

                        Debug.WriteLine("Add huong linh error: " + e.Message);
                        if (e.InnerException != null && e.InnerException.Message != null)
                            Debug.WriteLine(e.InnerException.Message);
                        if (e.InnerException != null && e.InnerException.GetType() == typeof(Microsoft.Data.Sqlite.SqliteException))
                        {
                            // duplicate
                            if (e.InnerException.Message.Contains("UNIQUE constraint failed"))
                            {
                                Debug.WriteLine("Huong linh already exists");
                                return true;
                            }

                            else
                                throw new Exception(e.InnerException.Message);
                        }

                        throw new Exception(e.InnerException.Message ?? e?.Message);
                    }
                }

                return false;
            }
        }

        // TODO (CD): Add all neccessary/needed methods
    }
}
