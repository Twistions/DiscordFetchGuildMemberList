namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MemberListUpdate
    {
        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("s")]
        public long S { get; set; }

        [JsonProperty("op")]
        public long Op { get; set; }

        [JsonProperty("d")]
        public D D { get; set; }
    }

    public partial class D
    {
        [JsonProperty("ops")]
        public List<Op> Ops { get; set; }

        [JsonProperty("online_count")]
        public long OnlineCount { get; set; }

        [JsonProperty("member_count")]
        public long MemberCount { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }

    public partial class Group
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public partial class Op
    {
        [JsonProperty("range")]
        public List<long> Range { get; set; }

        [JsonProperty("op")]
        public string OpOp { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("member", NullValueHandling = NullValueHandling.Ignore)]
        public Member Member { get; set; }

        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public Group Group { get; set; }
    }

    public partial class Member
    {
        [JsonProperty("user")]
        public MemberUser User { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("presence")]
        public Presence Presence { get; set; }

        [JsonProperty("premium_since")]
        public object PremiumSince { get; set; }

        [JsonProperty("nick")]
        public string Nick { get; set; }

        [JsonProperty("mute")]
        public bool Mute { get; set; }

        [JsonProperty("joined_at")]
        public DateTimeOffset JoinedAt { get; set; }

        [JsonProperty("hoisted_role")]
        public string HoistedRole { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }

        [JsonProperty("is_pending", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPending { get; set; }
    }

    public partial class Presence
    {
        [JsonProperty("user")]
        public PresenceUser User { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("client_status")]
        public ClientStatus ClientStatus { get; set; }

        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }
    }

    public partial class Activity
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("emoji", NullValueHandling = NullValueHandling.Ignore)]
        public Emoji Emoji { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("timestamps", NullValueHandling = NullValueHandling.Ignore)]
        public Timestamps Timestamps { get; set; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public string Details { get; set; }

        [JsonProperty("assets", NullValueHandling = NullValueHandling.Ignore)]
        public Assets Assets { get; set; }

        [JsonProperty("application_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationId { get; set; }

        [JsonProperty("sync_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncId { get; set; }

        [JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionId { get; set; }

        [JsonProperty("party", NullValueHandling = NullValueHandling.Ignore)]
        public Party Party { get; set; }

        [JsonProperty("flags", NullValueHandling = NullValueHandling.Ignore)]
        public long? Flags { get; set; }
    }

    public partial class Assets
    {
        [JsonProperty("large_text", NullValueHandling = NullValueHandling.Ignore)]
        public string LargeText { get; set; }

        [JsonProperty("large_image", NullValueHandling = NullValueHandling.Ignore)]
        public string LargeImage { get; set; }

        [JsonProperty("small_text", NullValueHandling = NullValueHandling.Ignore)]
        public string SmallText { get; set; }

        [JsonProperty("small_image", NullValueHandling = NullValueHandling.Ignore)]
        public string SmallImage { get; set; }
    }

    public partial class Emoji
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("animated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Animated { get; set; }
    }

    public partial class Party
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> Size { get; set; }
    }

    public partial class Timestamps
    {
        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public long? End { get; set; }
    }

    public partial class ClientStatus
    {
        [JsonProperty("web", NullValueHandling = NullValueHandling.Ignore)]
        public Status? Web { get; set; }

        [JsonProperty("desktop", NullValueHandling = NullValueHandling.Ignore)]
        public Status? Desktop { get; set; }

        [JsonProperty("mobile", NullValueHandling = NullValueHandling.Ignore)]
        public Status? Mobile { get; set; }
    }

    public partial class PresenceUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class MemberUser
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("public_flags", NullValueHandling = NullValueHandling.Ignore)]
        public long? PublicFlags { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("bot", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Bot { get; set; }
    }

    public enum Status { Dnd, Idle, Online };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                StatusConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "dnd":
                    return Status.Dnd;
                case "idle":
                    return Status.Idle;
                case "online":
                    return Status.Online;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Dnd:
                    serializer.Serialize(writer, "dnd");
                    return;
                case Status.Idle:
                    serializer.Serialize(writer, "idle");
                    return;
                case Status.Online:
                    serializer.Serialize(writer, "online");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }
}
