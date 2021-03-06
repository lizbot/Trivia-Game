﻿using System;
using System.Collections.Generic;
using SQLite;
using Infrastructure.Model;
using System.Linq;
using Answer = Infrastructure.Model.Answer;
using Category = Infrastructure.Model.Category;
using GameSaved = Infrastructure.Model.GameSaved;
using GeneralOptions = Infrastructure.Model.GeneralOptions;
using CustomOptions = Infrastructure.Model.CustomOptions;
using EndOfGameStatistics = Infrastructure.Model.EndOfGameStatistics;
using OverallStatistics = Infrastructure.Model.OverallStatistics;
using System.Text.RegularExpressions;

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
                db.CreateTable<CustomOptions>();
                db.CreateTable<GeneralOptions>();
                db.CreateTable<EndOfGameStatistics>();
                db.CreateTable<OverallStatistics>();
                db.CreateTable<GameSaved>();
                db.CreateTable<Category>();
            }
            
            // Generate base scripts for initializing values in the database.
            var checkGenOpts = CheckToSeeIfGeneralOptionsExist();
            var checkCustOpts = CheckToSeeIfCustomOptionsExist();
            var checkOverallStats = CheckToSeeIfOverallStatsExist();
            var checkEogStats = CheckToSeeIfEndOfGameStatisticsExist();
            var checkCategories = CheckToSeeIfCategoriesExist();
            var checkToSeeQuestionAndAnswers = CheckToSeeIfQuestionsAndAnswersExist();


            if (!checkGenOpts)
            {
                GenerateGeneralOptions();
            }
            if (!checkCustOpts)
            {
                GenerateCustomOptions();
            }
            if (!checkOverallStats)
            {
                DefaultOverallStatistics();
            }
            if (!checkEogStats)
            {
                DefaultEndOfGameStatistics();
            }
            if (!checkCategories)
            {
                GenerateCategories();
            }
            if (!checkToSeeQuestionAndAnswers)
            {
                GenerateQuestionsAndAnswers();
            }
        }

        private static Boolean CheckToSeeIfQuestionsAndAnswersExist()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {

                db.BeginTransaction();

                //This checks whether there is as resultFromOverallStats in the database
                var resultFromCategory = (from id in db.Table<Questions>() select id).Count();

                return resultFromCategory > 0;
            }
        }

        private static Boolean CheckToSeeIfCategoriesExist()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {

                db.BeginTransaction();

                //This checks whether there is as resultFromOverallStats in the database
                var resultFromCategory = (from id in db.Table<Category>() select id).Count();

                return resultFromCategory > 0;
            }
        }

        private static Boolean CheckToSeeIfEndOfGameStatisticsExist()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {

                db.BeginTransaction();

                //This checks whether there is as resultFromOverallStats in the database
                var resultFromEndOfGameStatistics = (from id in db.Table<EndOfGameStatistics>() select id).Count();

                return resultFromEndOfGameStatistics > 0;
            }
        }

        private static Boolean CheckToSeeIfOverallStatsExist()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {

                db.BeginTransaction();

                //This checks whether there is as resultFromOverallStats in the database
                var resultFromOverallStats = (from id in db.Table<OverallStatistics>() select id).Count();

                return resultFromOverallStats > 0;
            }

        }

        private static Boolean CheckToSeeIfCustomOptionsExist()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {

                db.BeginTransaction();

                //This checks whether there is as options in the database
                var resultFromGeneralOptions = (from id in db.Table<GeneralOptions>() select id).Count();

                return resultFromGeneralOptions > 0;
            }
        }

        private static Boolean CheckToSeeIfGeneralOptionsExist()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                
                db.BeginTransaction();

                //This checks whether there is as options in the database
                 var resultFromCustomOptions =  (from id in db.Table<CustomOptions>()select id).Count();

                 return resultFromCustomOptions > 0;
            }

        }

        /**
         * This equation reads all the questions and answers from the files and insert those
         * values into the database
         **/ 
        private async static void GenerateQuestionsAndAnswers()
        {
            String questionName;
            Int32 categoryId;
            String rightAnswerName;
            List<String> wrongAnswerNames;


            string category;
            string[] subjects = new string[4];

            //Paths for the text files locations in QA_TextFiles folder in the Infrastructure solution
            string[] _path = { @"Infrastructure\QA_TextFiles\Education.txt", @"Infrastructure\QA_TextFiles\Sports.txt",
                             @"Infrastructure\QA_TextFiles\Geography.txt",@"Infrastructure\QA_TextFiles\Entertainment.txt",
                                @"Infrastructure\QA_TextFiles\People.txt"};
            //App folder
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            foreach(var spec_path in _path)
            {
                //Get the files in that folder
                var _File = await _Folder.GetFileAsync(spec_path);
                //This is used for the categoryID later on
                category = spec_path.Remove(0, 28);
                category = category.Replace(".txt", string.Empty);
                //Every line in the txt files
                var _ReadThis = await Windows.Storage.FileIO.ReadLinesAsync(_File);

                
                for (int i = 0; i < _ReadThis.Count(); i++)
                {
                    //the first one always will be the question
                    questionName = _ReadThis[i++];
                    //then we get all the answers
                    subjects = Regex.Split(_ReadThis[i++], @"    ");
                    //correct answer is saved in the first string after spliting the string
                    rightAnswerName = subjects[0];
                    //the wrong answers
                    wrongAnswerNames = new List<string> { subjects[1], subjects[2], subjects[3] };

                    //Switch statement to decided the number for the
                    //categoryID based on the category variable 
                    switch(category)
                    {
                        case "Sports":
                            categoryId = 1;
                            break;
                        case "Education":
                            categoryId = 2;
                            break;
                        case "People":
                            categoryId = 3;
                            break;
                        case "Geography":
                            categoryId = 4;
                            break;
                        case "Entertainment":
                            categoryId = 5;
                            break;
                        default:
                            categoryId = 6;
                            break;
                    }
                    
                    //populate the database with the info
                    GenerateAnswersForQuestions(questionName, categoryId, rightAnswerName, wrongAnswerNames);
                }
            }
        }

        

        private static void GenerateAnswersForQuestions(
            String questionName, 
            Int32 categoryId, 
            String rightAnswerName, 
            IEnumerable<String> wrongAnswerNames)
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
                var c6 = new Category { Name = "Custom" };

                var categories = new List<Category> { c1, c2, c3, c4, c5, c6 };

                db.BeginTransaction();
                db.InsertAll(categories);

                db.Commit();
            }
        }

        private static void GenerateCustomOptions()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var customOptions = new Model.CustomOptions
                {
                      IsTimerOn = false,
                      NumberOfAnswersDisplayed = 4,
                      NumberOfQuestionsDesired = 20
                };

                db.Insert(customOptions);
                db.Commit();
            }
        }

        private static void GenerateGeneralOptions()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var option = new GeneralOptions
                {
                    IsMusicOn = true,
                    IsSoundEffectsOn = true
                };

                db.Insert(option);
                db.Commit();
            }
        }

        private static void DefaultOverallStatistics()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var defaultOverallOption = new OverallStatistics
                {
                    TotalCorrectAnswers = 0,
                    TotalQuestionsAttempted = 0,
                    LongestOverallStreak = 0,                   
                };

                db.Insert(defaultOverallOption);
                db.Commit();
            }
        }

        private static void DefaultEndOfGameStatistics()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var defaultEndOfGameStats = new EndOfGameStatistics
                {
                    TotalAnsweredCorrectly = 0,
                    TotalAnsweredIncorrectly = 0,
                    LongestStreak = 0,
                };

                db.Insert(defaultEndOfGameStats);
                db.Commit();
            }
        }
    }
}