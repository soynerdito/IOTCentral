using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IotCentral.Storage
{
    public class OpenEntity
    {
        private dynamic _Payload;
        public string Endpoint { get; set; }
        public dynamic Payload
        {
            get
            {
                return _Payload;
            }
            set
            {
                _Payload = value;
                ItemHash = ComputeHash(_Payload);
            }
        }

        public string ItemHash { get; private set; }

        public static string ComputeHash(dynamic value)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(
                     Encoding.ASCII.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(value))
                );
                //return hash.ToHashSet().ToString();
                StringBuilder formatted = new StringBuilder(2 * hash.Length);
                foreach (byte b in hash)
                {
                    formatted.AppendFormat("{0:X2}", b);
                }
                return formatted.ToString();
            }
        }
    }
    public class MagicFilter
    {
        private readonly IEnumerable<KeyValuePair<String, StringValues>> _Query;

        public MagicFilter(IEnumerable<KeyValuePair<String, StringValues>> query)
        {
            this._Query = query;
        }

        public bool Evaluate(dynamic value)
        {
            foreach (var keyValue in _Query)
            {
                var possibleValue = value[keyValue.Key];
                if (possibleValue != null && possibleValue != keyValue.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class OpenStorage
    {
        /// <summary>
        /// Generic bucket to save things
        /// What things I do not know and who cares!
        /// </summary>
        public HashSet<OpenEntity> Storage { get; private set; }

        public OpenStorage()
        {
            //Initialize storage
            Storage = new HashSet<OpenEntity>();
        }

        /// <summary>
        /// Free for all select
        /// </summary>
        /// <param name="endpoint">dataset subdivision</param>
        /// <param name="predicate">what ever filter for the Payload</param>
        /// <returns></returns>
        public List<object> Get(string endpoint, Func<dynamic, bool> predicate)
        {
            if (predicate != null)
            {
                return Storage.Where(x => x.Endpoint == endpoint).Select(x => x.Payload).Where(predicate).Select(x => x).ToList();
            }
            else
            {
                return Storage.Where(x => x.Endpoint == endpoint).Select(x => x.Payload).ToList();
            }

        }
        /// <summary>
        /// Check if object exists        
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public bool Exists(OpenEntity item)
        {
            // TODO: This does not works! returns always false
            //Jsonify the object then get its hash            
            return (Storage.Where(
                x => x.Endpoint == item.Endpoint 
                && x.ItemHash == item.ItemHash )?.Count() > 0);
        }
        /// <summary>
        /// Adds an object to the list
        /// </summary>
        /// <param name="endpoint">data set group name</param>
        /// <param name="payload">Don't know and dont care</param>
        /// <returns></returns>
        public bool Add(string endpoint, dynamic payload)
        {
            var newItem = new OpenEntity()
                    {
                        Endpoint = endpoint,
                        Payload = payload
                    };
            if (!Exists(newItem))
            {
                Storage.Add( newItem );
                return true;
            }
            return false;
        }


        public int Delete(string endpoint, Func<dynamic, bool> predicate)
        {
            int removeCount = 0;
            if( predicate !=null ){
                removeCount = Storage.RemoveWhere( x=> x.Endpoint == endpoint && predicate(x.Payload)  );
            }else{
                removeCount = Storage.RemoveWhere( x=> x.Endpoint == endpoint );
            }
            // foreach (var entry in Storage.Where(x => x.Endpoint == endpoint).Select(x=> x.Payload).Where(predicate))
            // {
            //     Storage.RemoveWhere( x=> x.Endpoint == endpoint && x.Payload == entry );
            //     Storage.RemoveWhere( x=> x.Endpoint == endpoint && predicate(x.Payload)  );
            //     removeCount++;
            // }
            return removeCount;
        }

    }
}
