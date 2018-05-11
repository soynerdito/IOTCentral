﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOTCentral.Storage
{
    public class LibreEntity
    {
        public string Endpoint { get; set; }
        public dynamic Payload { get; set; }
    }
    public class MagicFilter
    {
        private readonly IEnumerable<KeyValuePair<String, StringValues>>  _Query;

        public MagicFilter( IEnumerable<KeyValuePair<String, StringValues>> query)
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
    public class LibreStorage
    {
        /// <summary>
        /// Generic bucket to save things
        /// What things I do not know and who cares!
        /// </summary>
        public HashSet<LibreEntity> Storage { get; private set; }

        public LibreStorage()
        {
            //Initialize storage
            Storage = new HashSet<LibreEntity>();
        }

        /// <summary>
        /// Free for all select
        /// </summary>
        /// <param name="endpoint">dataset subdivision</param>
        /// <param name="predicate">what ever filter for the Payload</param>
        /// <returns></returns>
        public List<object> Get(string endpoint, Func<dynamic, bool> predicate)
        {
            if(predicate!=null)
            {
                return Storage.Where(x => x.Endpoint == endpoint).Select(x => x.Payload).Where(predicate).Select(x=>x).ToList();
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
        public bool Exists(string endpoint, dynamic payload)
        {
            //Jsonify the object then get its hash            
            return (Storage.Where(x => x.Endpoint == endpoint && x.GetHashCode() == new LibreEntity() { Endpoint = endpoint, Payload = payload }.GetHashCode() )?.Count() >0 );
        }
        /// <summary>
        /// Adds an object to the list
        /// </summary>
        /// <param name="endpoint">data set group name</param>
        /// <param name="payload">Don't know and dont care</param>
        /// <returns></returns>
        public bool Add(string endpoint, dynamic payload)
        {
            if(!Exists(endpoint, payload))
            {
                Storage.Add(
                    new LibreEntity()
                    {
                        Endpoint = endpoint,
                        Payload = payload
                    });
            }
            return false;
        }

        public int Delete(string endpoint, Func<dynamic,bool> predicate)
        {
            int removeCount = 0;
            foreach( var entry in Storage.Where(x => x.Endpoint == endpoint).Where(predicate))
            {
                Storage.Remove(entry);
                removeCount++;
            }
            return removeCount;
        }

    }
}