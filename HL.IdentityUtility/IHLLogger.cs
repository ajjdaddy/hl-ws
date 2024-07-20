namespace HL.IdentityUtility
{
    public interface IHLLogger
    {
        public void WriteLogError(string errorCode, string function, string msg);
        public void WriteLogInformation(string errorCode, string function, string msg);
        public void WriteLogWarning(string errorCode, string function, string msg);
    }
}
