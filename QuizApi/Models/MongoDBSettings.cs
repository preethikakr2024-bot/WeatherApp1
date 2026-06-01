using System;

namespace QuizApi.Models;

public class MongoDBSettings
{
        public string ConnectionString { get; set; } = null!;
        public string Database { get; set; } = null!;
}
