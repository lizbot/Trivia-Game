using System;
using System.Collections.Generic;
using SQLite;
using Infrastructure.Model;
using System.Linq;
using Answer = Infrastructure.Model.Answer;
using Category = Infrastructure.Model.Category;
using GameSaved = Infrastructure.Model.GameSaved;

namespace Infrastructure.Initialization
{
    public class DatabaseInitialization
    {

        public Questions Question { get; set; }

        /// <summary>
        /// Initializes the database tables and configuration.
        /// </summary>
        public static void Database()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                DeleteFromDb();

                db.CreateTable<Questions>();
                db.CreateTable<Answer>();
                //db.CreateTable<Options>();
                // db.CreateTable<Statistics>();
                db.CreateTable<GameSaved>();
                db.CreateTable<Category>();
            }

            // Generate base scripts for initializing values in the database.
            GenerateCategories();
            GenerateQuestionsAndAnswers();

            //Use for testing.
            // DoesQuestionNameInTableExist("Hello?");
            //var questions = GetQuestions("How are you?");
            //var categoryId = questions.CategoryId;
        }

        private static void DeleteFromDb()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                db.DropTable<Questions>();
                db.DropTable<Answer>();
                db.DropTable<Category>();

                db.Commit();
            }
        }

        private static void GenerateQuestionsAndAnswers()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                String questionName;
                Int32 categoryId;
                String rightAnswerName;
                List<String> wrongAnswerNames;

                //Create the information to generate the questions and answers.
                questionName = "What is a theme park located in Anaheim, California near the city of Stanton. The park's slogan is \"The Little Theme Park that's BIG on Family Fun\"?";
                categoryId = 5;
                rightAnswerName = "Adventure City";
                wrongAnswerNames = new List<String> { "Epcot", "PR", "Midway", "State Park" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a group of amusement parks located in Florida, New York, North Carolina and Texas?";
                categoryId = 5;
                rightAnswerName = "Adventure Landing";
                wrongAnswerNames = new List<string> { "Jolly Roger Amusement Park", "White Water Branson", "Six Flags Over Texas" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a  indoor amusement park (formerly known as Grand Slam Canyon) located at Circus Circus in Winchester, Nevada on the Las Vegas Strip?";
                categoryId = 5;
                rightAnswerName = "Adventuredome";
                wrongAnswerNames = new List<string> { "Elitch Gardens Theme Park", "Six Flags New England", "Fantasilandia" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a Mexican zoo park that was established in 1972 by Captain Carlos Camacho Espíritu. It is located about  from the city of Puebla?";
                categoryId = 5;
                rightAnswerName = "African Safari";
                wrongAnswerNames = new List<string> { "Kings Dominion", "Aqua Adventure", "Pyrite Rapids Water Park" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a family-owned safari park situated in Flamborough, Hamilton, Ontario, Canada, about  west of Toronto?";
                categoryId = 5;
                rightAnswerName = "African Lion Safari";
                wrongAnswerNames = new List<string> { "Baja Amusements", "Kings Island", "La Venezuela de Antier" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a water park located in Central Park in Fremont, California?";
                categoryId = 5;
                rightAnswerName = "Aqua Adventure";
                wrongAnswerNames = new List<string> { "Big Sky Water Park", "Adventuredome", "Epcot" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a chain of water parks owned and operated by SeaWorld Parks & Entertainment. Aquatica parks are operating in Orlando, Florida and San Antonio, Texas, with a third location set to open in Chula Vista, California in 2011?";
                categoryId = 5;
                rightAnswerName = "Aquatica San Diego";
                wrongAnswerNames = new List<string> { "Salitre Magico", "Aquasol Theme Park", "Musipan" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a Water park located in Arkadelphia, Arkansas?";
                categoryId = 5;
                rightAnswerName = "Arkadelphia Aquatic Park";
                wrongAnswerNames = new List<string> { "Camelbeach Waterpark", "Africam Safari", "Miami Seaquarium" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a city in Dickinson County, Iowa, United States. The population was 1,126 in the 2010 census, a decline from the 1,162 population in the 2000 census?";
                categoryId = 5;
                rightAnswerName = "Arnolds Park";
                wrongAnswerNames = new List<string> { "Musipan", "Disney California Adventure Park", "CoCo Key Water Resort" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is an amusement park, campground and automobile race track located in Warren County, Kentucky, just outside the limits of the city of Bowling Green?";
                categoryId = 5;
                rightAnswerName = "Beech Bend Park";
                wrongAnswerNames = new List<string> { "Universal Studios Hollywood", "Funderland", "Six Flags Hurricane Harbor" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a water park located at the Walt Disney World Resort in Bay Lake, Florida?";
                categoryId = 5;
                rightAnswerName = "Blizzard Beach";
                wrongAnswerNames = new List<string> { "Big Sky Water Park", "Crystal Palace Amusement Park", "Hopi Hari" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a  19th century African-themed animal theme park located in the city of Tampa, Florida?";
                categoryId = 5;
                rightAnswerName = "Busch Gardens Tampa Bay";
                wrongAnswerNames = new List<string> { "Fantasilandia", " Villa Campestre", "Calaway Park" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a  theme park located in James City County, Virginia, about 3 miles (5 km) southeast of Williamsburg, originally developed by Anheuser-Busch (A-B) and currently owned by SeaWorld Parks & Entertainment, a division of The Blackstone Group?";
                categoryId = 5;
                rightAnswerName = "Busch Gardens Williamsburg";
                wrongAnswerNames = new List<string> { "Six Flags Hurricane Harbor", "Western Playland", "Los Aleros" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is the practice of flying maneuvers involving aircraft attitudes that are not used in normal flight?";
                categoryId = 2;
                rightAnswerName = "Aerobatics";
                wrongAnswerNames = new List<string> {"Mountainboarding", "Shoot boxing", "kung fu"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a Japanese martial art developed by Morihei Ueshiba as a synthesis of his martial studies, philosophy, and religious beliefs?";
                categoryId = 2;
                rightAnswerName = "Aikido";
                wrongAnswerNames = new List<string> {"Ba game", "Muay Thai", "Savate"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a motorsport that involves airplanes competing over a fixed course, with the winner either returning the shortest time, the one to complete it with the most points, or to come closest to a previously estimated time?";
                categoryId = 2;
                rightAnswerName = "Air racing";
                wrongAnswerNames = new List<string> {"Clout archery", "Hwa Rang Do", "Kickboxing"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a sport or recreational activity in which participants eliminate opponents by hitting each other with spherical non-metallic pellets launched via replica firearms?";
                categoryId = 2;
                rightAnswerName = "Airsoft";
                wrongAnswerNames = new List<string> {"Artistic billiards", "Rodeo", "International rules football"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a team sport. It is played by two teams, eleven players to a side, who advance an oval ball  over a rectangular field that is 120 yards long by 53.3 yards wide and has goalposts at both ends?";
                categoryId = 2;
                rightAnswerName = "American football";
                wrongAnswerNames = new List<string> {"Sandboarding", "Horse racing", "Flight archery"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a method of fishing by means of an angle (fish hook). The hook is usually attached to a fishing line and the line is often attached to a fishing rod?";
                categoryId = 2;
                rightAnswerName = "Angling";
                wrongAnswerNames = new List<string> {"Disc golf", "Trick shot competition", "Sumo"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a variety of gridiron football played by the Arena Football League (AFL). It is a proprietary game, the rights to which are owned by Gridiron Enterprises, and is played indoors on a smaller field than American or Canadian outdoor football, resulting in a faster and higher-scoring game?";
                categoryId = 2;
                rightAnswerName = "Arena football";
                wrongAnswerNames = new List<string> {"Harpastum" ,  "Equestrian vaulting" , "Street football"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a carom billiards discipline in which players compete at performing 76 preset shots of varying difficulty?";
                categoryId = 2;
                rightAnswerName = "Artistic billiards";
                wrongAnswerNames = new List<string> { "Pato", "Taido", "Pehlwani" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a form of competitive indoor cycling in which athletes perform tricks (called exercises) for points on specialized, fixed-gear bikes in a format similar to ballet or gymnastics?";
                categoryId = 2;
                rightAnswerName = "Artistic cycling";
                wrongAnswerNames = new List<string> { "Test cricket", "Obstacle variations", "A Bracciuta" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a shot played on a billiards table (most often a pool table, though snooker tables are also used), which seems unlikely or impossible or requires significant skill?";
                categoryId = 2;
                rightAnswerName = "Artistic pool";
                wrongAnswerNames = new List<string> { "Kuk Sool Won", "Artistic billiards", "Western Pleasure" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a sport played between two teams of typically eleven players, though other variations in player numbers such as 5 and 7 are also played, with a spherical ball?";
                categoryId = 2;
                rightAnswerName = "Association football";
                wrongAnswerNames = new List<string> { "Haidong Gumdo", "Flag football", "Harness racing" };

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is marketed as AFL, after the Australian Football League, the only fully professional  league) is a sport played between two teams of 18 players on the field on either an Australian Football ground, a modified cricket field or similar sized sports venue?";
                categoryId = 2;
                rightAnswerName = "Australian football";
                wrongAnswerNames = new List<string> {"Kurash", "Eton College", "Beach basketball"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);

                questionName = "What is a sport which was started in Australia during World War II when U.S. soldiers wanted to play a form of football against the Australians?";
                categoryId = 2;
                rightAnswerName = "Austus";
                wrongAnswerNames = new List<string> {"Zui Quan", "Unicycle hockey", "Surf fishing"};

                GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);
            }
        }

        private static void GenerateAnswersForQuestions(String questionName, Int32 categoryId, String rightAnswerName, IEnumerable<String> wrongAnswerNames)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var question = new Questions
                {
                    CategoryId = categoryId,
                    QuestionName = questionName,
                    TimesCorrect = 0,
                    TimesViewed = 0
                };

                db.Insert(question);
                var questionId = question.QuestionId;

                var rightAnswer = new Answer
                {
                    IsCorrect = true,
                    Name = rightAnswerName,
                    QuestionId = questionId
                };

                db.Insert(rightAnswer);

                var wrongAnswers = wrongAnswerNames
                    .Select(answer => new Answer
                        {
                            IsCorrect = false,
                            Name = answer,
                            QuestionId = questionId
                        })
                    .ToList();

                db.InsertAll(wrongAnswers);

                db.Commit();
            }
        }

        /// <summary>
        /// Generates Categories to create static information to test with until we get Jorge's stuff in here.
        /// </summary>
        private static void GenerateCategories()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var c1 = new Category { Name = "Sports" };
                var c2 = new Category { Name = "Education" };
                var c3 = new Category { Name = "People" };
                var c4 = new Category { Name = "Geography" };
                var c5 = new Category { Name = "Entertainment" };

                var categories = new List<Category> { c1, c2, c3, c4, c5 };

                db.BeginTransaction();
                db.InsertAll(categories);

                db.Commit();
            }
        }
    }
}