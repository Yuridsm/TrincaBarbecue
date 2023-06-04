using System.Text.Json;
using System.Text.Json.Serialization;
using TrincaBarbecue.Core.Aggregate.Participant;

namespace TrincaBarbecue.Infrastructure.JsonConverters
{
    public class ParticipantConverter : JsonConverter<Participant>
    {
        public override Participant Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Guid identifier = Guid.Empty;
            Name name = null;
            Contribution contributionValue = null;
            bool bringDrink = false;
            List<string> items = null;
            Username username = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();

                    if (propertyName == "Identifier")
                    {
                        reader.Read();
                        identifier = reader.GetGuid();
                    }
                    else if (propertyName == "Name")
                    {
                        reader.Read();
                        name = JsonSerializer.Deserialize<Name>(ref reader, options);
                    }
                    else if (propertyName == "ContributionValue")
                    {
                        reader.Read();
                        contributionValue = JsonSerializer.Deserialize<Contribution>(ref reader, options);
                    }
                    else if (propertyName == "BringDrink")
                    {
                        reader.Read();
                        bringDrink = reader.GetBoolean();
                    }
                    else if (propertyName == "Items")
                    {
                        reader.Read();
                        items = JsonSerializer.Deserialize<List<string>>(ref reader, options);
                    }
                    else if (propertyName == "Username")
                    {
                        reader.Read();
                        username = JsonSerializer.Deserialize<Username>(ref reader, options);
                    }
                }
            }
            return new Participant(identifier, name, contributionValue, bringDrink, items, username);
        }

        public override void Write(Utf8JsonWriter writer, Participant value, JsonSerializerOptions options)
        {
            // Implemente a lógica de serialização se necessário
            throw new NotImplementedException();
        }
    }
}
