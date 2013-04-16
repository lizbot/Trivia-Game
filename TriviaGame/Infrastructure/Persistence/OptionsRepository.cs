using System;
using Domain.Persistence;
using SQLite;
using Infrastructure.Initialization;
using GeneralOptions = Application.Model.GeneralOptions;
using CustomOptions = Application.Model.CustomOptions;

namespace Infrastructure.Persistence
{
    public class OptionsRepository : IOptionsRepository 
    {
        public CustomOptions GetCustomOptions()
        {
             var returnedOptions = new CustomOptions();

            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var options = db.Get<Model.CustomOptions>(opts => opts.CustomOptionId == 2);
                if (options.CustomOptionId == 2)
                {
                    returnedOptions = new CustomOptions
                        {
                            CategoryId = (Int32) options.CategoryId,
                            CustomOptionId = options.CustomOptionId,
                            IsTimerOn = options.IsTimerOn,
                            NumberOfAnswersDisplayed = options.NumberOfAnswersDisplayed,
                            NumberOfQuestionsDesired = options.NumberOfQuestionsDesired
                        };

                    return returnedOptions;
                }

                options = db.Get<Model.CustomOptions>(opts => opts.CustomOptionId == 1);

                if (options.CustomOptionId == 1)
                {
                    returnedOptions = new CustomOptions
                        {
                            CategoryId = (Int32) options.CategoryId,
                            CustomOptionId = options.CustomOptionId,
                            IsTimerOn = options.IsTimerOn,
                            NumberOfAnswersDisplayed = options.NumberOfAnswersDisplayed,
                            NumberOfQuestionsDesired = options.NumberOfQuestionsDesired
                        };

                    return returnedOptions;
                }
            }

            return returnedOptions;
        }

        public GeneralOptions GetGeneralOptions()
        {
            var returnedOptions = new GeneralOptions();

            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var options = db.Get<Model.GeneralOptions>(opts => opts.GeneralOptionId == 2);
                if (options.GeneralOptionId == 2)
                {
                    returnedOptions = new GeneralOptions
                        {
                            GeneralOptionsId = options.GeneralOptionId,
                            IsMusicOn = options.IsMusicOn,
                            IsSoundEffectsOn = options.IsSoundEffectsOn
                        };

                    return returnedOptions;
                }
                
                options = db.Get<Model.GeneralOptions>(opts => opts.GeneralOptionId == 1);
                if (options.GeneralOptionId == 1)
                {
                    returnedOptions = new GeneralOptions
                        {
                            GeneralOptionsId = options.GeneralOptionId,
                            IsMusicOn = options.IsMusicOn,
                            IsSoundEffectsOn = options.IsSoundEffectsOn
                        };

                    return returnedOptions;
                }
            }

            return returnedOptions;
        }

        public void UpdateGeneralOptions(GeneralOptions options)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var userGeneralOptions = new Model.GeneralOptions
                {
                    GeneralOptionId = options.GeneralOptionsId,
                    IsMusicOn = options.IsMusicOn,
                    IsSoundEffectsOn = options.IsSoundEffectsOn,
                };

                if (userGeneralOptions.GeneralOptionId == 1)
                {
                    if (!(userGeneralOptions.IsMusicOn == false) || !(userGeneralOptions.IsSoundEffectsOn == false))
                    {
                        var newRowToInsert = new Model.GeneralOptions
                        {
                            IsMusicOn = options.IsMusicOn,
                            IsSoundEffectsOn = options.IsSoundEffectsOn,
                        };

                        db.Insert(newRowToInsert);
                        db.Commit();
                    }
                }
                else
                {
                    db.Update(userGeneralOptions);
                    db.Commit();
                }
              
            }
        }

        public void UpdateCustomOptions(CustomOptions options)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var userCustomOption = new Model.CustomOptions
                {
                    CustomOptionId = options.CustomOptionId,
                    IsTimerOn = options.IsTimerOn,
                    NumberOfAnswersDisplayed = options.NumberOfAnswersDisplayed,
                    NumberOfQuestionsDesired = options.NumberOfQuestionsDesired,
                };

                if (userCustomOption.CustomOptionId == 1)
                {
                    if (!(userCustomOption.IsTimerOn == false) || !(userCustomOption.NumberOfAnswersDisplayed == 4) || !(userCustomOption.NumberOfQuestionsDesired == 20))
                    {
                        var newRowToInsert = new Model.CustomOptions
                        {
                            IsTimerOn = options.IsTimerOn,
                            NumberOfAnswersDisplayed = options.NumberOfAnswersDisplayed,
                            NumberOfQuestionsDesired = options.NumberOfQuestionsDesired,
                        };

                        db.Insert(newRowToInsert);
                        db.Commit();
                    }
                }
                else
                {
                    db.Update(userCustomOption);
                    db.Commit();
                }
            }
        }
    }
}