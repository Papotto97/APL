namespace APL_FE.Utils
{
    public partial class EncryptionDecryptionUtils
    {
        protected static readonly string _localMasterKey = "QVBMLk1vbmdvLkVuY3J5cHRpb24uS2V5LlBhcG90dG8uUmVzdGl2by5SdXNzbw==";
        protected static readonly string DETERMINISTIC_ENCRYPTION_TYPE = "AEAD_AES_256_CBC_HMAC_SHA_512-Deterministic";
        protected static readonly string RANDOM_ENCRYPTION_TYPE = "AEAD_AES_256_CBC_HMAC_SHA_512-Random";

        //AutoEncryptionOptions autoEncryptionOptions = new AutoEncryptionOptions();
    }
}
