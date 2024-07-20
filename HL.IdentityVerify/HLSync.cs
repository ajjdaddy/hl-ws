using HL.IdentityUtility;

// TODO: Future: Implement HL Sync to HLClient
namespace HL.IdentitySync
{
    public class HLSync : IHLSync
    {
        HLLogger log = new HLLogger("HLSync");
        public bool IsRunning { get; set; }
    }
}
