﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalytics.JsonConverters
{
    public class TrainerConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Trainer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(Trainer))
            {
                JObject obj = serializer.Deserialize<JToken>(reader) as JObject;
                if (obj != null)
                {

                    var trainer = new Trainer(null);
                    trainer.ReadJson(obj);
                    return trainer;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }

        public override bool CanWrite { get { return false; } }
    }
}
