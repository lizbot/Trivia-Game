using System;
using System.Collections.Generic;
using Application.Model;
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

        private static void GenerateQuestionsAndAnswers()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                String questionName = null;
                Int32 categoryId = 0;
                String rightAnswerName = null;
                var wrongAnswerNames = new List<String>();
                    
                //Create the information to generate the questions and answers.
                questionName = "What is a theme park located in Anaheim, California near the city of Stanton. The park's slogan is \"The Little Theme Park that's BIG on Family Fun\"?";
                categoryId = 5;
                rightAnswerName = "Adventure City";
                wrongAnswerNames = new List<String>{"Epcot", "PR", "Midway", "State Park" };

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

//What is a Mexican zoo park that was established in 1972 by Captain Carlos Camacho Espíritu. It is located about  from the city of Puebla?
//Africam Safari    Kings Dominion    Aqua Adventure    Pyrite Rapids Water Park

//What is a family-owned safari park situated in Flamborough, Hamilton, Ontario, Canada, about  west of Toronto?
//African Lion Safari    Baja Amusements    Kings Island    La Venezuela de Antier

//What is a water park located in Central Park in Fremont, Californi?
//Aqua Adventure    Big Sky Water Park    Adventuredome    Epcot

//What is a chain of water parks owned and operated by SeaWorld Parks & Entertainment. Aquatica parks are operating in Orlando, Florida and San Antonio, Texas, with a third location set to open in Chula Vista, California in 201?
//Aquatica San Diego    Salitre Magico    Aquasol Theme Park    Musipan

//What is a Water park located in Arkadelphia, Arkansas. [http://lasr.net/pages/city.php?Arkadelphia&AR&Arkadelphia+Aquatic+Park&City_ID=AR0401001&Attraction_ID=AR0401001a003&VA=Y]  During the 2006 season, nearly 25,000 individuals visited the park?
//Arkadelphia Aquatic Park    Camelbeach Waterpark    Africam Safari    Miami Seaquarium

//What is a city in Dickinson County, Iowa, United States. The population was 1,126 in the 2010 census, a decline from the 1,162 population in the 2000 census?
//Arnolds Park    Musipan    Disney California Adventure Park    CoCo Key Water Resort

//What is an amusement park, campground and automobile race track located in Warren County, Kentucky, just outside the limits of the city of Bowling Green?
//Beech Bend Park    Universal Studios Hollywood    Funderland    Six Flags Hurricane Harbor

//What is a water park located at the Walt Disney World Resort in Bay Lake, Florid?
//Blizzard Beach    Big Sky Water Park    Crystal Palace Amusement Park    Hopi Hari

//What is a  19th century African-themed animal theme park located in the city of Tampa, Florida?
//Busch Gardens Tampa Bay    Fantasilandia    Villa Campestre    Calaway Park

//What is a  theme park located in James City County, Virginia, about 3 miles (5 km) southeast of Williamsburg, originally developed by Anheuser-Busch (A-B) and currently owned by SeaWorld Parks & Entertainment, a division of The Blackstone Group?
//Busch Gardens Williamsburg    Six Flags Hurricane Harbor    Western Playland    Los Aleros
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
                var c1 = new Category{ Name = "Sports" };
                var c2 = new Category { Name = "Education" };
                var c3 = new Category { Name = "People" };
                var c4 = new Category { Name = "Geography" };
                var c5 = new Category { Name = "Entertainment" };

                var categories = new List<Category> {c1, c2, c3, c4, c5};

                db.BeginTransaction();
                db.InsertAll(categories);

                db.Commit();
            }
        }

        /// <summary>
        /// Use this for testing only.
        /// </summary>
        /// <param name="questionName"></param>
        /// <returns>
        /// Whether or not the question exists.
        /// </returns>
        public static Questions DoesQuestionNameInTableExist(String questionName)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();
                db.Insert(new Questions
                    {
                        CategoryId = 5,
                        QuestionName = "Hello?",
                        TimesCorrect = 2,
                        TimesViewed = 3,
                    });

                db.Insert(new Questions
                {
                    CategoryId = 5,
                    QuestionName = "how are you?",
                    TimesCorrect = 2,
                    TimesViewed = 3,
                });

                // don't forget to fucking commit... liz is a tard.
                db.Commit();

                var questions = GetQuestions("how are you?");
                return questions;

               var returnQuestion1 = db.Get<Questions>(q => q.QuestionName == questionName );
               var returnQuestion2 = db.Get<Questions>(q => q.QuestionName == "how are you?");
               return returnQuestion2;
            }
        }

        private static Questions GetQuestions(String nameOfQuestion)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var returnQuestionsfrom = db.Get<Questions>(q => q.QuestionName == nameOfQuestion);
                return returnQuestionsfrom;
            }
        }
        
    }
}