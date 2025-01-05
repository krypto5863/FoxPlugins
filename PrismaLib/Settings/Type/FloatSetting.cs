﻿namespace PrismaLib.Settings.Type
{
    public class FloatSetting : Setting<float>
    {
        public FloatSetting(string key) : base(key)
        {
        }

        public FloatSetting(string key, float defaultValue) : base(key, defaultValue)
        {
        }

        public FloatSetting(string key, float defaultValue, bool addToPool) : base(key, defaultValue, addToPool)
        {
        }

        public override void Load()
        {
            Value = Settings.Storage.GetFloat(Key, DefaultValue);
        }

        public override void Save() => Settings.Storage.SetFloat(Key, Value);
    }
}