using ClassLibrary;
using MySql.Data.MySqlClient;

namespace Assemblage.Services
{
    public class ConversationDAO : IConversationDAO
    {
        private readonly string connectionString;

        public ConversationDAO()
        {
            this.connectionString = "datasource=localhost;port=8889;username=root;password=root;database=assemblage;";
        }

        public void CreateConversation(ConversationModel conversation)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO conversations (Title, LastMessage, TimeStamp) VALUES (@Title, @LastMessage, @TimeStamp)", connection);
                command.Parameters.AddWithValue("@Title", conversation.Title);
                command.Parameters.AddWithValue("@LastMessage", conversation.LastMessage);
                command.Parameters.AddWithValue("@TimeStamp", conversation.TimeStamp);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteConversation(int conversationId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("DELETE FROM conversations WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", conversationId);

                command.ExecuteNonQuery();
            }
        }

        public List<ConversationModel> GetAll()
        {
            List<ConversationModel> conversations = new List<ConversationModel>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM conversations", connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ConversationModel conversation = new ConversationModel
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            //LastMessage = reader.IsDBNull(reader.GetOrdinal("LastMessage")) ? null : reader.GetString(reader.GetOrdinal("LastMessage")),
                            TimeStamp = reader.GetDateTime(reader.GetOrdinal("TimeStamp"))
                        };

                        conversations.Add(conversation);
                    }
                }
            }

            return conversations;
        }


        public ConversationModel GetConversationByID(int conversationId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM conversations WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", conversationId);

                MySqlDataReader reader = command.ExecuteReader();

                ConversationModel conversation = null;

                if (reader.Read())
                {
                    conversation = new ConversationModel
                    {
                        ID = reader.GetInt32("ID"),
                        Title = reader.GetString("Title"),
                        //LastMessage = reader.IsDBNull(reader.GetOrdinal("LastMessage")) ? null : reader.GetString("LastMessage"),
                        TimeStamp = reader.GetDateTime("TimeStamp")
                    };
                }

                return conversation;
            }
        }

        public ConversationModel GetConversationByTitle(string conversationTitle)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM conversations WHERE Title like @Title", connection);
                command.Parameters.AddWithValue("@Title", "%" + conversationTitle + "%");

                MySqlDataReader reader = command.ExecuteReader();

                ConversationModel conversation = null;

                if (reader.Read())
                {
                    conversation = new ConversationModel
                    {
                        ID = reader.GetInt32("ID"),
                        Title = reader.GetString("Title"),
                        //LastMessage = reader.IsDBNull(reader.GetOrdinal("LastMessage")) ? null : reader.GetString("LastMessage"),
                        TimeStamp = reader.GetDateTime("TimeStamp")
                    };
                }

                return conversation;
            }
        }

        public void UpdateConversation(ConversationModel conversation)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("UPDATE conversations SET Title = @Title, LastMessage = @LastMessage, TimeStamp = @TimeStamp WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", conversation.ID);
                command.Parameters.AddWithValue("@Title", conversation.Title);
                command.Parameters.AddWithValue("@LastMessage", conversation.LastMessage);
                command.Parameters.AddWithValue("@TimeStamp", conversation.TimeStamp);

                command.ExecuteNonQuery();
            }
        }
    }

}
