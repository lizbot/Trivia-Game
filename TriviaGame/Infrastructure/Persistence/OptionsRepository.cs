using Application.Model;
using Domain.Persistence;
using System;
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
            throw new System.NotImplementedException();
        }

        public GeneralOptions GetGeneralOptions()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateGeneralOptions(GeneralOptions options)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var userGeneralOptions = new GeneralOptions
                {
                    IsMusicOn = options.IsMusicOn,
                    IsSoundEffectsOn = options.IsSoundEffectsOn,
                };

                //TODO(LAURA): need to work out on overriding the second row of the options 
                //var isTimeToOverride = db.Table<GeneralOptions>().Count();
               
                //if (isTimeToOverride > 1)
                //{
                //   db.Update(options);
                //   db.Commit();
                //}
                //else
                //{
                //    db.Insert(userGeneralOptions);
                //    db.Commit();
                //}
            }
        }

        public void UpdateCustomOptions(CustomOptions options)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();

                var userCustomOption = new CustomOptions
                {
                    IsTimerOn = options.IsTimerOn,
                    NumberOfAnswersDisplayed = options.NumberOfAnswersDisplayed,
                    NumberOfQuestionsDesired = options.NumberOfQuestionsDesired,
                };

                //TODO(LAURA): need to work out on overriding the second row of the options

                //if (options.CustomOptionId == 2)
                //{
                //    db.Update(userCustomOption);
                //    db.Commit();
                //}

                //else
                //{
                    db.Insert(userCustomOption);
                    db.Commit();
                //}
            }
        }
    }
}