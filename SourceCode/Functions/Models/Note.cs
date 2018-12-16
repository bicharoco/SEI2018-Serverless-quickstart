using System;
using Newtonsoft.Json;

namespace SEI2018.Models
{
    public class Note
    {
        #region Private members

        private Guid? _id = null; 

        #endregion

        #region Public Properties

        [JsonProperty(PropertyName = "id")]
        public Guid? Id {
            get
            {
                if (_id == null)
                {
                    _id = Guid.NewGuid();
                }

                return _id.Value;
            }
            set => _id = value;
        }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        #endregion
    }
}
