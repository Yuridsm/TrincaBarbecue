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

                    reader.Read();

                    switch (propertyName)
                    {
                        case "Identifier":
                            identifier = reader.GetGuid();
                            break;
                        case "Name":
                            name = JsonSerializer.Deserialize<Name>(ref reader, options);
                            break;
                        case "ContributionValue":
                            contributionValue = JsonSerializer.Deserialize<Contribution>(ref reader, options);
                            break;
                        case "BringDrink":
                            bringDrink = reader.GetBoolean();
                            break;
                        case "Items":
                            items = JsonSerializer.Deserialize<List<string>>(ref reader, options);
                            break;
                        case "Username":
                            username = JsonSerializer.Deserialize<Username>(ref reader, options);
                            break;
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
