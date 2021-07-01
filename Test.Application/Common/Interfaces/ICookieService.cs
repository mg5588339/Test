namespace Test.Application.Common.Interfaces
{
    public interface ICookieService
    {
        /// <summary>  
        /// Get the key value
        /// </summary>  
        /// <param name="key">Key</param>  
        string Get(string key);
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time (Minutes)</param>  
        void Set(string key, string value, int? expireTime);
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        void Remove(string key);
    }
}
