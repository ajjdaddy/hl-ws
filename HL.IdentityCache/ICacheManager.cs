namespace HL.IdentityCache
{
    public interface ICacheManager
    {
        public Task<HuongLinh> GetHuongLinhByName(string huongLinhName);
        public Task<HuongLinh> GetHuongLinhByID(int huongLinhID);
        public Task<bool> UpdateHuongLinhByID(int id, HuongLinh huongLinhData);
        public Task<bool> UpdateHuongLinhByName(string name, HuongLinh huongLinhData);
        public Task<bool> AddHuongLinh(string name, HuongLinh huongLinhData);
    }
}
